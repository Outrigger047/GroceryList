using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public class GroceryRepoItem : GroceryItem
    {
        public bool IsOnList { get; private set; }

        public GroceryRepoItem(string nameIn) : base(nameIn)
        {
        }

        public GroceryRepoItem(string nameIn, int priceIn, Enums.Stores storeIn) : base(nameIn, priceIn, storeIn)
        {
        }

        public void SetIsOnListFlag(bool statusIn)
        {
            IsOnList = statusIn;
        }
    }
}