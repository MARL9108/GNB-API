using GNB_Data.Data;
using GNB_Data.Request;
using GNB_Data.Response;
using GNB_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace GNB_API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GNBController : ControllerBase
    {
        private readonly IConversionRate conversionRateService;
        private readonly ITransaction transactionService;
        private readonly ILogger logger;
        public GNBController(IConversionRate conversionRateService, ITransaction transactionService, ILogger<GNBController> logger)
        {
            this.conversionRateService = conversionRateService;
            this.transactionService = transactionService;
            this.logger = logger;
        }

        [HttpGet("GetAllRates")]
        public async Task<IActionResult> GetAllConversionRates()
        {
            try
            {
                var conversionRates = await conversionRateService.GetConversionRates();
                if (conversionRates?.ConversionRates?.Count > 0) return Ok(conversionRates);
                return NotFound();
            }
            catch(Exception e)
            {
                logger.LogError(e, e?.InnerException?.Message);
                return BadRequest();
            }
        }

        [HttpGet("GetAllTransaction")]
        public async Task<IActionResult> GetAllTransactions()
        {
            try
            {
                var transactions = await transactionService.GetAllTransactions();
                if (transactions?.Transactions?.Count > 0) return Ok(transactions);
                return NotFound();
            }
            catch (Exception e)
            {
                logger.LogError(e, e?.InnerException?.Message);
                return BadRequest();
            }
        }

        [HttpPost("GetTransactionBySku")]
        public IActionResult GetTransaction([FromBody] TransactionRequest transactionRequest)
        {
            try
            {
                var transaction = transactionService.GetTransaction(transactionRequest);
                if (transaction?.Transactions?.Count > 0) return Ok(transaction);
                return NotFound();
            }
            catch (Exception e)
            {
                logger.LogError(e, e?.InnerException?.Message);
                return BadRequest();
            }
        }
    }
}
