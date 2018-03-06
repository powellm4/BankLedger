
/*
    BankLedger by Marshall Powell
    A simple C# program for creating a bank account and performing bank transactions (deposit,
    withdraw, check balance, view history, logout).


*/

using System;

namespace BankLedger
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Userbase Users = new Userbase();
            LoginScreen LoginScreen = new LoginScreen(Users);
            UserMenu UserMenu;
            while(!exit){
                User user = LoginScreen.RequestLogin();
                    if(user!=null){
                        UserMenu = new UserMenu(user);
                        user = UserMenu.Navigate();
                    }
            }
        }      
    }
}
