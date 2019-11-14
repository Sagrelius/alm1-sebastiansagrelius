using ALM1Bank.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM1Bank.Data
{
    public class BankRepository
    {

        public List<Customer> Customers = new List<Customer>
        {
            new Customer {CustomerID = 1, Name = "Sebastian Sagrelius", AccountID = 1},
            new Customer {CustomerID = 2, Name = "Theodor Royen", AccountID = 2},
            new Customer {CustomerID = 3, Name = "The Odor", AccountID = 3},
            new Customer {CustomerID = 4, Name = "Seb Astian", AccountID = 4}
        };

        public List<Account> Accounts = new List<Account>
        {
            new Account {AccountID = 1, Balance = 1000M, CustomerID = 1},
            new Account {AccountID = 2, Balance = 500M, CustomerID = 2},
            new Account {AccountID = 3, Balance = 20000M, CustomerID = 3},
            new Account {AccountID = 4, Balance = 10000M, CustomerID = 4}
        };

        public bool Withdraw(decimal amount, int accountID)
        {
            var account = Accounts.SingleOrDefault(x => x.AccountID == accountID);

            if (account.Balance - amount < 0)
            {
                return false;
            }
            account.Balance -= amount;
            return true;
        }

        public bool Deposit(decimal amount, int accountID)
        {
            var account = Accounts.SingleOrDefault(x => x.AccountID == accountID);
            account.Balance += amount;
            return true;
        }

        public Account GetAccount(int id)
        {
            var account = Accounts.SingleOrDefault(x => x.AccountID == id);

            return account;
        }

        public bool Transfer(decimal amount, int accountIDOne, int accountIDTwo)
        {

            var account1 = Accounts.SingleOrDefault(m => m.AccountID == accountIDOne);
            var account2 = Accounts.SingleOrDefault(m => m.AccountID == accountIDTwo);
            if (account1 == null || account1.Balance - amount < 0 || account2 == null || account1.AccountID == account2.AccountID)
            {

                return false;
            }

            else

                account1.Balance -= amount;
            account2.Balance += amount;

            return true;
        }


    }
}

