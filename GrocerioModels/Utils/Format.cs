using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Utils
{
    public class Format
    {
        public static string CreditCardNumber(string fullCardNumber)
        {
            var censoredCardNumber = "";

            for (int i = 0; i < fullCardNumber.Length - 4; i++)
                censoredCardNumber += "*";

            censoredCardNumber += fullCardNumber.Substring(fullCardNumber.Length - 4);

            return censoredCardNumber;
        }
    }
}
