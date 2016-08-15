using System;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    [Serializable]
    public class StorePrice
    {
        public Enums.Stores Store { get; private set; }
        public int Price { get; private set; }

        public StorePrice(Enums.Stores storeIn, int priceIn)
        {
            Store = storeIn;
            Price = priceIn;
        }

        public void UpdatePrice(int priceIn)
        {
            Price = priceIn;
        }
    }
}