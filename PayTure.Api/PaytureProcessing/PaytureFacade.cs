using FluentResults;
using Microsoft.Extensions.Logging;
using PayTureTest.PaytureProcessing.Client;
using PayTureTest.PaytureProcessing.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayTureTest.PaytureProcessing
{
    /// <summary>
    /// Фасад для работы с PayTure
    /// </summary>
    public class PaytureFacade
    {
        private readonly IPayTureClient _client;
        private readonly ILogger<PaytureFacade> _logger;

        public PaytureFacade(IPayTureClient client, ILogger<PaytureFacade> logger)
        {
            _client = client;
            _logger = logger;
        }

        /// <summary>
        /// Совершить оплату
        /// </summary>
        async public Task<Result<PayResponse>> PayAsync()
        {
            var payReq = GenerateTestReq();
            var payResult = await _client.PayAsync(payReq);
            if (payResult.IsFailed)
            {
                _logger.LogError(payResult.Errors.ToString(), payReq, payResult);
                return payResult;
            }

            if (payResult.Value.OperationStatus == OperationStatus.None)
            {
                const string msg = "Неизвестный статуст оплаты в PayTune.";
                _logger.LogError(msg, payReq, payResult.Value);
                return Result.Fail<PayResponse>(msg);
            }

            if (payResult.Value.OperationStatus == OperationStatus.Fail)
            {
                const string msg = "Отказ оплаты в PayTune.";
                _logger.LogInformation(msg, payReq, payResult.Value);
                return Result.Fail<PayResponse>($"{msg} Код ошибки: {payResult.Value.ErrCode}");
            }
            return payResult;
        }

        private PayRequest GenerateTestReq()
        {
            var payInfo = new PayInfo
            {
                Amount = 123,
                PAN = "5218851946955484",
                EMonth = 12,
                EYear = 22,
                CardHolder = "Ivan Ivanov",
                OrderId = Guid.NewGuid(),
                SecureCode = 123
            };
            return new PayRequest
            {
                Amount = payInfo.Amount,
                Key = "Merchant",
                OrderId = payInfo.OrderId,
                PayInfo = payInfo,
                CustomFields = new Dictionary<string, string> { { "IP", "96.196.254.36" } }
            };
        }
    }
}