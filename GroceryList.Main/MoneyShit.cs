using System;

namespace GroceryList.Main
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
    }
}