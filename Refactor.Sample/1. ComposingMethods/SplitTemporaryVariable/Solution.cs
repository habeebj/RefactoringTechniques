using System;

namespace Refactor.Sample.ComposingMethods.SplitTemporaryVariable
{
    public class Solution
    {
        private int width;
        private int height;

        void SomeMethod()
        {
            double perimeter = 2 * (height + width);
            Console.WriteLine(perimeter);
            double area = height * width;
            Console.WriteLine(area);
        }
    }
}

// Problem
// You have a local variable that’s used to store various intermediate values inside a method.

// Solution
// Use different variables for different values. Each variable should be responsible for only one particular thing.