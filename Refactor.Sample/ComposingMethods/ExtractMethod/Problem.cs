using System;

namespace Refactoring.Sample.ComposingMethods.ExtractMethod
{
    public class Problem
    {
        private string name;
        private void PrintBanner() {}
        private double GetOutstanding() => default(double);

        void PrintOwing()
        {
            PrintBanner();
            
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"amount: {GetOutstanding()}");
        }
    }
}


/* Problem */
// You have a code fragment that can be grouped together.
/* Solution */
// Move this code to a separate new method (or function) and replace the old code with a call to the method.

// Why Refactor
// The more lines found in a method, the harder it’s to figure out what the method does. This is the main reason for this refactoring.