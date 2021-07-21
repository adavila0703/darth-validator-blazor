using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarthValidatorBlazor.Utils
{
    public class Validator
    {
        public static void SaveUnmatching()
        {
            //TODO: add csv export
        }


        public static string[] Validation(List<string> listOne, List<string> listTwo)
        {
            int rowCount = listTwo.Count;
            int columnCount = listOne.ElementAt(0).Split(",").Length;
            float numOfMatching = new int();

            for (int i = 0; i < rowCount; i++)
            {
                if (listOne.Contains(listTwo.ElementAt(i)))
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
    }
}
