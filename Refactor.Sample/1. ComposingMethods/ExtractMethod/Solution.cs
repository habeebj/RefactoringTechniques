using System;

namespace Refactoring.Sample.ComposingMethods.ExtractMethod
{
    public class Solution
    {
        private string name;
        private void PrintBanner() {}
        private double GetOutstanding() => default(double);

        void PrintOwing()
        {
            PrintBanner();
            PrintDetails();
        }

        private void PrintDetails()
        {
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"amount: {GetOutstanding()}");
        }
    }
}


// Problem
// You have a code fragment that can be grouped together.

// Solution
// Move this code to a separate new method (or function) and replace the old code with a call to the method.

// Why Refactor

// The more lines found in a method, the harder it’s to figure out what the method does. This is the main reason for this refactoring.

// Besides eliminating rough edges in your code, extracting methods is also a step in many other refactoring approaches.

/* Benefits */
// More readable code! Be sure to give the new method a name that describes the method’s purpose: createOrder(), renderCustomerInfo(), etc.
// Less code duplication. Often the code that’s found in a method can be reused in other places in your program. So you can replace duplicates with calls to your new method.
// Isolates independent parts of code, meaning that errors are less likely (such as if the wrong variable is modified).