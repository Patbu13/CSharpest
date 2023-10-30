using System.Collections.Generic;
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

        public void writeUser(User user)
        {
            UserLoader userLoader = new UserLoader(_filepath);
            List<User> currUsers = userLoader.loadUsers();

            bool exists = currUsers.Contains(user);

            if (exists)
            {
                int index = currUsers.IndexOf(user);
                currUsers[index] = user;
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
