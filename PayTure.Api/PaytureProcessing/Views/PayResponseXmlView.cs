using System.Collections.Generic;
using System.Xml.Serialization;

namespace PayTureTest.PaytureProcessing.Views
{
    /// <summary>
    /// Xml представление ответа на запрос платежа
    /// </summary>
    [XmlRoot("Pay")]
    public class PayResponseXmlView
    {
        /// <summary>
        /// Признак успешности операции.
        /// </summary>
        [XmlAttribute("Success")]
        public string Success { get; set; }

        /// <summary>
        /// Идентификатор платежа в системе Продавца
        /// </summary>
        [XmlAttribute("OrderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// Наименование платежного Терминала
        /// </summary>
        [XmlAttribute("Key")]
        public string Key { get; set; }

        /// <summary>
        /// Сумма платежа в копейках
        /// </summary>
        [XmlAttribute("Amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Адрес сервера аутентификации 3-D Secure
        /// </summary>
        [XmlAttribute("ACSUrl")]
        public string ACSUrl { get; set; }

        /// <summary>
        /// Запрос на аутентификацию 3-D Secure
        /// </summary>
        [XmlAttribute("PaReq")]
        public string PaReq { get; set; }

        /// <summary>
        /// Уникальный идентификатор транзакции (MD)
        /// </summary>
        [XmlAttribute("ThreeDSKey")]
        public string ThreeDSKey { get; set; }

        /// <summary>
        /// Версия протокола 3-D Secure
        /// </summary>
        [XmlAttribute("ThreeDSVersion")]
        public string ThreeDSVersion { get; set; }

        /// <summary>
        /// Конечный Терминал, на котором был выполнен платеж
        /// </summary>
        [XmlAttribute("FinalTerminal")]
        public string FinalTerminal { get; set; }

        /// <summary>
        /// Дополнительные параметры транзакции
        /// </summary>
        [XmlElement("AddInfo")]
        public List<AddInfoXmlView> AddInfo { get; set; }

        /// <summary>
        /// Код ошибки
        /// </summary>
        [XmlAttribute("ErrCode")]
        public string ErrCode { get; set; }
    }
}