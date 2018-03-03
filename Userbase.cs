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

        private void Add(User user){
            string Username = user.GetUserName();
            Users.Add(Username, user);
            Console.WriteLine("Added User {0} to Userbase", Username);
        }

        public bool UserExists(string userName){
            bool UserInUserbase = Users.ContainsKey(userName);
            return UserInUserbase;
        }

        public User GetUser(string username){
            User user = Users[username];
            return user;
        }


        public void CreateUser(){
            User user;
            String Username = CreateUserName();
            String Password = CreatePassword();
            user = new User(Username,Password);
            this.Add(user);
        }

        private string CreateUserName(){
            String Input;
            String Username = null;
            bool UsernameAccepted = false;
            while (!UsernameAccepted){
                Console.WriteLine("Enter desired Username:");
                Input = Console.ReadLine();
                if (!String.IsNullOrEmpty(Input)){
                    if(!this.UserExists(Input)){
                        Username = Input;
                        UsernameAccepted=true;
                        Console.WriteLine("Username {0} Accepted", Username);
                    }else{
                        Console.WriteLine("Error: Username {0} taken \n", Input);
                    }
                }else{
                    Console.WriteLine("Error: Username cannot be blank.");
                }
            }
            return Username;
        }
        private string CreatePassword(){
            String Input;
            String Password = null;
            bool PasswordAccepted = false;
            Console.WriteLine("Create Password:");
            while (!PasswordAccepted){
                Input = Console.ReadLine();
                if (!String.IsNullOrEmpty(Input)){
                    Password = Input;
                    PasswordAccepted=true;
                    Console.WriteLine("Password Accepted");
                }else{
                    Console.WriteLine("Error: Enter Valid Password");
                }
            }
            return Password;
        }

        public bool ValidatePassword(User user, string password){
            bool validated = false;
            validated = user.GetPassword().Equals(password);
            return validated;
        }
        /*
        public User Lookup(){

        }
        */
            




    }
}