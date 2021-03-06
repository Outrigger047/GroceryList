﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace GroceryList.Main.Helpers
{
    public static class DiskRepoHelpers
    {
        private const int DISK_REPO_NAME_COL_INDEX = 0;
        private const int DISK_REPO_CATEGORY_COL_INDEX = 1;
        private const int DISK_REPO_HANNAFORD_COL_INDEX = 2;
        private const int DISK_REPO_SHAWS_COL_INDEX = 3;
        private const int DISK_REPO_SAMS_COL_INDEX = 4;
        private const int DISK_REPO_TJS_COL_INDEX = 5;

        private static readonly string DISK_REPO_VALID_HEADER_ROW = 
            "ITEM\tCATEGORY\tHANNAFORD_PRICE\tSHAWS_PRICE\tSAMS_PRICE\tTJS_PRICE";

        public static Dictionary<int, Enums.Stores> DiskRepoStoreColIndexLookup =
            new Dictionary<int, Enums.Stores>()
            {
                { 2, Enums.Stores.Hannaford },
                { 3, Enums.Stores.Shaws },
                { 4, Enums.Stores.Sams },
                { 5, Enums.Stores.TraderJoes }
            };

        public static FileInfo GetMostRecentRepo(string repoFilesPath)
        {
            IEnumerable<string> filesTemp = Directory.EnumerateFiles(repoFilesPath);
            List<string> files = new List<string>();

            foreach (var file in filesTemp)
            {
                if (Regex.IsMatch(file, @"[0-9]{14}\-repo\.txt"))
                {
                    files.Add(file);
                }
            }

            if (files.Count > 0)
            {
                files.Sort();
                return new FileInfo(files.Last()); 
            }
            else
            {
                return null;
            }
        }

        public static List<GroceryItem> LoadRepositoryFromDisk(FileInfo path)
        {
            List<GroceryItem> repoFromDisk = new List<GroceryItem>();

            bool tryAgain;

            do
            {
                tryAgain = false;

                try
                {
                    StreamReader sr = new StreamReader(path.FullName);

                    if (sr.ReadLine().ToString() == DISK_REPO_VALID_HEADER_ROW)
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] currentLine = sr.ReadLine().Split('\t');

                            if (repoFromDisk.FindIndex(x => x.Name == currentLine[0]) > -1)
                            {
                                throw new Exception("Duplicate item found", 
                                    new Exception(currentLine[0]));
                            }

                            if (RowHasPrices(currentLine))
                            {
                                repoFromDisk.Add(
                                    new GroceryItem(currentLine[0], ExtractPricesFromRow(currentLine))); 
                            }
                            else
                            {
                                repoFromDisk.Add(new GroceryItem(currentLine[0]));
                            }
                        }

                        sr.Close();
                        return repoFromDisk;
                    }
                    else
                    {
                        throw new Exception("Header row invalid");
                    }
                }
                catch (FileNotFoundException)
                {
                    tryAgain = true;

                    FileStream fs = File.Create(path.FullName);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(DISK_REPO_VALID_HEADER_ROW);
                    sw.Close();
                    fs.Close();
                }
            } while (tryAgain);

            return null;
        }

        public static void WriteRepositoryToDisk(List<GroceryItem> repoToWrite, FileInfo path)
        {
            using (StreamWriter sw = new StreamWriter(path.FullName))
            {
                sw.WriteLine(DISK_REPO_VALID_HEADER_ROW);

                foreach (var item in repoToWrite)
                {
                    sw.Write(item.Name + "\t");
                    sw.Write("\t"); // Category write should be added here once property is added to GroceryItem class

                    var hannafordPrice = item.Prices.Find(x => x.Store == Enums.Stores.Hannaford)?.Price;
                    if (hannafordPrice != null)
                    {
                        sw.Write(MoneyShit.PenniesToDecimal((int)hannafordPrice).ToString() + "\t");
                    }
                    else
                    {
                        sw.Write("\t");
                    }

                    var shawsPrice = item.Prices.Find(x => x.Store == Enums.Stores.Shaws)?.Price;
                    if (shawsPrice != null)
                    {
                        sw.Write(MoneyShit.PenniesToDecimal((int)shawsPrice).ToString() + "\t");
                    }
                    else
                    {
                        sw.Write("\t");
                    }

                    var samsPrice = item.Prices.Find(x => x.Store == Enums.Stores.Sams)?.Price;
                    if (samsPrice != null)
                    {
                        sw.Write(MoneyShit.PenniesToDecimal((int)samsPrice).ToString() + "\t");
                    }
                    else
                    {
                        sw.Write("\t");
                    }

                    var tjsPrice = item.Prices.Find(x => x.Store == Enums.Stores.TraderJoes)?.Price;
                    if (tjsPrice != null)
                    {
                        sw.Write(MoneyShit.PenniesToDecimal((int)tjsPrice).ToString());
                    }

                    sw.WriteLine();
                }
            }
        }

        public static void WriteListToDisk(FileInfo pathToWrite, 
            Dictionary<GroceryItem, int> listToWrite, 
            List<GroceryItem> repoToWrite)
        {
            DiskData data = new DiskData(repoToWrite, listToWrite);
            Stream fs = File.Create(pathToWrite.FullName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fs, data);
            fs.Close();
        }

        public static void ReadListFromDisk(FileInfo pathToRead, 
            Dictionary<GroceryItem, int> listToLoadInto,
            List<GroceryItem> repoToLoadInto)
        {
            DiskData data = new DiskData();
            Stream fs = File.OpenRead(pathToRead.FullName);
            BinaryFormatter deserializer = new BinaryFormatter();
            data = (DiskData)deserializer.Deserialize(fs);
            fs.Close();

            foreach (var item in data.List)
            {
                listToLoadInto.Add(item.Key, item.Value);
            }

            foreach (var item in data.Repo)
            {
                repoToLoadInto.Add(item);
            }
        }

        private static bool RowHasPrices(string[] currentLine)
        {
            if (currentLine[DISK_REPO_HANNAFORD_COL_INDEX] != "" ||
                currentLine[DISK_REPO_SHAWS_COL_INDEX] != "" ||
                currentLine[DISK_REPO_SAMS_COL_INDEX] != "" ||
                currentLine[DISK_REPO_TJS_COL_INDEX] != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static List<StorePrice> ExtractPricesFromRow(string[] currentLine)
        {
            List<StorePrice> pricesFromRow = new List<StorePrice>();

            for (int i = DISK_REPO_HANNAFORD_COL_INDEX; i <= DISK_REPO_TJS_COL_INDEX; i++)
            {
                if (currentLine[i] != "")
                {
                    Enums.Stores currentLineStore;
                    DiskRepoStoreColIndexLookup.TryGetValue(i, out currentLineStore);
                    pricesFromRow.Add(new StorePrice(currentLineStore, MoneyShit.ParseMoneysFromFile(currentLine[i])));
                }
            }

            return pricesFromRow;
        }

        [Serializable]
        private class DiskData
        {
            public List<GroceryItem> Repo { get; set; }
            public Dictionary<GroceryItem, int> List { get; set; }

            public DiskData()
            {

            }

            public DiskData(List<GroceryItem> repo, Dictionary<GroceryItem, int> list)
            {
                Repo = repo;
                List = list;
            }
        }
    }
}