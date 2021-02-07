using Microsoft.AspNetCore.Mvc;
using PayTureTest.PaytureProcessing.Views;
using System.Threading.Tasks;

namespace PayTureTest.PaytureProcessing
{
    /// <summary>
    /// Контроллер для работы с payture
    /// </summary>
    [Route("api/payture")]
    [ApiController]
    public class PaytureController : ControllerBase
    {
        private readonly PaytureFacade _facade;
        public PaytureController(PaytureFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Обработать платеж
        /// </summary>        
        [HttpGet("pay")]
        async public Task<ActionResult<PayResponse>> ProcessPayAsync()
        {
            var res = await _facade.PayAsync();
            if (res.IsFailed)
                return new BadRequestObjectResult(res.Errors);            
            return res.Value;
        }
    }
}