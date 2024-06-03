using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using ConvertorApp.Helper;
using ExcelDataReader;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ConvertorApp
{
    public class ExcelToCSV
    {
        private readonly ILogger<ExcelToCSV> _logger;

        public ExcelToCSV(ILogger<ExcelToCSV> logger)
        {
            _logger = logger;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        }

        [Function(nameof(ExcelToCSV))]
        [BlobOutput("csv-container/{name}.csv", Connection = "ExeclCSVFileStorage")]
        public async Task<string> Run(
            [BlobTrigger("excel-container/{name}.{type}", Connection = "ExeclCSVFileStorage")] byte[] inputBlob,
            string name,
            string type,
            FunctionContext context)
        {
            var logger = context.GetLogger("ExcelToCsvFunction");
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}");
            using var memoryStream = new MemoryStream(inputBlob);
            using var reader = ExcelReaderFactory.CreateReader(memoryStream);
            var result = reader.AsDataSet();

            var csvContent = new StringBuilder();
            foreach (System.Data.DataTable table in result.Tables)
            {
                foreach (System.Data.DataRow row in table.Rows)
                {
                    for (var i = 0; i < table.Columns.Count; i++)
                    {
                        csvContent.Append(row[i]);
                        if (i < table.Columns.Count - 1)
                            csvContent.Append(",");
                    }
                    csvContent.AppendLine();
                }
            }

            return csvContent.ToString();
        }
    }
}
