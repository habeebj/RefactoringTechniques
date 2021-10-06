namespace Refactor.Sample.SimplifyingMethodCall.SeparateQueryFromModifier
{
    public class Problem
    {
        void GetTotalOutstandingAndSetReadyForSummaries() { }
    }
}

// Problem
// Do you have a method that returns a value but also changes something inside an object?

// Solution
// Split the method into two separate methods. As you would expect, one of them should return the value and the other one modifies the object.

// Why Refactor
// This factoring technique implements Command and Query Responsibility Segregation. This principle tells us to separate code responsible for getting data from code that changes something inside an object.

// Benefits
// If you have a query that doesn’t change the state of your program, you can call it as many times as you like without having to worry about unintended changes in the result caused by the mere fact of you calling the method.

// Drawbacks
// In some cases it’s convenient to get data after performing a command. For example, when deleting something from a database you want to know how many rows were deleted.