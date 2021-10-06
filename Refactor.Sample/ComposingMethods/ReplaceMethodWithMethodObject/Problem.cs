namespace Refactor.Sample.ComposingMethods.ReplaceMethodWithMethodObject
{
    public class Problem
    {
        public class Order
        {
            public double Price()
            {
                double primaryBasePrice;
                double secondaryBasePrice;
                double tertiaryBasePrice;
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