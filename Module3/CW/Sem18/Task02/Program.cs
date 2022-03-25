using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Task02
{
    class Program
    {
        private const string connectionString = "Data Source=AdventureWorksLT.db";
        static void Main(string[] args)
        {
            string request1 = "UPDATE Product SET StandardCost = 50 WHERE ProductID = 680";
            ExecuteSQL_DataTable(connectionString, request1);
            string request2 = "UPDATE Product SET ListPrice = 78 WHERE ProductID = 680";
            ExecuteSQL_DataTable(connectionString, request2);
            string request3 = "DELETE FROM Product WHERE ProductId = 1";
            ExecuteSQL_DataTable(connectionString, request3);
            string request4 =  "INSERT INTO Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate, rowguid) VALUES (798231, 'NewProduct', '33789', 'Blue', 50, 25, '2022-03-21', '450000')";
            ExecuteSQL_DataTable(connectionString, request4);
            string request5 = "DELETE FROM Product WHERE ProductId = 706";
            ExecuteSQL_DataTable(connectionString, request5);
            string request6 = "SELECT * FROM Product WHERE ListPrice < 700 and ListPrice > 560";
            DataTable results6 = ExecuteSQL_DataTable(connectionString, request6);
            PrintTable(results6);
            Console.WriteLine("---");
            string request7 = "SELECT * FROM Product WHERE INSTR(Name, 'Product')";
            DataTable result7 = ExecuteSQL_DataTable(connectionString, request7);
            PrintTable(result7);
            Console.WriteLine("---");
            string request8 = "SELECT * FROM Product WHERE ProductId = 1";
            DataTable result8 = ExecuteSQL_DataTable(connectionString, request8);
            PrintTable(result8);
        }

        private static void PrintTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item};");
                }
                Console.WriteLine();
            }
        }

        private static DataTable ExecuteSQL_DataTable(string connectionString, string request, params Tuple<string, string>[] arguments)
        {
            DataTable dataTable = new DataTable();
            using var connection = new SqliteConnection(connectionString);
            using var command = new SqliteCommand(request, connection);
            command.CommandType = CommandType.Text;
            foreach (Tuple<string,string> argument in arguments)
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