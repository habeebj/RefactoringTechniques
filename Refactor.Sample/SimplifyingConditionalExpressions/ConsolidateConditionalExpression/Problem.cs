namespace Refactor.Sample.SimplifyingConditionalExpressions.ConsolidateConditionalExpression
{
    public class Problem
    {
        public int seniority { get; private set; }
        public int monthsDisabled { get; private set; }
        public bool isPartTime { get; private set; }

        double DisabilityAmount()
        {
            if (seniority < 2)
            {
                return 0;
            }
            if (monthsDisabled > 12)
            {
                return 0;
            }
            if (isPartTime)
            {
                return 0;
            }
            // Compute the disability amount.
            // ...
            return 0;
        }
    }
}

// Problem
// You have multiple conditionals that lead to the same result or action.

// Solution
// Consolidate all these conditionals in a single expression.