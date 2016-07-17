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

        public List<GroceryItem> Items { get; private set; }

        public GroceryItemRepository()
        {
            _file = new FileInfo(FILE_PATH);
            LoadRepository();
        }

        private bool LoadRepository()
        {
            using (StreamReader reader = File.OpenText(_file.FullName))
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        string[] currentLine = reader.ReadLine().Split('\t');

                        Items.Add(new GroceryItem(currentLine[0],
                            MoneyShit.ParseMoneysFromFile(currentLine[1]),
                            ParseStoreName(currentLine[2])));
                    }

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw;
                }
            }
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