using System;

namespace BankLedger
{
    class User
    {
        private string Username;
        private string Password;
      //  private string Name;
        //private string Balance;


        public User (string userName, string password){
            this.Username = userName;
            this.Password = password;
            Console.WriteLine("Created new User with Username:{0}, Password: {1}", this.Username,this.Password);
        }

        public string GetUserName(){
            return this.Username;
        }

        public string GetPassword(){
            return this.Password;
        }
            




    }
}