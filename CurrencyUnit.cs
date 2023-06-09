﻿namespace MinhHelper
{
    internal class CurrencyUnit
    {

        NationalCurrency nationalCurrency;
        public CurrencyUnit(NationalCurrency nationalCurrency)
        {
            this.nationalCurrency = nationalCurrency;
        }
        public string Unit
        {
            get
            {
                switch (nationalCurrency)
                {
                    case NationalCurrency.USD:
                        return " Đô la ";

                    default:
                        return " đồng ";
                }
            }
        }

        public string UnitEN
        {
            get
            {
                switch (nationalCurrency)
                {
                    case NationalCurrency.USD:
                        return " Dollars ";

                    default:
                        return " Vietnamese dongs ";
                }
            }
        }

        public string SubsidiaryEN
        {
            get
            {
                switch (nationalCurrency)
                {
                    case NationalCurrency.USD:
                        return " cent ";

                    default:
                        return " ";
                }
            }
        }

        public string Subsidiary
        {
            get
            {
                switch (nationalCurrency)
                {
                    case NationalCurrency.USD:
                        return " xu ";

                    default:
                        return " hào ";
                }
            }
        }

        public string Suffix
        {
            get
            {
                switch (nationalCurrency)
                {
                    case NationalCurrency.USD:
                        return " Mỹ";

                    default:
                        return "";
                }
            }
        }
    }
}
