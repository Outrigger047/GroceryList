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
                new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"Assets");
        private readonly FileInfo _file;

        public List<GroceryItem> Items { get; private set; }

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

        public void EditItemInRepository(GroceryItem itemToEdit)
        {
            GroceryItem targetItem = Items.Find(x => x.Name == itemToEdit.Name);

            targetItem.ChangeName(itemToEdit.Name);
            foreach (var p in itemToEdit.Prices)
            {
                targetItem.AddNewPrice(p.Store, p.Price);
            }
        }
    }
}