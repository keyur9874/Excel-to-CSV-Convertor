using System.Data;
using System.Text;

namespace ConvertorApp.Helper
{
    internal static class ConvertorHelper
    {
        internal static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        internal static string ConvertToCsv(DataSet dataSet)
        {
            var csvBuilder = new StringBuilder();

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    var columnValues = new string[row.ItemArray.Length];
                    for (var i = 0; i < row.ItemArray.Length; i++)
                    {
                        columnValues[i] = row[i].ToString();
                    }
                    csvBuilder.AppendLine(string.Join(",", columnValues));
                }
            }

            return csvBuilder.ToString();
        }
    }
}
