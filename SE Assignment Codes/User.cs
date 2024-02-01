using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class User
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }

        public bool IsStaff { get; set; }

        // Constructor
        public User(string name, string id, string username, string password, string mobileNumber, bool isStaff)
        {
            Name = name;
            ID = id;
            Username = username;
            Password = password;
            MobileNumber = mobileNumber;
            IsStaff = isStaff;
        }

        // Method to provide user's name
        public string ProvideName()
        {
            return Name;
        }

        // Method to identify the user
        public string IdentifyUser()
        {
            return $"{Name} ({ID})";
        }
    }
}
