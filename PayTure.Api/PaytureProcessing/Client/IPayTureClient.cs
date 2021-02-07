using FluentResults;
using PayTureTest.PaytureProcessing.Views;
using System.Threading.Tasks;

namespace PayTureTest.PaytureProcessing.Client
{
    /// <summary>
    /// Интерфейс клиента для общения с PayTure
    /// </summary>
    public interface IPayTureClient
    {
        /// <summary>
        /// Совершить оплату
        /// </summary>
        /// <param name="request">Запрос на совешение оплаты</param>        
        Task<Result<PayResponse>> PayAsync(PayRequest request);
    }
}