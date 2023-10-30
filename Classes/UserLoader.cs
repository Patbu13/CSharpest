using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/28/23

namespace CSharpest.Classes
{
    public class UserLoader
    {
        private readonly string _filepath;

        public UserLoader(string filepath) {
            _filepath = filepath;
        }


        public List<User> loadUsers()
        {
            List<User> users = new List<User>();

            using StreamReader reader = new StreamReader(_filepath);
            var json = reader.ReadToEnd();
            var jarray = JArray.Parse(json);

            foreach (var i in jarray)
            {
                User user = i.ToObject<User>();
                users.Add(user);
            }

            return users;
        }


    }
}
