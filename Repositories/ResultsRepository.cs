using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using sampleApp.Models;
using System.Text;

namespace sampleApp.Repositories
{

    public class ResultsRepository
    {
        static string password = "wp2003wp";
        static string salt = "f9keVBXE";
        private readonly List<Result> results = new()
        {
            new Result
            {
                Gender = "Female",
                Name = new Name
                {
                    Title = "Madame",
                    First = "Romana",
                    Last = "Francois"
                },
                Location = new Location
                {
                    Street = new Street { Number = 3471, Name = "Rue Dubois" },
                    City = "Brutten",
                    State = "Fribourg",
                    Country = "Switzerland",
                    Postcode = 6951,
                    Coordinates = new Coordinates { Latitude = "-54.4721", Longitude = "30.6940" },
                    Timezone = new Timezone { Offset = "+6:00", Description = "Almaty, Dhaka, Colombo" }
                },
                Email = "romana.francois@example.com",
                Dob = new AgeDate { Date = DateTimeOffset.Parse("1964-04-24T06:25:40.777Z"), Age = 57 },
                Registered = new AgeDate { Date = DateTimeOffset.Parse("2016-09-28T11:15:47.538Z"), Age = 57 },

                Phone = "078 225 75 50",
                Cell = "075 437 25 80",
                Id = new NameValue { Name = "AVS", Value = "756.9989.7526.17" },
                Picture = new Picture
                {
                    Large = "https://randomuser.me/api/portraits/women/27.jpg",
                    Medium = "https://randomuser.me/api/portraits/med/women/27.jpg",
                    Thumbnail = "https://randomuser.me/api/portraits/thumb/women/27.jpg"
                },
                Nat = "CH",

                Login = new Login
                {
                    Uuid = Guid.NewGuid(),
                    Username = "tinykoala839",
                    Password = password,
                    Salt = salt,
                    Md5 = GetMD5Hash(password + salt),
                    Sha1 = GetSha1Hash(password + salt),
                    Sha256 = GetSha256Hash(password + salt),

                }

            }
        };
        public static string GetMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GetSha1Hash(string input)
        {
            var data = Encoding.UTF8.GetBytes(input);
            var hashData = new SHA1Managed().ComputeHash(data);
            var hash = string.Empty;
            foreach (var b in hashData)
            {
                hash += b.ToString("X2");
            }
            return hash;
        }

        static string GetSha256Hash(string input)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public IEnumerable<Result> GetResults()
        {
            return results;
        }

        public Result GetResult(Guid id)
        {
            return results.Where(result => result.Login.Uuid == id).SingleOrDefault();
        }
    }
}

