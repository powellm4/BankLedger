using System;
using System.Collections.Generic;

namespace BankLedger
{
    class Userbase
    {
        private Dictionary<string, User> Users;


        public Userbase (){
            Users = new Dictionary<string, User>();
            
            
        }

        public void Add(User user){
            string Username = user.GetUserName();
            Users.Add(Username, user);
            Console.WriteLine("Added User {0} to Userbase", Username);
        }

        public bool UserExists(string userName){
            bool UserInUserbase = Users.ContainsKey(userName);
            return UserInUserbase;
        }

        /*
        public User Lookup(){

        }
        */
            




    }
}