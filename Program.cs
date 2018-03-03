/*
You have been tasked with writing the world’s greatest banking ledger. Please code a solution
that can perform the following workflows through a console application (accessed via the 
command line):

-Create a new account
-Login
-Record a deposit
-Record a withdrawal
-Check balance
-See transaction history
-Log out

For additional credit, you may implement this through a web page. They don’t have to run at 
the same time, but if you would like to do that, feel free.

C# is preferred but not required. Use whatever frameworks/libraries you wish, and just make
sure they are included or available via via NuGet/npm/etc. Please use a temporary memory store
(local cache) instead of creating an actual database, and don't spend much time on the UI
(unless you love doing that).




todo:
    create user class
    store users
        dictionary
            key: username, value : user
    enable user creation via command line
    enable user login via command line
    enable user account interaction via command line
    enable exit sequence from steps

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
            while(!exit){
                User user = RequestLogin(Users);
                NavigateUser(user);
            }

            

        }




        static User RequestLogin(Userbase users){
            bool LoginComplete = false;
            User user = null;
            Console.WriteLine("Welcome! \nTo Login, Enter 1. \nTo Create an Account, Enter 2.");
            while(!LoginComplete){
                String Input = Console.ReadLine();
                if (!String.IsNullOrEmpty(Input)){
                    if(Input == "2"){
                        users.CreateUser();
                        user = Login(users);
                        //LoginComplete=true;
                    }else if(Input == "1"){
                        user = Login(users);
                    }else{
                        Console.WriteLine("Please enter either 1 or 2 to continue");
                    }
                }
                if(user!=null){
                    LoginComplete=true;
                }
            }
            return user;
        }

        static User Login(Userbase users){
            bool LoginSuccess=false;
            User user = RequestUser(users);
            LoginSuccess =RequestPassword(user,users);
            if (LoginSuccess){
                return user;
            }
            else{
                return null;
            }
        }

        public static User RequestUser(Userbase users){
            //bool LoginSuccess = false;
            bool UserFound = false;
            User User= null;
            String Input;
            Console.Write("Welcome to the login screen!\nEnter username:\n>");
            while(!UserFound){
                Input = Console.ReadLine();
                if(!String.IsNullOrEmpty(Input)){
                    UserFound = users.UserExists(Input);
                    if(UserFound){
                        User = users.GetUser(Input);
                        //LoginSuccess = RequestPassword(User,users);
                    }else{
                        Console.Write("Username not found. Try Again:\n>");
                    }
                }else{
                Console.WriteLine("Please enter valid username.");
                }
            }
            return User;
        }
        public static bool RequestPassword(User user, Userbase users){
            bool PasswordAccepted = false;
            String Input;
            while (!PasswordAccepted){
                Console.Write("Enter password:\n>");
                Input = Console.ReadLine();
                if (users.ValidatePassword(user,Input)){
                    PasswordAccepted=true;
                    Console.WriteLine("Password Accepted");
                }else{
                    Console.WriteLine("Error: Password Incorrect");
                }
            }
            return PasswordAccepted;
        }

        static void NavigateUser(User user){
            
        }

       
    }
}
