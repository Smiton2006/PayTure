using FluentResults;
using PayTureTest.PaytureProcessing.Views;
using System;
using System.IO;
using System.Xml.Serialization;

namespace PayTureTest.PaytureProcessing
{
    /// <summary>
    /// Парсер ответов от Payture
    /// </summary>
    public static class PaytureParser
    {
        /// <summary>
        /// Распарсить ответ при совершении опаты
        /// </summary>
        /// <param name="stream">Стрим с ответом об оплате</param>        
        public static Result<PayResponse> ParsePayResponse(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(PayResponseXmlView));
            try
            {
                var payXmlView = (PayResponseXmlView)serializer.Deserialize(stream);
                return Result.Ok(new PayResponse(payXmlView));
            }
            catch (Exception ex)
            {
                return Result.Fail<PayResponse>($"Не удалось преобразовать переданный стрим. Ошибка: {ex.Message}");
            }
        }
    }
}
