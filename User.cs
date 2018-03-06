/*
    User 
    Contains functionality to make deposits and withdrawals, check balance, and see
        transaction history, as well as retrieving account details such as username and password.
 */


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

        /*
        GetUserName()
        Returns the username of the user object
         */
        public string GetUserName(){
            return this.Username;
        }

        /*
        GetPassword()
        Returns the password of the user object
         */
        public string GetPassword(){
            return this.Password;
        }


        /*
        MakeDeposit()
        Updates the users balance with a given amount and updates the users
            transaction history
        Input: The deposit amount (Double)
         */
        public void MakeDeposit(Double amount){
            this.Balance += amount;
            this.UpdateTransactionHistory("Deposit", amount);
            Console.WriteLine("--------------\nYou made a deposit of $"+ String.Format("{0:.00}",amount));
        }

         /*
        MakeWithdrawal()
        Funds permitting, subtracts the withdrawal amount from the users balance and updates the users
            transaction history
        Input: The withdrawal amount (Double)
         */
        public void MakeWithdrawal(Double amount){
            if (this.Balance-amount>=0.00){
                Balance = Balance-amount;
                this.UpdateTransactionHistory("Withdrawal", amount);
                Console.WriteLine("--------------\nYou made a withdrawal of $"+ String.Format("{0:.00}",amount));
            }else{
                Console.WriteLine("--------------\nError: Insufficient funds, withdrawal cancelled.");
            }
        }
        
        /*
        UpdateTransactionHistory()
        Records a transaction (deposit or withdrawal) to the users transaction history (arraylist)
        Inputs: The type of transaction (deposit or withdrawal), the amount of money involved in
            transaction
        */
        private void UpdateTransactionHistory(string type, Double amount){
            String FormattedAmount = string.Format("{0:0.00}",amount);
            String FormattedBalance = string.Format("{0:0.00}",this.Balance);
            String TransactionDate = DateTime.Today.ToShortDateString();
            String TransactionTime = DateTime.Now.ToShortTimeString();
            String Transaction = TransactionDate + " " + TransactionTime + "   " + type +
                                 ": $" + FormattedAmount +", Balance: $"+FormattedBalance+"";
            this.TransactionHistory.Add(Transaction);
        }

        /*
        DisplayTransactionHistory()
        Prints the users transaction history to the screen 
         */
        public void DisplayTransactionHistory(){
            foreach (String i in this.TransactionHistory){
                Console.WriteLine(">>>{0}",i);
            }
        }

        /*
        CheckBalance()
        Prints the users current balance to the screen
         */
        public void CheckBalance(){
            String FormattedBalance = string.Format("{0:0.00}",this.Balance);
            Console.WriteLine("---------------\nCurrent Balance: ${0}",FormattedBalance);
        }




    }
}