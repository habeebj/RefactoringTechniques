namespace Refactoring.Sample.ComposingMethods.InlineMethod
{
    public class Solution
    {
        public class PizzaDelivery
        {
            private int numberOfLateDeliveries;

            int GetRating()
            {
                return numberOfLateDeliveries > 5 ? 2 : 1;
            }

            bool MoreThanFiveLateDeliveries()
            {
                return numberOfLateDeliveries > 5;
            }
        }
    }
}