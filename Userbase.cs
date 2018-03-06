/*
    Userbase
    A Class to store, search for and create user objects. 

*/

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

        /*
        Add()
        Adds a user to the userbase
        Input: the user object to be added to the userbase
         */
        private void Add(User user){
            string Username = user.GetUserName();
            Users.Add(Username, user);
            Console.WriteLine("--------------\nAdded User {0} to Userbase", Username);
        }

        /*
        UserExists()
        Searches for a username and returns a boolean based on whether or not a user 
            is found with that username
        Input: the username by which to search for a user
        Returns: True if user is found, false if not
         */
        public bool UserExists(string userName){
            bool UserInUserbase = Users.ContainsKey(userName);
            return UserInUserbase;
        }

        /*
        GetUser()
        Returns a user object selected by username
        Input: Username of requested user
        Returns: Found user object
         */
        public User GetUser(string username){
            User user = Users[username];
            return user;
        }

        /* 
        CreateUser()
        Initiates the user creation process by calling the CreateUserName()
            and CreatePassword() functions and adding the user to the userbase.
        */
        public void CreateUser(){
            User user;
            String Username = CreateUserName();
            String Password = CreatePassword();
            user = new User(Username,Password);
            this.Add(user);
        }

        /*
        CreateUserName()
        Allows the user to create a username, handles input and checks for duplicate
            usernames.
        Returns: The created unique username to be used for a new user.
         */
        private string CreateUserName(){
            String Input;
            String Username = null;
            bool UsernameAccepted = false;
            while (!UsernameAccepted){
                Console.Write("--------------\nEnter desired Username:\n>");
                Input = Console.ReadLine();
                if (!String.IsNullOrEmpty(Input)){
                    if(!this.UserExists(Input)){
                        Username = Input;
                        UsernameAccepted=true;
                        Console.WriteLine("--------------\nUsername {0} Accepted", Username);
                    }else{
                        Console.WriteLine("--------------\nError: Username {0} taken \n", Input);
                    }
                }else{
                    Console.WriteLine("--------------\nError: Username cannot be blank.");
                }
            }
            return Username;
        }
        
        /*
        CreatePassword()
        Allows the user to create their own password as long as the password
            is not blank
        Returns: the user created password to be used with the user account
         */
        private string CreatePassword(){
            String Input;
            String Password = null;
            bool PasswordAccepted = false;
            Console.Write("--------------\nCreate Password:\n>");
            while (!PasswordAccepted){
                Input = Console.ReadLine();
                if (!String.IsNullOrEmpty(Input)){
                    Password = Input;
                    PasswordAccepted=true;
                    Console.WriteLine("--------------\nPassword Accepted");
                }else{
                    Console.Write("--------------\nError: Enter Valid Password:\n>");
                }
            }
            return Password;
        }

        /*
        ValidatePassword()
        Given a user object and a password attempt, returns a boolean indicating
            whether or not the password attempt was successful
        Input: The user object for the attempted login and the password attempt
        Returns: True if password attempt was correct and false otherwise.
         */
        public bool ValidatePassword(User user, string password){
            bool validated = false;
            validated = user.GetPassword().Equals(password);
            return validated;
        }
             
    }
}