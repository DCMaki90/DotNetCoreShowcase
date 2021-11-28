using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using static System.Environment;

namespace DotNetCoreShowcase.SampleDB.Models
{
    public class ShowcaseSampleDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public string DbPath { get; private set; }
        public string AppDataProjectDir { get; private set; }


        public ShowcaseSampleDBContext()
        {
            // Set to user's AppData folder
            SpecialFolder appDataDir = Environment.SpecialFolder.LocalApplicationData;
            AppDataProjectDir = $@"{Environment.GetFolderPath(appDataDir)}\DotNetCoreShowcase";
            DbPath = $@"{AppDataProjectDir}\ShowcaseSample.sqlite";

            // CreateDirectory function ignores if it exists, created if it does not
            System.IO.Directory.CreateDirectory(AppDataProjectDir);  
            if (System.IO.File.Exists(DbPath))
            {
                using (var connection = new SqliteConnection($"Data Source={DbPath}"))
                {
                    connection.Open();
                    SqliteCommand dropCmd = connection.CreateCommand();
                    dropCmd.CommandText = "DROP TABLE IF EXISTS Users";
                    dropCmd.ExecuteNonQuery();
                    dropCmd.CommandText = "DROP TABLE IF EXISTS Addresses";
                    dropCmd.ExecuteNonQuery();
                    dropCmd.CommandText = "DROP TABLE IF EXISTS __EFMigrationsHistory";
                    dropCmd.ExecuteNonQuery();
                }
            }
            else
            {
                using (var connection = new SqliteConnection($"Data Source={DbPath}"))
                {
                    // Ensure the SQLite db file is created
                    connection.Open();  
                }
            }
        }

        // Create a Sqlite database file
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
