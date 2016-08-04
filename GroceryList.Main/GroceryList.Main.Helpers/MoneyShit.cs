using System;

namespace GroceryList.Main.Helpers
{
    public static class MoneyShit
    {
        public static int ParseMoneysFromFile(string moneysFromFile)
        {
            if (moneysFromFile == "")
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(Math.Round(Convert.ToDouble(moneysFromFile), 2) * 100);
            }
        }

        public static decimal PenniesToDecimal(int penniesIn)
        {
            return Math.Round((decimal)penniesIn / 100, 2);
        }

        public static int DecimalToPennies(decimal decimalIn)
        {
            return Convert.ToInt32(decimalIn * 100);
        }
    }
}