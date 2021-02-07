namespace PayTureTest.PaytureProcessing
{
    /// <summary>
    /// Статусы операции
    /// </summary>
    public enum OperationStatus
    {
        /// <summary>
        /// Отсутсвует
        /// </summary>
        None = 0,

        /// <summary>
        /// Операция неуспешна
        /// </summary>
        Fail = 1,

        /// <summary>
        /// Операция успешна
        /// </summary>
        Success = 2,

        /// <summary>
        /// Необходима аутентификация 3‑D Secure
        /// </summary>
        ThreeDS = 3
    }

    /// <summary>
    /// Парсер статуса операции
    /// </summary>
    public static class OperationStatusParser
    {
        /// <summary>
        /// Получить операции из текстового представления
        /// </summary>
        /// <param name="status">Текстовое представление операции</param>
        public static OperationStatus Parse(string status)
        {
            switch (status)
            {
                case "True":
                    return OperationStatus.Success;

                case "False":
                    return OperationStatus.Fail;

                case "3DS":
                    return OperationStatus.ThreeDS;

                default:
                    return OperationStatus.None;
            }
        }
    }
}