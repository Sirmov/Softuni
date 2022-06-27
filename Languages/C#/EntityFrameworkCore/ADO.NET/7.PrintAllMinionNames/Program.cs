using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _7.PrintAllMinionNames
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

            string[] minionNames = GetMinionNames(sqlConnection);
            int counter = 0;

            for (int i = 0; i < minionNames.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(minionNames[counter]);
                }
                else
                {
                    Console.WriteLine(minionNames[minionNames.Length - 1 - counter]);
                    counter++;
                }
            }

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private static string[] GetMinionNames(SqlConnection sqlConnection)
        {
            string query = @"SELECT [Name] FROM [Minions]";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<string> minionNames = new List<string>();
            while (sqlDataReader.Read())
            {
                minionNames.Add(sqlDataReader["Name"].ToString());
            }

            sqlCommand.Dispose();
            sqlDataReader.Close();
            sqlDataReader.Dispose();
            return minionNames.ToArray();
        }
    }
}
