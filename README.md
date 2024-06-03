# Excel-to-CSV-Convertor

Excel-to-CSV-Convertor is an Azure Function that triggers on Excel file upload to Azure Blob Storage, converts the file to CSV, and uploads it to another container. Ideal for data conversion and analysis.

## Setup

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Update the Azure Blob Storage connection strings in the local.settings.json file.
4. Run the solution.

## Architecture Diagram
![image](https://github.com/keyur9874/Excel-to-CSV-Convertor/assets/73292698/e8c815c0-993a-45aa-8f0f-8d2814b0b75f)

## Usage

Upload an Excel file to the specified input container in your Azure Blob Storage. The Azure Function will automatically trigger, convert the file to CSV, and upload the converted file to the output container.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
