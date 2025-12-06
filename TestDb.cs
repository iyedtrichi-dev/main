using System;
using Microsoft.EntityFrameworkCore;

class TestDb
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();
            Console.WriteLine("Database created successfully!");

            // Check tables
            var connection = context.Database.GetDbConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT name FROM sqlite_master WHERE type='table';";
            var reader = command.ExecuteReader();
            Console.WriteLine("Tables in database:");
            while (reader.Read())
            {
                Console.WriteLine("- " + reader.GetString(0));
            }
            connection.Close();
        }
    }
}
