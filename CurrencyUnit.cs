using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MinhHelper
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
