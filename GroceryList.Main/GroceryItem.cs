using System.Collections.Generic;
using System.Linq;

namespace GroceryList.Main
{
    public class GroceryItem
    {
        public string Name { get; private set; }
        public List<StorePrice> Prices { get; private set; }

        public GroceryItem(string nameIn)
        {
            Name = nameIn;
            Prices = new List<StorePrice>();
        }

        public GroceryItem(string nameIn, int priceIn, Enums.Stores storeIn)
        {
            Name = nameIn;
            Prices = new List<StorePrice>();
            Prices.Add(new StorePrice(storeIn, priceIn));
        }

        public void AddNewPrice(Enums.Stores storeIn, int priceIn)
        {
            StorePrice priceToAdd = new StorePrice(storeIn, priceIn);
            if (IsNewPriceUnique(priceToAdd))
            {
                Prices.Add(new StorePrice(storeIn, priceIn)); 
            }
        }

        public string ListBoxRowText
        {
            get
            {
                System.Text.StringBuilder runningPrices = new System.Text.StringBuilder();

                if (Prices.Any())
                {
                    foreach (var p in Prices)
                    {
                        runningPrices.Append("   ");
                        runningPrices.Append(p.Store);
                        runningPrices.Append(": $");
                        runningPrices.Append((decimal)p.Price / 100);
                    } 
                }

                return Name + runningPrices.ToString();
            }
        }

        private bool IsNewPriceUnique(StorePrice newStorePrice)
        {
            if (Prices.Exists(x => x.Store == newStorePrice.Store))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}