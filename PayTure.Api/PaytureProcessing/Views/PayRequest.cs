using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PayTureTest.PaytureProcessing.Views
{
    /// <summary>
    /// Запрос на создание платежа
    /// </summary>
    public class PayRequest
    {
        /// <summary>
        /// Наименование платежного Терминала
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Уникальный идентификатор платежа в системе Продавца
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Сумма платежа в копейках
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Параметры для совершения транзакции
        /// </summary>
        public PayInfo PayInfo { get; set; }

        /// <summary>
        /// Идентификатор Покупателя в системе Payture AntiFraud
        /// </summary>
        public Guid? CustomerKey { get; set; }

        /// <summary>
        /// Идентификатор платежа в системе Payture AntiFraud
        /// </summary>
        public Guid? PaytureId { get; set; }

        /// <summary>
        /// Дополнительные поля транзакции
        /// </summary>
        public Dictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Информация о чеке в формате JSON, закодированная в Base64
        /// </summary>
        public string Cheque { get; set; }

        public FormUrlEncodedContent ToFormContent()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("Key", Key);
            dict.Add("Amount", Amount.ToString());
            dict.Add("OrderId", OrderId.ToString());

            dict.Add("PayInfo", PayInfo.ToString());
            if (CustomFields != null)
            {
                var customFields = new StringBuilder();
                foreach (var field in CustomFields)
                    customFields.Append($"{field.Key}={field.Value}; ");
                dict.Add("CustomFields", customFields.ToString());
            }

            return new FormUrlEncodedContent(dict);
        }
    }
}