namespace Refactor.Sample.ComposingMethods.RemoveAssignmentsToParameters
{
    public class Problem
    {
        int Discount(int inputVal, int quantity)
        {
            if (quantity > 50)
            {
                inputVal -= 2;
            }

            return inputVal;
        }
    }
}

// Problem
// Some value is assigned to a parameter inside method’s body.

// Solution
// Use a local variable instead of a parameter.

// Why
// Second, multiple assignments of different values to a single parameter make it difficult for you to know what data should be contained in the parameter at any particular point in time.

// Benefits
// Each element of the program should be responsible for only one thing. This makes code maintenance much easier going forward, since you can safely replace code without any side effects.