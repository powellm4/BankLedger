/*
    LoginScreen
    A Class that handles the login process of the user, also allowing the user to create an account if 
    the user does not yet have one.
*/


using System;

namespace BankLedger
{
    class LoginScreen
    {
        private Userbase Users;

        /*
        LoginScreen Constructor: 
        Input: A Userbase of users to which the user can login or in which the user can 
            create an account.
        */
        public LoginScreen(Userbase users){
            this.Users = users;
        }

        /*
        RequestLogin()
        Initiates the login process by giving user the choice of logging in or creating an account.
        Returns: The user object for which the user has provided the correct credentials. Returns null
            if login process fails.
        */
        public User RequestLogin(){
            bool LoginComplete = false;
            User user = null;
            while(!LoginComplete){
                Console.Write("--------------\nWelcome! \n--------------\nTo Login, Enter 1. \nTo Create an Account, Enter 2.\n>");
                String Input = Console.ReadLine();
                if (!String.IsNullOrEmpty(Input)){
                    if(Input == "2"){
                        Users.CreateUser();
                        user = Login();
                        //LoginComplete=true;
                    }else if(Input == "1"){
                        user = Login();
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

        /*
        Login()
        Calls 2 functions: RequestUser (which asks for username) and RequestPassword(which asks for
            password).
        Returns: User object upon successful login. Returns null if login is unsuccessful. 
        */
        private User Login(){
            bool LoginSuccess=false;
            User user = RequestUser();
            LoginSuccess =RequestPassword(user);
            if (LoginSuccess){
                return user;
            }
            else{
                return null;
            }
        }

        /*
        RequestUser()
        Requests the existing username from the user. Handles input from user and makes call to
            the UserExists() and GetUser() methods of the current Userbase object.
        Returns: User object with given username if user is found.
        */
        private  User RequestUser(){
            bool UserFound = false;
            User User= null;
            String Input;
            Console.Write("--------------\nWelcome to the login screen!\nEnter username:\n>");
            while(!UserFound){
                Input = Console.ReadLine();
                if(!String.IsNullOrEmpty(Input)){
                    UserFound = this.Users.UserExists(Input);
                    if(UserFound){
                        User = this.Users.GetUser(Input);
                    }else{
                        Console.Write("--------------\nUsername not found. Try Again:\n>");
                    }
                }else{
                Console.WriteLine("--------------\nPlease enter valid username.");
                }
            }
            return User;
        }

        /*
        RequestPassword()
        Asks for the password associated with the provided user. Handles user input and gives the
            user 3 chances to input the password correctly. 
        Input: User object for which login is being attempted
        Returns: true if password is entered correctly and false otherwise.
        */
        private bool RequestPassword(User user){
            bool PasswordAccepted = false;
            bool Lockout = false;
            String Input;
            int AttemptsRemaining =3;
            while ((!PasswordAccepted) && (!Lockout)){
                Console.Write("--------------\nEnter password:\n>");
                Input = Console.ReadLine();
                if (this.Users.ValidatePassword(user,Input)){
                    PasswordAccepted=true;
                    Console.WriteLine("--------------\nPassword Accepted");
                }else{                    
                    AttemptsRemaining--;
                    if(AttemptsRemaining==0){
                        Lockout=true;
                    }
                    if(Lockout){
                        Console.WriteLine("--------------\nPassword Incorrect, Returning to main screen");
                    }else{
                        Console.WriteLine("--------------\nError: Password Incorrect, Attempts Remaining: {0}",AttemptsRemaining);
                    }                        
                }
            }
            return PasswordAccepted;
        }
    }
}