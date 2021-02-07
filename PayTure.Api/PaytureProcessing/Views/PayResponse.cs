using PayTureTest.Extensions;
using System;
using System.Linq;

namespace PayTureTest.PaytureProcessing.Views
{
    /// <summary>
    /// Ответ на запрос платежа
    /// </summary>
    public class PayResponse
    {
        /// <summary>
        /// Статус операции
        /// </summary>
        public OperationStatus OperationStatus { get; set; }

        /// <summary>
        /// Идентификатор платежа в системе Продавца
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Наименование платежного Терминала
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Сумма платежа в копейках
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// Адрес сервера аутентификации 3-D Secure
        /// </summary>
        public string ACSUrl { get; set; }

        /// <summary>
        /// Запрос на аутентификацию 3-D Secure
        /// </summary>
        public string PaReq { get; set; }

        /// <summary>
        /// Уникальный идентификатор транзакции (MD)
        /// </summary>
        public string ThreeDSKey { get; set; }

        /// <summary>
        /// Версия протокола 3-D Secure
        /// </summary>
        public string ThreeDSVersion { get; set; }

        /// <summary>
        /// Конечный Терминал, на котором был выполнен платеж
        /// </summary>
        public string FinalTerminal { get; set; }

        /// <summary>
        /// Дополнительные параметры транзакции
        /// </summary>
        public AddInfo AddInfo { get; set; }

        /// <summary>
        /// Код ошибки
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="view">Xml представление ответа на запрос платежа</param>
        public PayResponse(PayResponseXmlView view)
        {
            OperationStatus = OperationStatusParser.Parse(view.Success);
            if (Guid.TryParse(view.OrderId, out var orderId))
                OrderId = orderId;
            Key = view.Key;
            if (int.TryParse(view.Amount, out var amount))
                Amount = amount;
            ACSUrl = view.ACSUrl;
            PaReq = view.PaReq;
            ThreeDSKey = view.ThreeDSKey;
            ThreeDSVersion = view.ThreeDSVersion;
            FinalTerminal = view.FinalTerminal;
            ErrCode = view.ErrCode;
            AddInfo = view.AddInfo.ToDictionary(x => x.Key, y => y.Value).ToObject<AddInfo>();
        }
    }
}