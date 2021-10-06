namespace Refactoring.Sample.ComposingMethods.InlineMethod
{
    public class Problem
    {
        public class PizzaDelivery
        {
            private int numberOfLateDeliveries;

            int GetRating()
            {
                return MoreThanFiveLateDeliveries() ? 2 : 1;
            }

            bool MoreThanFiveLateDeliveries()
            {
                return numberOfLateDeliveries > 5;
            }
        }
    }
}

// Problem
// When a method body is more obvious than the method itself, use this technique.

// Solution
// Replace calls to the method with the method’s content and delete the method itself.

/*
Why Refactor

A method simply delegates to another method. In itself, this delegation is no problem. But when there are many such methods, they become a confusing tangle that’s hard to sort through.

Often methods aren’t too short originally, but become that way as changes are made to the program. So don’t be shy about getting rid of methods that have outlived their use.

Benefits

By minimizing the number of unneeded methods, you make the code more straightforward.
*/