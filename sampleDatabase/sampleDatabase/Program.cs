// See https://aka.ms/new-console-template for more information

using System.Data.SqlClient;
using Dapper;
using sampleDatabase;

namespace testingDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String connectionString =
                "Server=localhost;Database=testdatabase;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            var user = new User
            {
                userId = 1,
                userName = "admin",
                password = "something",
            };
            
            String deleteQuery = "DELETE FROM userTable WHERE userId = 1";
            
            String insertQuery = "INSERT INTO userTable (userId, userName, password) VALUES (@userId ,@userName, @password);";
            
            String selectQuery = "SELECT * FROM userTable";
            
            String updateQuery = "UPDATE userTable SET userName = 'tommy', password= '12345655' WHERE userId = 1";
            
            List<User> users = connection.Query<User>(selectQuery).ToList();
            
            connection.Query(deleteQuery);
            connection.Query(insertQuery, user);
            connection.Query(selectQuery);
            connection.Query(updateQuery);

            for (var i = 0; i < users.Count; i++)
            {
                Console.WriteLine(users[i].userName);
                Console.WriteLine(users[i].password);
            }
        }
    }
};


