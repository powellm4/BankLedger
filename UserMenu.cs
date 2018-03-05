using System;

namespace BankLedger
{
    class UserMenu
    {
        private User User;
        public UserMenu(User user){
            this.User = user;
        }
        public User Navigate(){
            String Input;
            bool LoggedIn = true;
            string OptionOne = "Record a deposit";
            string OptionTwo = "Record a withdrawal";
            string OptionThree = "Check your balance";
            string OptionFour = "See your transaction history";
            string OptionFive = "Logout";
            while(LoggedIn){
                Console.Write("--------------\n"+
                                "What would you like to do? Enter 1-5.\n"+
                                "1.{0}\n2.{1}\n3.{2}\n4.{3}\n5.{4}\n>",
                                OptionOne,OptionTwo,OptionThree,OptionFour,OptionFive);
                Input= Console.ReadLine();

                switch(Input){
                    case "1":
                        ProcessDeposit();
                        break;
                    case "2":
                        ProcessWithdrawal();
                        break;
                    case "3":
                        this.User.CheckBalance();
                        break;
                    case "4":
                        Console.WriteLine("--------------\nDisplaying transaction history.\n------------------");
                        this.User.DisplayTransactionHistory();
                        break;
                    case "5":
                        Console.WriteLine("Logging out\n");
                        LoggedIn = false;
                        break;
                }
            }
            return null;
        }

        private void ProcessDeposit(){
            Double Amount;
            bool ValidAmount =false;
            while(!ValidAmount){
                Console.Write("How much money would you like to deposit?\n>");
                String Input = Console.ReadLine();
                if (!String.IsNullOrEmpty(Input)){
                    Amount = Convert.ToDouble(Input);
                    Amount = Math.Round(Amount,2);
                    ValidAmount = true;
                    this.User.MakeDeposit(Amount);
                }else{
                    Console.Write("Enter valid amount.\n");
                }
            }
        }

        private void ProcessWithdrawal(){
            Double Amount;
            bool ValidAmount =false;
            while(!ValidAmount){
                Console.Write("How much money would you like to withdraw?\n>");
                String Input = Console.ReadLine();
                if (!String.IsNullOrEmpty(Input)){
                    Amount = Convert.ToDouble(Input);
                    Amount = Math.Round(Amount,2);
                    ValidAmount = true;
                    this.User.MakeWithdrawal(Amount);
                }else{
                    Console.Write("Enter valid amount.\n");
                }
            }
        }













    }
}