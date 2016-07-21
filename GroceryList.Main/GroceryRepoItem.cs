using System.Collections.Generic;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public class GroceryRepoItem : GroceryItem
    {
        public bool IsOnList { get; private set; }

        public GroceryRepoItem(string nameIn) : base(nameIn)
        {
        }

        public GroceryRepoItem(string nameIn, List<StorePrice> pricesIn) : base(nameIn, pricesIn)
        {
        }

        public void SetIsOnListFlag(bool statusIn)
        {
            IsOnList = statusIn;
        }
    }
}