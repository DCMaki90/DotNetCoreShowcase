using DotNetCoreShowcase.SampleDB.Models;
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
                Guid userIdGuid = Guid.NewGuid();
                Guid addressGuid = Guid.NewGuid();
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
            }
        }
    }
}
