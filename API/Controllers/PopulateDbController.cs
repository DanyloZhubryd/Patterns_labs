using System.Data;
using Instagram.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace Instagram.Controllers;

[ApiController]
[Route("[controller]")]
public class PopulateDbController : ControllerBase
{
    private readonly IPopulateDbService _populateService;

    public PopulateDbController(IPopulateDbService populateService)
    {
        _populateService = populateService;
    }

    [HttpPost]
    public async Task<IActionResult> PopulateDatabase()
    {
        var dataTable = GetDataTableFromCSVFile("user.csv");
        await _populateService.PopulateUser(dataTable);

        dataTable = GetDataTableFromCSVFile("story.csv");
        await _populateService.PopulateStory(dataTable);

        dataTable = GetDataTableFromCSVFile("comment.csv");
        await _populateService.PopulateComment(dataTable);

        dataTable = GetDataTableFromCSVFile("reaction.csv");
        await _populateService.PopulateReaction(dataTable);

        return NoContent();
    }
    private static DataTable GetDataTableFromCSVFile(string fileName)
    {
        DataTable csvData = new DataTable();
        string csvFilePath = GetFilePath(fileName);
        try
        {
            using (TextFieldParser csvReader = new TextFieldParser(csvFilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] colFields = csvReader.ReadFields();
                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    csvData.Columns.Add(datecolumn);
                }
                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
        }
        catch (Exception ex)
        {
            return null;
        }
        return csvData;
    }

    // private static void InsertDataIntoSQLServer(DataTable csvFileData, string tableName)
    // {
    //     using (SqlConnection dbConnection = new SqlConnection())
    //     {
    //         dbConnection.ConnectionString = "data source=DESKTOP-JU5F5N7;" +
    //             "initial catalog=lab2;" +
    //             "Integrated Security=SSPI;" +
    //             "Encrypt=false";
    //         dbConnection.Open();
    //         using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
    //         {
    //             s.DestinationTableName = tableName;
    //             foreach (var column in csvFileData.Columns)
    //                 s.ColumnMappings.Add(column.ToString(), column.ToString());
    //             s.WriteToServer(csvFileData);
    //         }
    //     }
    // }

    private static string GetFilePath(string fileName)
    {
        string fileDirectory = "D:\\Documentation_labs\\Lab2\\Infrastructure\\Resources\\Generated";
        string file = System.IO.Path.Combine(fileDirectory, fileName);

        return file;
    }
}