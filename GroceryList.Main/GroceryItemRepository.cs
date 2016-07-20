using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GroceryList.Main
{
    public class GroceryItemRepository
    {
        private readonly string FILE_PATH = 
            Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), 
                "repo.txt");

        private readonly FileInfo _file;

        public List<GroceryRepoItem> Items { get; private set; }

        public GroceryItemRepository()
        {
            _file = new FileInfo(FILE_PATH);
            Items = new List<GroceryRepoItem>();

            LoadRepositoryFromDisk();
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

        private void LoadRepositoryFromDisk()
        {
            bool theOldCollegeTry = true;
            while (theOldCollegeTry)
            {
                try
                {
                    StreamReader reader = new StreamReader(_file.FullName);

                    while (!reader.EndOfStream)
                    {
                        string[] currentLine = reader.ReadLine().Split('\t');

                        Items.Add(new GroceryRepoItem(currentLine[0],
                            MoneyShit.ParseMoneysFromFile(currentLine[1]),
                            ParseStoreName(currentLine[2])));
                    }

                    theOldCollegeTry = false;
                }
                catch (FileNotFoundException)
                {
                    FileStream fs = File.Create(_file.FullName);
                    fs.Close();
                    // Give it the old college try!
                } 
            }
        }

        private void WriteRepositoryToDisk()
        {
            // Gotta do this...
            throw new NotImplementedException();
        }

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