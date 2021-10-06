namespace Refactor.Sample.SimplifyingMethodCall.ReplaceErrorCodeWithException
{
    public class Problem
    {
        private int balance;
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        int Withdraw(int amount)
        {
            if (amount > balance)
            {
                return -1;
            }
            else
            {
                Balance -= amount;
                return 0;
            }
        }
    }
}

// Problem
// A method returns a special value that indicates an error?

// Solution
// Throw an exception instead.

