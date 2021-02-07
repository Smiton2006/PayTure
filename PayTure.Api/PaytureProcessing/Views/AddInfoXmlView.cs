using System.Xml.Serialization;

namespace PayTureTest.PaytureProcessing.Views
{
    /// <summary>
    /// Xml представление дополнительных параметров о платеже
    /// </summary>
    public class AddInfoXmlView
    {
        /// <summary>
        /// Наименование параметра
        /// </summary>
        [XmlAttribute("Key")]
        public string Key { get; set; }

        /// <summary>
        /// Значение параметра
        /// </summary>
        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
