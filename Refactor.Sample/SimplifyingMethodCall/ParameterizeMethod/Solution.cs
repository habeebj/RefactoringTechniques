namespace Refactor.Sample.SimplifyingMethodCall.ParameterizeMethod
{
    public class Solution
    {
        public double Raised(double percentage)
        {
            return 10 * percentage / 100;
        }

    }
}

// Problem
// Multiple methods perform similar actions that are different only in their internal values, numbers or operations.

// Solution
// Combine these methods by using a parameter that will pass the necessary special value.

// Why Refactor
// If you have similar methods, you probably have duplicate code, with all the consequences that this entails.

// What’s more, if you need to add yet another version of this functionality, you will have to create yet another method. Instead, you could simply run the existing method with a different parameter.

