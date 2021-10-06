using System;

namespace Refactor.Sample.ComposingMethods.SplitTemporaryVariable
{
    public class Problem
    {
        private int width;
        private int height;

        void SomeMethod()
        {
            double temp = 2 * (height + width);
            Console.WriteLine(temp);
            temp = height * width;
            Console.WriteLine(temp);
        }
    }
}

// Problem
// You have a local variable that’s used to store various intermediate values inside a method (except for cycle variables).

// Solution
// Use different variables for different values. Each variable should be responsible for only one particular thing.

// Why Refactor
// If you’re skimping on the number of variables inside a function and reusing them for various unrelated purposes, you’re sure to encounter problems as soon as you need to make changes to the code containing the variables. You will have to recheck each case of variable use to make sure that the correct values are used.

// Benefits
// Code becomes more readable.

// Each component of the program code should be responsible for one and one thing only. This makes it much easier to maintain the code, since you can easily replace any particular thing without fear of unintended effects.


