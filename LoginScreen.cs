using System;

namespace BankLedger
{
    class LoginScreen
    {
        public LoginScreen(){

        }
        public User RequestLogin(Userbase users){
            bool LoginComplete = false;
            User user = null;
            while(!LoginComplete){
                Console.WriteLine("Welcome! \nTo Login, Enter 1. \nTo Create an Account, Enter 2.");
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

        private User Login(Userbase users){
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

        private  User RequestUser(Userbase users){
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
        private bool RequestPassword(User user, Userbase users){
            bool PasswordAccepted = false;
            bool Lockout = false;
            String Input;
            int AttemptsRemaining =3;
            while ((!PasswordAccepted) && (!Lockout)){
                Console.Write("Enter password:\n>");
                Input = Console.ReadLine();
                if (users.ValidatePassword(user,Input)){
                    PasswordAccepted=true;
                    Console.WriteLine("Password Accepted");
                }else{                    
                    AttemptsRemaining--;
                    if(AttemptsRemaining==0){
                        Lockout=true;
                    }
                    if(Lockout){
                        Console.WriteLine("Password Incorrect, Returning to main screen");
                    }else{
                        Console.WriteLine("Error: Password Incorrect, Attempts Remaining: {0}",AttemptsRemaining);
                    }                        
                }
            }
            return PasswordAccepted;
        }

    }
}