using AutoMapper;
using GNB_Data.Data;
using GNB_Data.Response;
using GNB_Repository.Base;
using GNB_Repository.Context;
using GNB_Repository.Models;
using GNB_Service.Repository;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace GNB_Service.Services
{
    public class ConversionRateService : IConversionRate
    {        
        private readonly GNBContext GNBcontext;
        private readonly IRateRepository rateRepository;
        private readonly IGnbAPI gnbAPIService;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public ConversionRateService(IGnbAPI gnbAPIService, IRateRepository rateRepository, GNBContext context, IMapper mapper, ILogger<ConversionRateService> logger)
        {
            this.gnbAPIService = gnbAPIService;
            this.rateRepository = rateRepository;
            this.GNBcontext = context;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<RateResponseDTO> GetConversionRates()
        {            
            try
            {
                var APIresult = await gnbAPIService.GetAPIRates();
                if (APIresult != null) {
                    UpdateRatesFromAPI(APIresult);
                    return APIresult;
                }                
                return await GetRates();                
            }
            catch(Exception e)
            {
                logger.LogInformation(e, String.Format(ResourcesService.ERROR, e?.Message));
                return await GetRates();
            }            
        }        
        public async Task GetDefaultConversion(GNBTransactionResponse gNBTransactionResponse, string defaultCoin)
        {
            foreach (var transaction in gNBTransactionResponse.Transactions)
            {
                var rate = await GetRateByRange(transaction.Currency, defaultCoin);

                transaction.Amount = Math.Round(transaction.Amount * rate, 2);
                transaction.Currency = defaultCoin;
            }
        }
        private async Task<RateResponseDTO> GetRates()
        {
            var rateResponse = new RateResponseDTO();
            var rates = await rateRepository.GetAllRates();
            rateResponse.ConversionRates = mapper.Map<List<RateDTO>>(rates);
            return rateResponse;
        }
        private async Task<decimal> GetRateByRange(string from, string to)
        {
            var conversionRateResponse = await GetRates();
            return conversionRateResponse.ConversionRates.Where(x => x.From.Equals(from) && x.To.Equals(to)).Any()
                ? conversionRateResponse.ConversionRates.Find(x => x.From.Equals(from) && x.To.Equals(to)).Rate
                : 1;
        }
        //TO DO
        private async void UpdateRatesFromAPI(RateResponseDTO rateResponse)
        {
            try
            {
                var BDRates = await rateRepository.GetAll();
                await rateRepository.DeleteRange(BDRates);
                await rateRepository.AddRange(rateResponse.ConversionRates.Select(x=> new Rate()
                {
                    From= x.From,
                    To= x.To,   
                    RateValue = x.Rate
                }));
                
            }
            catch(Exception e)
            {
                logger.LogError(e, e?.InnerException?.Message);
            }
        }
    }
}
