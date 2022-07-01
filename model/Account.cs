using System;

namespace Bank
{
    public class Account
    {
        private AccountType AccountType {get; set;}
        private double Balance {get; set;}
        private double Credit {get ; set;}
        private string Name {get; set;}
    
         public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }
        public bool Withdrawn(double amountWithdrawn)
        {
            if(this.Balance - amountWithdrawn < (this.Credit * -1))
            {
                Console.WriteLine("Valor insuficiente.");
                return false;
            }
            this.Balance -= amountWithdrawn;

            Console.WriteLine($"Saldo atual da conta de {this.Name} é {this.Balance}");
            return true;
        }
        public void Deposit(double amountDeposit)
        {
            this.Balance += amountDeposit;
            Console.WriteLine($"O saldo atual da conta de {this.Name} é de {this.Balance}");
        }
        public void Transfer(double amountTransfer, Account destinationAccount)
        {
            if(this.Withdrawn(amountTransfer))
            {
                destinationAccount.Deposit(amountTransfer);
            }
        }
        public override string ToString()
        {
            string regress = "";
            regress += "| " + this.AccountType + " ";
            regress += "| " + this.Name + " ";
            regress += "| " + this.Balance + " ";
            regress += "| " + this.Credit + " |";
            return regress;
        }
    }
}