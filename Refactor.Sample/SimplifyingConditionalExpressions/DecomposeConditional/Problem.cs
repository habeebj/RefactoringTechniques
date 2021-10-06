using System;

namespace Refactor.Sample.SimplifyingConditionalExpressions.DecomposeConditional
{
    public class Problem
    {
        private const double SUMMERRATE = 0.6;
        private DateTime SUMMER_START = DateTime.Now.Subtract(TimeSpan.FromDays(10));
        private DateTime SUMMER_END = DateTime.Now;

        public int Quantity { get; private set; }
        public int WinterRate { get; private set; }
        public int WinterServiceCharge { get; private set; }

        public double GetCharges(DateTime date)
        {
            double charge;

            if (date < SUMMER_START || date > SUMMER_END)
            {
                charge = Quantity * WinterRate + WinterServiceCharge;
            }
            else
            {
                charge = Quantity * SUMMERRATE;
            }
            
            return charge;
        }
    }
}

// Problem
// You have a complex conditional (if-then/else or switch).

// Solution
// Decompose the complicated parts of the conditional into separate methods: the condition, then and else.

// Why Refactor
// The longer a piece of code is, the harder it’s to understand. Things become even more hard to understand when the code is filled with conditions:

// While you’re busy figuring out what the code in the then block does, you forget what the relevant condition was.

// While you’re busy parsing else, you forget what the code in then does.

// Benefit
// By extracting conditional code to clearly named methods, you make life easier for the person who’ll be maintaining the code later (such as you, two months from now!).