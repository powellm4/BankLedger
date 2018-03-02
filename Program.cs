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
    store users in list
    enable user creation via command line

 */





using System;

namespace BankLedger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            User TestUser = new User("user1","password1");
        }
    }
}
