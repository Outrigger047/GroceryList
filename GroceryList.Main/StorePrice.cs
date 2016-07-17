using System;

namespace GroceryList.Main
{
    public class StorePrice
    {
        public Enums.Stores Store { get; private set; }
        public int Price { get; private set; }

        public StorePrice(Enums.Stores storeIn, int priceIn)
        {
            Store = storeIn;
            Price = priceIn;
        }
    }
}