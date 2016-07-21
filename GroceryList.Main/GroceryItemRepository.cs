using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public class GroceryItemRepository
    {
        private static readonly string DISK_REPO_FILE_PATH = 
            Path.Combine(Path.GetDirectoryName(
                new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"\Assets\repo.txt");
        private readonly FileInfo _file;

        public List<GroceryRepoItem> Items { get; private set; }

        public GroceryItemRepository()
        {
            _file = new FileInfo(DISK_REPO_FILE_PATH);
            Items = DiskRepoHelpers.LoadRepositoryFromDisk(_file);
        }

        public GroceryItem GetItemFromString(string itemToFind)
        {
            foreach (var item in Items)
            {
                if (item.Name == itemToFind)
                {
                    return item;
                }
            }

            return null;
        }

        [System.Obsolete]
        private Enums.Stores ParseStoreName(string storeNameFromFile)
        {
            switch (storeNameFromFile)
            {
                case "Hannaford":
                    return Enums.Stores.Hannaford;
                case "Sam's":
                    return Enums.Stores.Sams;
                case "Shaw's":
                    return Enums.Stores.Shaws;
                default:
                    return Enums.Stores.Hannaford;
            }
        }
    }
}