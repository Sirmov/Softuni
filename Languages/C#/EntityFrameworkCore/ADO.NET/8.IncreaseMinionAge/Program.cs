using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace _8.IncreaseMinionAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Server=localhost;
                                            Database=MinionsDB;
                                            User Id=username;
                                            Password=password;
                                            Encrypt=false";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            int[] minionIds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (int minionId in minionIds)
            {
                UpdateMinionsAge(minionId, sqlConnection);
            }

            Console.WriteLine(GetMinions(sqlConnection));

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private static void UpdateMinionsAge(int minionId, SqlConnection sqlConnection)
        {
            string query = @"UPDATE [Minions] SET
                                [Name] = UPPER(LEFT([Name], 1)) + SUBSTRING([Name], 2, LEN([Name]))
                                ,[Age] += 1
                            WHERE [Id] = @MinionId";
            // string query = "UPDATE [Minions] SET [Name] = UPPER(LEFT([Name], 1)) + SUBSTRING([Name], 2, LEN([Name])), [Age] += 1 WHERE [Id] IN ({string.Join(", ", minionIds)})"
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("MinionId", minionId);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
        }

        private static string GetMinions(SqlConnection sqlConnection)
        {
            string query = @"SELECT [Name], [Age] FROM [Minions]";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            StringBuilder output = new StringBuilder();
            while (sqlDataReader.Read())
            {
                output.AppendLine($"{sqlDataReader["Name"]} {sqlDataReader["Age"]}");
            }

            sqlCommand.Dispose();
            sqlDataReader.Close();
            sqlDataReader.Dispose();
            return output.ToString().TrimEnd();
        }
    }
}
