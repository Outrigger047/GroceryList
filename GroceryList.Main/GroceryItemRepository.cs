using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public class GroceryItemRepository
    {
        private static readonly string DISK_REPO_FILE_PATH_DIR = 
            Path.Combine(Path.GetDirectoryName(
                new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"Assets");

        private FileInfo _file;

        public List<GroceryItem> Items { get; private set; }

        public GroceryItemRepository()
        {
            _file = new FileInfo(DiskRepoHelpers.GetMostRecentRepo(DISK_REPO_FILE_PATH_DIR).ToString());
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

        public void WriteRepoToDisk(object sender, EventArgs e)
        {
            FileInfo updatedFileName = new FileInfo(BuildRepoWriteFileName());
            DiskRepoHelpers.WriteRepositoryToDisk(Items, updatedFileName);
            _file = updatedFileName;
        }

        private string BuildRepoWriteFileName()
        {
            return Path.Combine(DISK_REPO_FILE_PATH_DIR, DateTime.Now.ToString("yyyyMMddHHmmss") + @"-repo.txt");
            //return DISK_REPO_FILE_PATH_DIR + DateTime.Now.ToString("yyyyMMddHHmmss") + @"-repo.txt";
        }
    }
}