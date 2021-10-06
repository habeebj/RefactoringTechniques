namespace Refactor.Sample.SimplifyingConditionalExpressions.ConsolidateConditionalExpression
{
    public class Solution
    {
        public int seniority { get; private set; }
        public int monthsDisabled { get; private set; }
        public bool isPartTime { get; private set; }

        double DisabilityAmount()
        {
            if (IsNotEligibleForDisability())
                return 0;
            
            // Compute the disability amount.
            // ...
            return 0;
        }

        private bool IsNotEligibleForDisability()
        {
            return seniority < 2 && monthsDisabled > 12 && isPartTime;
        }
    }
}

// Problem
// You have multiple conditionals that lead to the same result or action.

// Solution
// Consolidate all these conditionals in a single expression.