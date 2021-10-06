namespace Refactor.Sample.ComposingMethods.ReplaceMethodWithMethodObject
{
    public class Solution
    {
        public class Order
        {
            public double Price()
            {
                return new PriceCalculator(this).Compute();
            }
        }

        public class PriceCalculator
        {
            private double primaryBasePrice;
            private double secondaryBasePrice;
            private double tertiaryBasePrice;

            public PriceCalculator(Order order)
            {
                // Copy relevant information from the
                // order object.
            }

            public double Compute()
            {
                // Perform long computation.
                return 0;
            }
        }
    }
}

// Problem
// You have a long method in which the local variables are so intertwined that you can’t apply Extract Method.

// Solution
// Transform the method into a separate class so that the local variables become fields of the class. Then you can split the method into several methods within the same class.

// Benefits
// Isolating a long method in its own class allows stopping a method from ballooning in size. This also allows splitting it into submethods within the class, without polluting the original class with utility methods.

// Drawbacks
// Another class is added, increasing the overall complexity of the program.