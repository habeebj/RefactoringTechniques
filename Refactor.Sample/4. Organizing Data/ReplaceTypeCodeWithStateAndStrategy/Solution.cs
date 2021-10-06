using System;

namespace Refactor.Sample.Organizing_Data.ReplaceTypeCodeWithStateAndStrategy
{
    public class Solution
    {
        public class Account
        {
            public Account(string iban, bool isOverdraftAllowed)
            {
                Iban = iban;
                State = new Open(isOverdraftAllowed);
            }

            public string Iban { get; }
            public AccountState State { get; set; }
            public decimal CurrentBalance { get; set; }

            public void Withdraw(decimal amount) => State.Withdraw(this, amount);
        }

        public abstract class AccountState
        {
            public abstract void Withdraw(Account account, decimal amount);
        }

        public class Open : AccountState
        {
            private readonly bool isOverdraftAllowed;

            public Open(bool isOverdraftAllowed)
            {
                this.isOverdraftAllowed = isOverdraftAllowed;
            }

            public override void Withdraw(Account account, decimal amount)
            {
                if (amount > account.CurrentBalance && !isOverdraftAllowed)
                    throw new InvalidOperationException($"Account {account.Iban} does not allow overdraft.");

                account.CurrentBalance -= amount;
            }
        }

        public class Closed : AccountState
        {
            public override void Withdraw(Account account, decimal amount)
            {
                throw new InvalidOperationException($"Cannot withdraw money because account {account.Iban} is closed.");
            }
        }

        public class Frozen : AccountState
        {
            public override void Withdraw(Account account, decimal amount)
            {
                throw new InvalidOperationException($"Cannot withdraw money because account {account.Iban} is frozen.");
            }
        }

        public class NoDebit : AccountState
        {
            public override void Withdraw(Account account, decimal amount)
            {
                throw new InvalidOperationException($"Cannot withdraw money because your account is ------.");
            }
        }
    }
}