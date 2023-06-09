﻿using System;
using System.Globalization;

namespace MinhHelper
{
    public class CurrencyHelper
    {
        public static string NumberToWordsEN(decimal inputNumber, NationalCurrency nationalCurrency)
        {
            var number = SplitDecimalPoint(inputNumber);
            var currencyUnit = new CurrencyUnit(nationalCurrency);

            string firstPart = LongToString(number.Item1);
            string secondPart = LongToString(number.Item2);
            string result = "";

            if (String.IsNullOrEmpty(secondPart) || String.IsNullOrWhiteSpace(secondPart) || secondPart == "zero")
            {
                result = firstPart + currencyUnit.UnitEN;
            }
            else
            {
                result = firstPart + currencyUnit.UnitEN + " and " + secondPart + currencyUnit.SubsidiaryEN;
            }

            return result.RemoveRedundantWhitespaces();
        }

        public static string NumberToWordsVI(decimal inputNumber, NationalCurrency nationalCurrency)
        {
            var number = SplitDecimalPoint(inputNumber);
            var currencyUnit = new CurrencyUnit(nationalCurrency);

            string firstPart = ChuyenSo(number.Item1);
            string secondPart = ChuyenSo(number.Item2);
            string result = "";

            if (String.IsNullOrEmpty(secondPart) || String.IsNullOrWhiteSpace(secondPart) || secondPart == "không")
            {
                result = firstPart + currencyUnit.Unit + currencyUnit.Suffix;
            }
            else
            {
                result = firstPart + currencyUnit.Unit + " và " + secondPart + currencyUnit.Subsidiary + currencyUnit.Suffix;
            }
            
            return result.RemoveRedundantWhitespaces();
        }        

        private static Tuple<long, long> SplitDecimalPoint(decimal inputNumber)
        {
            string s = inputNumber.ToString("0.00", CultureInfo.InvariantCulture);
            string[] parts = s.Split('.');
            var beforeDecimal = long.Parse(parts[0]);
            var afterDecimal = long.Parse(parts[1]);
            var result = Tuple.Create(beforeDecimal, afterDecimal);
            return result;
        }
        
        private static string ChuyenSo(long inputNumber)
        {
            string number = inputNumber.ToString();
            string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string doc;
            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            doc = "";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) doc += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') doc += "lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) doc += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    doc += "mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc += "mốt ";
                                    else
                                        doc += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    doc += "lăm ";
                                else
                                    doc += cs[5] + " ";
                                break;
                            default:
                                doc += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }

                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc += dv[n - j - 1] + " ";
                        }
                    }
                }


                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc += "tỉ ";
                        rd = 0;
                    }
                    else
                        if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }

            if (len == 1)
                if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];

            return doc;
        }

        private static string LongToString(long inputNumber)
        {
            if (inputNumber == 0)
                return "zero";

            if (inputNumber < 0)
                return "minus " + LongToString(Math.Abs(inputNumber));

            string words = "";

            if ((inputNumber / 1000000) > 0)
            {
                words += LongToString(inputNumber / 1000000) + " million ";
                inputNumber %= 1000000;
            }

            if ((inputNumber / 1000) > 0)
            {
                words += LongToString(inputNumber / 1000) + " thousand ";
                inputNumber %= 1000;
            }

            if ((inputNumber / 100) > 0)
            {
                words += LongToString(inputNumber / 100) + " hundred ";
                inputNumber %= 100;
            }

            if (inputNumber > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (inputNumber < 20)
                    words += unitsMap[inputNumber];
                else
                {
                    words += tensMap[inputNumber / 10];
                    if ((inputNumber % 10) > 0)
                        words += "-" + unitsMap[inputNumber % 10];
                }
            }

            return words;
        }

    }
}
