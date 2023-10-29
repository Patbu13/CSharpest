using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CSharpest.Classes
{
    public class UserLoader
    {
        private readonly string _filepath;

        public UserLoader(string filepath) {
            _filepath = filepath;
        }


        public SortedSet<User> loadInventory()
        {
            SortedSet<User> users = new SortedSet<User>();


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
