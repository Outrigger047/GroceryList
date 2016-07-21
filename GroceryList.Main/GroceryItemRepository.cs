using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public class GroceryItemRepository
    {
        private const int DISK_REPO_HANNAFORD_COL_INDEX = 2;
        private const int DISK_REPO_SHAWS_COL_INDEX = 3;
        private const int DISK_REPO_SAMS_COL_INDEX = 4;
        private readonly string DISK_REPO_FILE_PATH = 
            Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), 
                @"\Assets\repo.txt");
        private readonly string DISK_REPO_VALID_HEADER_ROW = "ITEM\tCATEGORY\tHANNAFORD_PRICE\tSHAWS_PRICE\tSAMS_PRICE";

        private readonly FileInfo _file;

        public List<GroceryRepoItem> Items { get; private set; }

        public GroceryItemRepository()
        {
            _file = new FileInfo(DISK_REPO_FILE_PATH);
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

        [System.Obsolete("Use LoadRepositoryFromDiskNew()")]
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

                        if (currentLine[1] == "" && currentLine[2] == "")
                        {
                            Items.Add(new GroceryRepoItem(currentLine[0]));
                        }
                        else
                        {
                            Items.Add(new GroceryRepoItem(currentLine[0],
                                MoneyShit.ParseMoneysFromFile(currentLine[1]),
                                ParseStoreName(currentLine[2])));
                        }
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

        private void LoadRepositoryFromDiskNew()
        {
            bool tryAgain;

            do
            {
                tryAgain = false;

                try
                {
                    StreamReader sr = new StreamReader(_file.FullName);

                    while (!sr.EndOfStream)
                    {
                        string[] currentLine = sr.ReadLine().Split('\t');

                        if (currentLine.ToString() == DISK_REPO_VALID_HEADER_ROW)
                        {

                        }
                        else
                        {
                            throw new Exception("Header row invalid");
                        }

                        //if (currentLine[1] == "" && currentLine[2] == "")
                        //{
                        //    Items.Add(new GroceryRepoItem(currentLine[0]));
                        //}
                        //else
                        //{
                        //    Items.Add(new GroceryRepoItem(currentLine[0],
                        //        MoneyShit.ParseMoneysFromFile(currentLine[1]),
                        //        ParseStoreName(currentLine[2])));
                        //}
                    }
                }
                catch (FileNotFoundException)
                {
                    tryAgain = true;

                    FileStream fs = File.Create(_file.FullName);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(DISK_REPO_VALID_HEADER_ROW);
                    sw.Close();
                    fs.Close();
                }
            } while (tryAgain);
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