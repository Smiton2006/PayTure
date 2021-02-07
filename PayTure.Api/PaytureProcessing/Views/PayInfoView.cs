using System;
using System.Text;

namespace PayTureTest.PaytureProcessing.Views
{
    /// <summary>
    /// Параметры для совершения транзакции
    /// </summary>
    public class PayInfo
    {
        /// <summary>
        /// Номер карты
        /// </summary>
        public string PAN { get; set; }

        /// <summary>
        /// Месяц истечения срока действия карты
        /// </summary>
        public int EMonth { get; set; }

        /// <summary>
        /// Год истечения срока действия карты
        /// </summary>
        public int EYear { get; set; }

        /// <summary>
        /// Уникальный идентификатор платежа в системе Продавца
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Сумма платежа в копейках
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// CVC2/CVV2 код
        /// </summary>
        public int? SecureCode { get; set; }

        /// <summary>
        /// Фамилия и имя держателя карты
        /// </summary>
        public string CardHolder { get; set; }

        public override string ToString()
        {
            var payInfo = new StringBuilder();
            payInfo.Append($"PAN={PAN}; EMonth={EMonth}; EYear={EYear}; " +
                $"OrderId={OrderId}; Amount={Amount}");
            if (SecureCode != null)
                payInfo.Append($"; SecureCode={SecureCode}");

            if (CardHolder != null)
                payInfo.Append($"; CardHolder={CardHolder}");
            return payInfo.ToString();
        }
    }
}