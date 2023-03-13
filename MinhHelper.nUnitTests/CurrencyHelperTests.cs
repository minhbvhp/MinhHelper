using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHelper.nUnitTests
{
    public class CurrencyHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RemoveRedundantWhitespaces_Test()
        {
            //Assign
            decimal input1 = 512121.15M;
            decimal input2 = 2100;
            decimal input3 = 2100;
            long input4 = 500000;
            long input5 = 505000;


            //Act
            var Test1 = CurrencyHelper.NumberToWords(input1, NationalCurrency.USD).RemoveRedundantWhitespaces();
            var Test2 = CurrencyHelper.NumberToWords(input2, NationalCurrency.USD).RemoveRedundantWhitespaces();
            var Test3 = CurrencyHelper.NumberToWords(input3, NationalCurrency.VND).RemoveRedundantWhitespaces();
            var Test4 = CurrencyHelper.NumberToWords(input4, NationalCurrency.VND).RemoveRedundantWhitespaces();
            var Test5 = CurrencyHelper.NumberToWords(input5, NationalCurrency.VND).RemoveRedundantWhitespaces();

            //Assert
            string Result1 = "năm trăm mười hai nghìn một trăm hai mươi mốt Đô la và mười lăm xu Mỹ";
            string Result2 = "hai nghìn một trăm Đô la Mỹ";
            string Result3 = "hai nghìn một trăm đồng";
            string Result4 = "năm trăm nghìn đồng";
            string Result5 = "năm trăm lẻ năm nghìn đồng";


            Assert.AreEqual(Result1, Test1);
            Assert.AreEqual(Result2, Test2);
            Assert.AreEqual(Result3, Test3);
            Assert.AreEqual(Result4, Test4);
            Assert.AreEqual(Result5, Test5);
        }
    }
}
