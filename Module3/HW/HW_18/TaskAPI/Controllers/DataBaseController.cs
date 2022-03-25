using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("DataBase")]
    public class DataBaseController : ControllerBase
    {
        private const string ConnectionString = "Data Source=AdventureWorksLT.db";

        [HttpGet("db")]
        public IActionResult GetAllProductsInfo()
        {
            string request = "SELECT * FROM Product";
            DataTable dataTable = ExecuteSQL_DataTable(ConnectionString, request);

            string json = JsonConvert.SerializeObject(dataTable);
            return json.Length <= 0 ? BadRequest("Нет продуктов") : Ok(json);
        }

        [HttpGet("db/{productId}")]
        public IActionResult GetProductInfoById(int productId)
        {
            string request = $"SELECT * FROM Product WHERE ProductId = {productId}";
            DataTable dataTable = ExecuteSQL_DataTable(ConnectionString, request);
            string json = JsonConvert.SerializeObject(dataTable);
            return json.Length <= 0 ? BadRequest("Нет таких продуктов") : Ok(json);
        }

        [HttpPut("db/update")]
        public IActionResult UpdateProductInfo([Required] int id, [Required] string name, [Required] string number, [Required] string color, [Required] int cost, [Required] int price)
        {
            string request = $"UPDATE Product SET Name = '{name}', ProductNumber = '{number}', Color = '{color}', " +
                            $"StandardCost = {cost}, ListPrice = {price} WHERE ProductID = {id}";
            ExecuteSQL_DataTable(ConnectionString, request);
            return Ok("Данные обновлены");
        }

        [HttpPost("add")]
        public IActionResult InsertProductInfo([Required] string name, [Required] string number, [Required] string color, [Required] int cost, [Required] int price)
        {
            int generatedId = GenerateProductId();
            string generatedGuid = GenerateGuidNumber();
            bool isOperationSuccessful = true;
            try
            {
                 string request = "INSERT INTO Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate, rowguid) " +
                    $"VALUES ({generatedId}, '{name}', '{number}', '{color}', {cost}, {price}, {DateTime.Now}, '{generatedGuid}')";
                ExecuteSQL_DataTable(ConnectionString, request);
            }
            catch
            {
                isOperationSuccessful = false;
            }
            return isOperationSuccessful? Ok("Продукт добавлен") : BadRequest("Невозможно добавить продукт");
        }

        [HttpDelete("delete/{productId}")]
        public IActionResult DeleteProductInfo(int productId)
        {
            string SQL = $"DELETE FROM Product WHERE ProductID = {productId}";
            try
            {
                ExecuteSQL_DataTable(ConnectionString, SQL);
                return Ok("Продукт удален");
            }
            catch
            {
                return BadRequest("Продукт не был удален");
            }
        }

        private static int GenerateProductId()
        {
            Random randomizer = new Random();
            return randomizer.Next(1000);
        }

        private static string GenerateGuidNumber()
        {
            Random randomizer = new Random();
            StringBuilder generatedGuid = new StringBuilder();
            for (var i = 0; i < 5; i++)
            {
                generatedGuid.Append(randomizer.Next(65, 91));
            }
            return generatedGuid.ToString();
        }

        private static DataTable ExecuteSQL_DataTable(string connectionString, string request, params Tuple<string, string>[] arguments)
        {
            DataTable dataTable = new DataTable();
            using var connection = new SqliteConnection(connectionString);
            using var command = new SqliteCommand(request, connection);
            command.CommandType = CommandType.Text;
            foreach (Tuple<string, string> argument in arguments)
            {
                command.Parameters.Add(new SqliteParameter(argument.Item1, argument.Item2));
            }
            connection.Open();
            SqliteDataReader reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dataTable.Columns.Add(new DataColumn(reader.GetName(i)));
            }
            int rowIndex = 0;
            while (reader.Read())
            {
                DataRow row = dataTable.NewRow();
                dataTable.Rows.Add(row);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataTable.Rows[rowIndex][i] = (reader.GetValue(i));
                }
                rowIndex++;
            }
            return dataTable;
        }
    }
}