using PayTureTest.PaytureProcessing;
using System.IO;
using System.Text;
using Xunit;

namespace PayTureTest.Test
{
    public class PayTureParserTests
    {
        [Fact]
        public void ParsePayResponse_ValidData_SuccesParse()
        {
            var str =
            "<Pay OrderId=\"2d436b58-1c49-aa25-8137-ffdc3fb5210f\" Key=\"Merchant\" Success=\"True\" Amount=\"12420\">" +
                "<AddInfo Key =\"AuthCode\" Value=\"122938\" />" +
                "<AddInfo Key =\"RefNumber\" Value=\"637176303771\" />" +
                "<AddInfo Key =\"CardHolder\" Value=\"Ivan Ivanov\" />" +
                "<AddInfo Key =\"PaymentSystem\" Value=\"MasterCard\" />" +
                "<AddInfo Key =\"PANMask\" Value=\"411111xxxxxx0031\" />" +
                "<AddInfo Key =\"Compensation\" Value=\"12360\" />" +
                "<AddInfo Key =\"BankHumanName\" Value=\"TEST BANK\" />" +
                "<AddInfo Key =\"BankCountryCode\" Value=\"US\" />" +
                "<AddInfo Key =\"BankCity\" Value=\"\" />" +
                "<AddInfo Key =\"cardtype\" Value=\"V_BUSINESS\" />" +
                "<AddInfo Key =\"externalmerchantorderid\" Value=\"2d436b58-1c49-aa25-8137-ffdc3fb5210f\" />" +
                "<AddInfo Key =\"externalwallet\" Value=\"None\" />" +
                "<AddInfo Key =\"generalfee\" Value=\"60\" />" +
                "<AddInfo Key =\"is3ds\" Value=\"False\" />" +
                "<AddInfo Key =\"orderdate\" Value=\"20200220125920\" />" +
            "</Pay>";

            var payResponseRes = PaytureParser.ParsePayResponse(new MemoryStream(Encoding.UTF8.GetBytes(str)));
            Assert.True(payResponseRes.IsSuccess);
            Assert.Equal("2d436b58-1c49-aa25-8137-ffdc3fb5210f", payResponseRes.Value.OrderId.ToString());
            Assert.Equal(12420, payResponseRes.Value.Amount);
            Assert.Equal("122938", payResponseRes.Value.AddInfo.AuthCode);
            Assert.Equal("False", payResponseRes.Value.AddInfo.Is3ds);
        }

        [Fact]
        public void ParsePayResponse_InValidXml_FailParse()
        {
            var str = "<Payy> </Pay>";

            var payResponseRes = PaytureParser.ParsePayResponse(new MemoryStream(Encoding.UTF8.GetBytes(str)));
            Assert.True(payResponseRes.IsFailed);
        }
    }
}