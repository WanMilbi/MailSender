using MailSender.lib.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class TestEncoderTests
    {
        [TestMethod]
        public void Encode_ABC_to_BCD_with_key_1()
        {
            // A-A-A = Arrange - Act - Assert


            #region Arrange
            const string str = "ABC";
            const int key = 1;
            const string execpted_str = "BCD";
            #endregion

            #region Act
            var actual_str = TextEncoder.Encode(str, key);
            #endregion

            #region Assert
Assert.AreEqual(execpted_str, actual_str);
            

            #endregion
        }
        [TestMethod]
        public void Decode_BCD_to_ABC_with_key_1()
        {
            // A-A-A = Arrange - Act - Assert


            #region Arrange
            const string str = "BCD";
            const int key = 1;
            const string execpted_str = "ABC";
            #endregion

            #region Act
            var actual_str = TextEncoder.Decode(str, key);
            #endregion

            #region Assert
            Assert.AreEqual(execpted_str, actual_str);


            #endregion
        }
    }
}
