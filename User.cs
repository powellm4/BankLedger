using System;
using System.Collections;

namespace BankLedger
{
    class User
    {
        private string Username;
        private string Password;
        private Double Balance;
        private ArrayList TransactionHistory;


        public User (string userName, string password){
            this.Username = userName;
            this.Password = password;
            this.Balance = 0.00;
            this.TransactionHistory  = new ArrayList();
            Console.WriteLine("--------------\nCreated new User with Username:{0}, Password: {1}", this.Username,this.Password);
        }

        public string GetUserName(){
            return this.Username;
        }

        public string GetPassword(){
            return this.Password;
        }

        public Double GetBalance(){
            return this.Balance;
        }

        public Double MakeDeposit(Double amount){
            this.Balance += amount;
            this.UpdateTransactionHistory("Deposit", amount);
            Console.WriteLine("--------------\nYou made a deposit of $"+ String.Format("{0:.00}",amount));
            return this.Balance;
        }

        public Double MakeWithdrawal(Double amount){
            if (this.Balance-amount>=0.00){
                Balance = Balance-amount;
                this.UpdateTransactionHistory("Withdrawal", amount);
                Console.WriteLine("--------------\nYou made a withdrawal of $"+ String.Format("{0:.00}",amount));
            }else{
                Console.WriteLine("Error: Insufficient funds, withdrawal cancelled.");
            }
            return Balance;
        }
        
        private void UpdateTransactionHistory(string type, Double amount){
            String FormattedAmount = string.Format("{0:0.00}",amount);
            String FormattedBalance = string.Format("{0:0.00}",this.Balance);
            String TransactionDate = DateTime.Today.ToShortDateString();
            String TransactionTime = DateTime.Now.ToShortTimeString();
            String Transaction = TransactionDate + " " + TransactionTime + "   " + type +
                                 ": $" + FormattedAmount +", Balance: $"+FormattedBalance+"";
            this.TransactionHistory.Add(Transaction);
        }

        public void DisplayTransactionHistory(){
            foreach (String i in this.TransactionHistory){
                Console.WriteLine(">>>{0}",i);
            }
        }

        public void CheckBalance(){
            String FormattedBalance = string.Format("{0:0.00}",this.Balance);
            Console.WriteLine("---------------\nCurrent Balance: ${0}",FormattedBalance);
        }




    }
}