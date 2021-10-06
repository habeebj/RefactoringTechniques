namespace Refactor.Sample.SimplifyingConditionalExpressions.ConsolidateDuplicateConditionalFragments
{
    public class Problem
    {
        public double Price { get; private set; }

        void SendDiscount()
        {
            double total = 0;

            if (IsSpecialDeal())
            {
                total = Price * 0.95;
                Send();
            }
            else
            {
                total = Price * 0.98;
                Send();
            }
        }

        private void Send()
        {
            throw new System.NotImplementedException();
        }

        private bool IsSpecialDeal()
        {
            throw new System.NotImplementedException();
        }
    }
}

// Problem
// Identical code can be found in all branches of a conditional.

// Solution
// Move the code outside of the conditional.