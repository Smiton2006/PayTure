namespace PayTureTest.PaytureProcessing.Views
{
    /// <summary>
    /// Дополнительные параметры транзакции, которые могут быть переданы
    /// в ответе платежного шлюза по согласованию со службой поддержки Payture
    /// </summary>
    public class AddInfo
    {
        /// <summary>
        /// Код авторизации
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// Уникальный номер транзакции, присвоенный банком-эквайером (RRN)
        /// </summary>
        public string RefNumber { get; set; }

        /// <summary>
        /// Фамилия и имя держателя карты
        /// </summary>
        public string CardHolder { get; set; }

        /// <summary>
        /// Платежная система
        /// </summary>
        public string PaymentSystem { get; set; }

        /// <summary>
        /// Маскированный номер карты (первые 6 и последние 4 цифры: 123456хххххх1234)
        /// </summary>
        public string PANMAsk { get; set; }

        /// <summary>
        /// Конечная сумма возмещения в копейках (общая сумма платежа минус комиссия, установленная на терминале)
        /// </summary>
        public string Compensation { get; set; }

        /// <summary>
        /// Срок действия карты в формате ММ/ГГГГ
        /// </summary>
        public string ExpDate { get; set; }

        /// <summary>
        /// Двухбуквенный ISO код страны банка эмитента карты
        /// </summary>
        public string BankCountryCode { get; set; }

        /// <summary>
        /// Название банка эмитента карты
        /// </summary>
        public string BankHumanName { get; set; }

        /// <summary>
        /// Город банка эмитента карты
        /// </summary>
        public string BankCity { get; set; }

        /// <summary>
        /// Тип карты. Например, V_GOLD, M_WORLD, MIR_CLASSIC
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// Признак необходимости аутентификации 3DS для текущей операции
        /// </summary>
        public string Is3ds { get; set; }

        /// <summary>
        /// Email зарегистрированного в системе Payture Покупателя, либо параметр Email, переданный в CustomFields
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона Покупателя, зарегистрированного в системе Payture, либо параметр PhoneNumber, переданный в CustomFields
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Тип оплаты: None (оплата картой); ApplePay, GooglePay, SamsungPay, MasterPass, GooglePayToken, GooglePayCard, VkPay, VisaToken
        /// </summary>
        public string ExternalWallet { get; set; }

        /// <summary>
        /// Общая комиссия по операции в копейках (комиссия шлюза, банка и партнера)
        /// </summary>
        public string GeneralFee { get; set; }

        /// <summary>
        /// Дата совершения операции в формате ГГГГММДДччммсс
        /// </summary>
        public string OrderDate { get; set; }

        /// <summary>
        /// Идентификатор зарегистрированной карты в системе Payture
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Статус зарегистрированной карты
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Логин Покупателя в системе Payture
        /// </summary>
        public string VwUserLgn { get; set; }
    }
}