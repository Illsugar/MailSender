using MailSender.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Services
{
    [TestClass]
    public class TextEncoderTests
    {
        [TestMethod]
        public void Encode_ABC_return_DEF_with_key_3()
        {
            // A-A-A

            // Arrange - подготовка данных
            var str = "ABC";
            var Key = 3;
            var expected_result = "DEF";

            // Act - действие, нацеленное на тестирование кода
            var actual_result = TextEncoder.Encode(str, Key);

            // Assert - проверка утверждений
            Assert.AreEqual(expected_result, actual_result);

            //StringAssert.Matches();
            //CollectionAssert.AreEquivalent();
        }

        [TestMethod]
        public void Decode_DEF_return_ABC_with_key_3()
        {
            // A-A-A

            // Arrange - подготовка данных
            var str = "DEF";
            var Key = 3;
            var expected_result = "ABC";

            // Act - действие, нацеленное на тестирование кода
            var actual_result = TextEncoder.Decode(str, Key);

            // Assert - проверка утверждений
            Assert.AreEqual(expected_result, actual_result);

            //StringAssert.Matches();
            //CollectionAssert.AreEquivalent();
        }
    }
}
