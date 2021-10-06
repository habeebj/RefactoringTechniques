namespace Refactor.Sample.Organizing_Data.ReplaceMagicNumberWithSymbolicConstant
{
    public class Problem
    {
        private const double GRAVITATINAL_FORCE = 9.81;

        double PotentialEnergy(double mass, double height)
        {
            return mass * height * GRAVITATINAL_FORCE;
        }
    }
}

// Problem
// Your code uses a number that has a certain meaning to it.

// Solution
// Replace this number with a constant that has a human-readable name explaining the meaning of the number.

// Why Refactor

// A magic number is a numeric value that’s encountered in the source but has no obvious meaning. This “anti-pattern” makes it harder to understand the program and refactor the code.

// Yet more difficulties arise when you need to change this magic number. Find and replace won’t work for this: the same number may be used for different purposes in different places, meaning that you will have to verify every line of code that uses this number.

// Benefits
// The symbolic constant can serve as live documentation of the meaning of its value.
// It’s much easier to change the value of a constant than to search for this number throughout the entire codebase, without the risk of accidentally changing the same number used elsewhere for a different purpose.
// Reduce duplicate use of a number or string in the code. This is especially important when the value is complicated and long (such as 3.14159 or 0xCAFEBABE).

// Good to Know
// Not all numbers are magical.
// If the purpose of a number is obvious, there’s no need to replace it. A classic example is:
// for (i = 0; i < сount; i++) { ... }
