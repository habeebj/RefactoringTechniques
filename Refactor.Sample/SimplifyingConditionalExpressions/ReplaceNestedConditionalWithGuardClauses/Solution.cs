using System;

namespace Refactor.Sample.SimplifyingConditionalExpressions.ReplaceNestedConditionalWithGuardClauses
{
    public class Solution
    {
        public bool isDead { get; private set; }
        public bool isSeparated { get; private set; }
        public bool isRetired { get; private set; }

        public double GetPayAmount()
        {
            double result;

            if (isDead)
            {
                result = DeadAmount();
            }

            if (isSeparated)
            {
                result = SeparatedAmount();
            }

            if (isRetired)
            {
                result = RetiredAmount();
            }

            return NormalPayAmount();
        }

        private double DeadAmount()
        {
            throw new NotImplementedException();
        }

        private double NormalPayAmount()
        {
            throw new NotImplementedException();
        }

        private double RetiredAmount()
        {
            throw new NotImplementedException();
        }

        private double SeparatedAmount()
        {
            throw new NotImplementedException();
        }
    
    }
}

// Problem
// You have a group of nested conditionals and it’s hard to determine the normal flow of code execution.

// Solution
// Isolate all special checks and edge cases into separate clauses and place them before the main checks. Ideally, you should have a “flat” list of conditionals, one after the other.

