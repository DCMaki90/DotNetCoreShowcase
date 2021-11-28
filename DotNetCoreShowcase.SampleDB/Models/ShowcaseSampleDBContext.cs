using System;
using System.IO;
using System.Reflection;
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
            DbPath = $@"{AppDataProjectDir}\ShowcaseSample.db";
            
            System.IO.Directory.CreateDirectory(AppDataProjectDir);  // Function ignores if it exists, created if it does not
            if (!System.IO.File.Exists(DbPath))
            {
                using (var connection = new SqliteConnection($"Data Source={DbPath}"))
                {
                    connection.Open();  // Ensure the SQLite db file is created
                }
            }
        }

        // Create a Sqlite database file
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
