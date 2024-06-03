using System.IO;
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
        }

        [Function(nameof(ExcelToCSV))]
        public async Task Run(
            [BlobTrigger("excel-container/{name}", Connection = "ExeclCSVFileStorage")] byte[] inputBlob,
            string name,
            FunctionContext context)
        {
            var logger = context.GetLogger("ExcelToCsvFunction");
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}");
        }
    }
}
