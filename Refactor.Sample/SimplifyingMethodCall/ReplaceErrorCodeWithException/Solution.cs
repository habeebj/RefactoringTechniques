using System;

namespace Refactor.Sample.SimplifyingMethodCall.ReplaceErrorCodeWithException
{
    public class Solution
    {
        private int balance;
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        void Withdraw(int amount)
        {
            if (amount > balance)
            {
                throw new Exception("amount grt balance");
            }
            
            Balance -= amount;
        }
    }
}

// Problem
// A method returns a special value that indicates an error?

// Solution
// Throw an exception instead.

