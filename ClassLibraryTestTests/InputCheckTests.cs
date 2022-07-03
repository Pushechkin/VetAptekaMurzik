using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryTest.Tests
{
    [TestClass()]
    public class InputCheckTests
    {
        /// <summary>
        /// 1 тест
        /// </summary>
        [TestMethod()]
        public void Check_ValidateSymbols_ReturnsTrue()
        {
            string count = "100";
            bool expected = true;

            bool actual = InputCheck.ValidateInput(count);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 2 тест
        /// </summary>
        [TestMethod()]
        public void Check_ValidateSymbols_ReturnsFalse1()
        {
            string count = "-120";
            bool expected = false;

            bool actual = InputCheck.ValidateInput(count);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 3 тест
        /// </summary>
        [TestMethod()]
        public void Check_ValidateSymbols_ReturnsFalse2()
        {
            string count = "def";
            bool expected = false;


            bool actual = InputCheck.ValidateInput(count);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 4 тест
        /// </summary>
        [TestMethod()]
        public void Check_ValidateSymbols_ReturnsFalse3()
        {
            string count = "10000";
            bool expected = false;


            bool actual = InputCheck.ValidateInput(count);

            Assert.AreEqual(expected, actual);
        }
    }
}