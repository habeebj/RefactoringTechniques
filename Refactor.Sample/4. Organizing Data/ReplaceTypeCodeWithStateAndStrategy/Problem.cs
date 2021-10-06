using System;

namespace Refactor.Sample.Organizing_Data.ReplaceTypeCodeWithStateAndStrategy
{
    public class Problem
    {
        public class Account
        {
            public Account(string iban)
            {
                Iban = iban;
                State = AccountState.Open;
            }

            public string Iban { get; }
            public AccountState State { get; set; }
            public bool IsOverdraftAllowed { get; set; }
            public decimal CurrentBalance { get; set; }

            public void Withdraw(decimal amount)
            {
                if (State == AccountState.Open)
                {
                    if (amount > CurrentBalance)
                    {
                        if (IsOverdraftAllowed)
                        {
                            CurrentBalance -= amount;
                        }
                        else
                        {
                            throw new InvalidOperationException($"Account {Iban} does not allow overdraft.");
                        }
                    }
                    else
                    {
                        CurrentBalance -= amount;
                    }
                }
                else if (State == AccountState.Closed)
                {
                    throw new InvalidOperationException($"Cannot withdraw money because account {Iban} is closed.");
                }
                else if (State == AccountState.Frozen)
                {
                    throw new InvalidOperationException($"Cannot withdraw money because account {Iban} is frozen.");
                }
            }
        }

        public enum AccountState
        {
            Open, Closed, Frozen
        }
    }
}

// Problem
// You have a coded type that affects behavior but you can’t use subclasses to get rid of it.

// Solution
// Replace type code with a state object. If it’s necessary to replace a field value with type code, another state object is “plugged in”.

// Benefits
// If you need to add a new value of a coded type, all you need to do is to add a new state subclass without altering the existing code (cf. the Open/Closed Principle).

// Drawbacks
// If you have a simple case of type code but you use this refactoring technique anyway, you will have many extra (and unneeded) classes.