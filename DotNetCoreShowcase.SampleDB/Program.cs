using System;
using System.IO;
using static System.Environment;
using Microsoft.EntityFrameworkCore;
using DotNetCoreShowcase.SampleDB.Models;

namespace DotNetCoreShowcase.SampleDB
{
    class Program
    {
        static void Main()
        {
            // Copy existing database to AppData
            Console.WriteLine("DotNetCoreShowcase.SampleDB Started");
            Console.WriteLine("DotNetCoreShowcase.SampleDB: Copying sample Chinook_sqlite.sqlite database...");
            SpecialFolder appDataDir = Environment.SpecialFolder.LocalApplicationData;
            string appDataProjectDir = $@"{Environment.GetFolderPath(appDataDir)}\DotNetCoreShowcase";
            File.Copy($@".\SampleDatabases\Chinook_Sqlite.sqlite" , $@"{appDataProjectDir}\Chinook_Sqlite.sqlite", overwrite : true);

            // Populate unexisting database to AppData
            Console.WriteLine("DotNetCoreShowcase.SampleDB: Populating ShowcaseSample.sqlite database...");
            using (var showcaseContext = new ShowcaseSampleDBContext())
            {
                // Automate table creations to add data
                showcaseContext.Database.Migrate();

                // Add data
                Guid addressGuid = Guid.NewGuid();
                showcaseContext.Addresses.Add(new Address()
                {
                    AddressId = addressGuid,
                    AddressLine1 = "115 Ash St. NE",
                    City = "New London",
                    State = "MN",
                    Zip = 56273,
                    Country = "USA"
                });
                showcaseContext.SaveChanges();

                Guid userIdGuid = Guid.NewGuid();
                showcaseContext.Users.Add(new User() 
                { 
                    UserId = userIdGuid,
                    CreationEpoch = 1638045950,
                    Email = "dcmaki90@gmail.com",
                    FirstName = "Devin",
                    LastName = "Maki",
                    AddressId = addressGuid
                });
                showcaseContext.SaveChanges();
            }
            Console.WriteLine("DotNetCoreShowcase.SampleDB: Finished");
        }
    }
}
