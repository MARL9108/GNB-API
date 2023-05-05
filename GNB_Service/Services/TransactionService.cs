using AutoMapper;
using GNB_Data.Data;
using GNB_Data.Request;
using GNB_Data.Response;
using GNB_Repository.Base;
using GNB_Repository.Context;
using GNB_Repository.Models;
using GNB_Service.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GNB_Service.Services
{
    public class TransactionService : ITransaction
    {
        private readonly GNBContext context;        
        private readonly IConversionRate conversionRateService;
        private readonly IGnbAPI gnbAPIService;
        private readonly ITransactionRepository transactionRepository;
        private readonly IConfiguration config;
        private readonly IMapper mapper;
        private readonly ILogger logger;
        public TransactionService(IConversionRate conversionRateService, IGnbAPI gnbAPIService, GNBContext context, ITransactionRepository transactionRepository, IMapper mapper, IConfiguration config, ILogger<TransactionService> logger)
        {
            this.conversionRateService = conversionRateService;
            this.gnbAPIService = gnbAPIService;
            this.context = context;
            this.transactionRepository = transactionRepository;
            this.mapper = mapper;
            this.config = config;
            this.logger = logger;            
        }
        public async Task<TransactionResponseDTO> GetAllTransactions()
        {
            try
            {
                var APIresult = await gnbAPIService.GetTransactions();
                if (APIresult != null) {
                    UpdateTransactionsFromAPI(APIresult);
                    return APIresult;
                }                
                return await GetTransactions();
            }
            catch (Exception e)
            {
                logger.LogError(e, e?.InnerException?.Message);
                return await GetTransactions();
            }
        }

        public async Task<GNBTransactionResponse> GetTransaction(TransactionRequest transactionRequest)
        {            
            GNBTransactionResponse GNBTransaction = await GetTransactionBySku(transactionRequest.Sku);

            conversionRateService.GetDefaultConversion(GNBTransaction, config["DefaultCoin"]);

            GNBTransaction.totalAmount = GNBTransaction.Transactions.Sum(x => x.Amount);
            return GNBTransaction;
        }

        public async Task<GNBTransactionResponse> GetTransactionBySku(string Sku)
        {
            var GNBTransaction = new TransactionResponseDTO();
            var GNBTransactionResponse = new GNBTransactionResponse();
            GNBTransaction = await GetTransactions();
            GNBTransaction.Transactions = GNBTransaction.Transactions.Where(x => x.Sku.Equals(Sku)).ToList();
            GNBTransactionResponse.Transactions = GNBTransaction.Transactions;
            return GNBTransactionResponse;
        }

        private async Task<TransactionResponseDTO> GetTransactions()
        {
            var transactionResponse = new TransactionResponseDTO();
            var transaction = await transactionRepository.GetAllTransactions();
            transactionResponse.Transactions = mapper.Map<List<TransactionDTO>>(transaction);
            return transactionResponse;
        }
        private async void UpdateTransactionsFromAPI(TransactionResponseDTO transactionResponse)
        {
            try
            {
                var BDTransaction = await transactionRepository.GetAll();
                await transactionRepository.DeleteRange(BDTransaction);
                await transactionRepository.AddRange(transactionResponse.Transactions.Select(x => new Transaction()
                {
                    Sku = x.Sku,
                    Currency = x.Currency,
                    Amount = x.Amount
                }));

            }
            catch (Exception e)
            {
                logger.LogError(e, e?.InnerException?.Message);
            }
        }
    }
}
