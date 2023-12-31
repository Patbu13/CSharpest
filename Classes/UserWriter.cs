﻿using System.Collections.Generic;
using System.Text.Json;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23

namespace CSharpest.Classes
{
    public class UserWriter
    {
        private readonly string _filepath;

        public UserWriter(string filepath)
        {
            _filepath = filepath;
        }

        public void writeUser(Shopper user)
        {
            UserLoader userLoader = new UserLoader(_filepath);
            List<Shopper> currUsers = userLoader.loadUsers();
            Shopper? foundUser = currUsers.Find(x => x.AccountID == user.AccountID);

            if (foundUser != null)
            {
                currUsers[currUsers.IndexOf(foundUser)] = user;
            }
            else
            {
                currUsers.Add(user);
            }

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            JsonSerializerOptions optionsCopy = new(options);
            string jsonString = JsonSerializer.Serialize(currUsers, optionsCopy);

            File.WriteAllText(_filepath, jsonString);
        }
    }
}
