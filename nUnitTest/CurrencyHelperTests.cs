using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinhHelper;
using System;

namespace nUnitTest
{
    [TestClass]
    public class CurrencyHelperTests
    {
        [TestMethod]
        public void NumberToWordsVI_Test()
        {
            //Assign
            decimal input1 = 512121.15M;
            decimal input2 = 2100;
            decimal input3 = 2100;
            long input4 = 500000;
            long input5 = 505000;


            //Act
            var Test1 = CurrencyHelper.NumberToWordsVI(input1, NationalCurrency.USD);
            var Test2 = CurrencyHelper.NumberToWordsVI(input2, NationalCurrency.USD);
            var Test3 = CurrencyHelper.NumberToWordsVI(input3, NationalCurrency.VND);
            var Test4 = CurrencyHelper.NumberToWordsVI(input4, NationalCurrency.VND);
            var Test5 = CurrencyHelper.NumberToWordsVI(input5, NationalCurrency.VND);

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

        [TestMethod]
        public void NumberToWordsEN_Test()
        {
            //Assign
            decimal input1 = 512121.15M;
            decimal input2 = 2100;
            decimal input3 = 2100;
            long input4 = 5213455;
            decimal input5 = 5254.25M;


            //Act
            var Test1 = CurrencyHelper.NumberToWordsEN(input1, NationalCurrency.USD);
            var Test2 = CurrencyHelper.NumberToWordsEN(input2, NationalCurrency.USD);
            var Test3 = CurrencyHelper.NumberToWordsEN(input3, NationalCurrency.VND);
            var Test4 = CurrencyHelper.NumberToWordsEN(input4, NationalCurrency.VND);
            var Test5 = CurrencyHelper.NumberToWordsEN(input5, NationalCurrency.USD);

            //Assert
            string Result1 = "five hundred and twelve thousand one hundred and twenty-one Dollars and fifteen cent";
            string Result2 = "two thousand one hundred Dollars";
            string Result3 = "two thousand one hundred Vietnamese dongs";
            string Result4 = "five million two hundred and thirteen thousand four hundred and fifty-five Vietnamese dongs";
            string Result5 = "five thousand two hundred and fifty-four Dollars and twenty-five cent";


            Assert.AreEqual(Result1, Test1);
            Assert.AreEqual(Result2, Test2);
            Assert.AreEqual(Result3, Test3);
            Assert.AreEqual(Result4, Test4);
            Assert.AreEqual(Result5, Test5);
        }
    }
}
