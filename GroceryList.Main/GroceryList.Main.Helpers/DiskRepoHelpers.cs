﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GroceryList.Main.Helpers
{
    public static class DiskRepoHelpers
    {
        private const int DISK_REPO_NAME_COL_INDEX = 0;
        private const int DISK_REPO_CATEGORY_COL_INDEX = 1;
        private const int DISK_REPO_HANNAFORD_COL_INDEX = 2;
        private const int DISK_REPO_SHAWS_COL_INDEX = 3;
        private const int DISK_REPO_SAMS_COL_INDEX = 4;

        private static readonly string DISK_REPO_VALID_HEADER_ROW = 
            "ITEM\tCATEGORY\tHANNAFORD_PRICE\tSHAWS_PRICE\tSAMS_PRICE";

        public static Dictionary<int, Enums.Stores> DiskRepoStoreColIndexLookup =
            new Dictionary<int, Enums.Stores>()
            {
                { 2, Enums.Stores.Hannaford },
                { 3, Enums.Stores.Shaws },
                { 4, Enums.Stores.Sams }
            };

        public static List<GroceryRepoItem> LoadRepositoryFromDisk(FileInfo path)
        {
            List<GroceryRepoItem> repoFromDisk = new List<GroceryRepoItem>();

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

                            if (RowHasPrices(currentLine))
                            {
                                repoFromDisk.Add(
                                    new GroceryRepoItem(currentLine[0], ExtractPricesFromRow(currentLine))); 
                            }
                            else
                            {
                                repoFromDisk.Add(new GroceryRepoItem(currentLine[0]));
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

        public static void WriteRepositoryToDisk()
        {
            // Gotta do this...
            throw new NotImplementedException();
        }

        private static bool RowHasPrices(string[] currentLine)
        {
            if (currentLine[DISK_REPO_HANNAFORD_COL_INDEX] != "" ||
                currentLine[DISK_REPO_SHAWS_COL_INDEX] != "" ||
                currentLine[DISK_REPO_SAMS_COL_INDEX] != "")
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

            for (int i = DISK_REPO_HANNAFORD_COL_INDEX; i < DISK_REPO_SAMS_COL_INDEX; i++)
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
    }
}