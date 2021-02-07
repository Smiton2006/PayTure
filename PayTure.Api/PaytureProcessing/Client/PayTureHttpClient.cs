using FluentResults;
using Microsoft.Extensions.Logging;
using PayTureTest.PaytureProcessing.Views;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PayTureTest.PaytureProcessing.Client
{
    /// <summary>
    /// HTTP реализация клиента для общения с PayTure
    /// </summary>
    public class PayTureHttpClient : IPayTureClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<PayTureHttpClient> _logger;

        private const string address = "https://sandbox3.payture.com";
        private const string payRoute = "api/Pay";

        public PayTureHttpClient(HttpClient client, ILogger<PayTureHttpClient> logger)
        {
            client.BaseAddress = new Uri(address);
            _client = client;
            _logger = logger;
        }

        ///<inheritdoc/>
        async public Task<Result<PayResponse>> PayAsync(PayRequest request)
        {
            HttpResponseMessage res;
            try
            {
                res = await _client.PostAsync(payRoute, request.ToFormContent());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return Result.Fail<PayResponse>("Не удалось выполнить запрос к PayTure");
            }

            if (!res.IsSuccessStatusCode)
            {
                _logger.LogError("PayTure вернул неуспешны код ответа", res);
                return Result.Fail<PayResponse>("PayTure вернул неуспешны код ответа");
            }

            var resStream = await res.Content.ReadAsStreamAsync();
            var parseRes = PaytureParser.ParsePayResponse(resStream);
            if (parseRes.IsFailed)
            {
                _logger.LogError("Ошибка во время парсинга ответа", parseRes);
                return Result.Fail<PayResponse>(parseRes.ToString());
            }

            return Result.Ok(parseRes.Value);
        }
    }
}