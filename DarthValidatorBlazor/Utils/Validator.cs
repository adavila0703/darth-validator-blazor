using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DarthValidatorBlazor.Utils
{
    public class Validator
    {
        public static void SaveUnmatching()
        {
            //TODO: add csv export
        }

        public static HashSet<string> AddToHashSet(IEnumerable<string> file)
        {
            var hashSet = new HashSet<string>();
            foreach (var row in file)
            {
                hashSet.Add(row);
            }
            return hashSet;
        }

        public static string[] SearchSets(HashSet<string> setOne, HashSet<string> setTwo)
        {
            int rowCount = setOne.Count > setTwo.Count ? setOne.Count : setTwo.Count;
            int columnCount = setOne.ElementAt(0).Split(",").Length;
            float numOfMatching = new int();

            for (int i = 0; i < rowCount; i++)
            {
                if (setOne.Contains(setTwo.ElementAt(i)))
                {
                    numOfMatching++;
                }
            }
            return new string[] { $"{rowCount}", $"{columnCount}", $"{Math.Round((numOfMatching / rowCount) * 100, 3)}", $"{Math.Round(((rowCount - numOfMatching) / rowCount) * 100, 3)}" };
        }
        public static string ReportRows(string reportName, string[] reportOne, string[] reportTwo)
        {
            var columnNames = new string[] { "RowCount", "ColumnCount", "Matching", "Unmatching" };
            var reportRows = "";
            reportRows += $"\n{reportName}\n";
            for (int i = 0; i < columnNames.Length; i++)
            {
                reportRows += $"{columnNames[i]}: {reportOne[i]} ";
            }
            return reportRows;
        }
        public static string CreateReport(string[] reportOne, string[] reportTwo)
        {
            return $"{ReportRows("Report1", reportOne, reportTwo)} {ReportRows("Report2", reportOne, reportTwo)}";
        }

        // TODO: Set up main entry function to start the validator here

        static void ToCall()
        {
            var workBookOne = File.ReadLines("../../../../example1.csv", Encoding.GetEncoding(codepage: 65001));
            var workBookTwo = File.ReadLines("../../../../example2.csv", Encoding.GetEncoding(codepage: 65001));

            var hashSetOne = AddToHashSet(workBookOne);
            var hashSetTwo = AddToHashSet(workBookTwo);
            Console.WriteLine(CreateReport(SearchSets(hashSetOne, hashSetTwo), SearchSets(hashSetTwo, hashSetOne)));
        }
    }
}
