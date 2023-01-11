using Microsoft.Data.SqlClient;
using System;

namespace _9.IncreaseAgeStoredProcedure
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

            int minionId = int.Parse(Console.ReadLine());
            IncreaseMinionAge(minionId, sqlConnection);
            Console.WriteLine(GetMinion(minionId, sqlConnection));

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private static string GetMinion(int minionId, SqlConnection sqlConnection)
        {
            string query = @"SELECT [Name], [Age] FROM [Minions] WHERE [Id] = @MinionId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("MinionId", minionId);
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string minion = string.Empty;

            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                minion = $"{sqlDataReader["Name"]} – {sqlDataReader["Age"]} years old";
            }

            sqlCommand.Dispose();
            sqlDataReader.Close();
            sqlDataReader.Dispose();
            return minion;
        }

        private static void IncreaseMinionAge(int minionId, SqlConnection sqlConnection)
        {
            string query = @"EXEC [USP_GetOlder] @MinionId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("MinionId", minionId);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
        }
    }
}
