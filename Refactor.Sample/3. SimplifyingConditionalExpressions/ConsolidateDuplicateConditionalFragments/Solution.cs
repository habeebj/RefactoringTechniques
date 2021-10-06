namespace Refactor.Sample.SimplifyingConditionalExpressions.ConsolidateDuplicateConditionalFragments
{
    public class Solution
    {
        private const double SPECIAL_DEAL_DISCOUNT = 0.95;
        private const double DISCOUNT = 0.98;

        public double Price { get; private set; }

        void SendDiscount()
        {
            double discount = IsSpecialDeal() ? SPECIAL_DEAL_DISCOUNT : DISCOUNT;
            var total = Price * discount;
            Send();
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