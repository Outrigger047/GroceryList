using System;
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

        private static List<StorePrice> ExtractPricesFromRow(string[] currentLine)
        {
            List<StorePrice> pricesFromRow = new List<StorePrice>();

            return pricesFromRow;
        }
    }
}