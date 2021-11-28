using DotNetCoreShowcase.SampleDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using static System.Environment;

namespace DotNetCoreShowcase.SampleDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Copy existing database to AppData
            SpecialFolder appDataDir = Environment.SpecialFolder.LocalApplicationData;
            string appDataProjectDir = $@"{Environment.GetFolderPath(appDataDir)}\DotNetCoreShowcase";
            File.Copy($@".\SampleDatabases\Chinook_Sqlite.sqlite" , $@"{appDataProjectDir}\Chinook_Sqlite.sqlite", overwrite : true);

            // Populate unexisting database to AppData
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
        }
    }
}
