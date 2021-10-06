using System;

namespace Refactor.Sample.SimplifyingConditionalExpressions.DecomposeConditional
{
    public class Solution
    {
        private const double SUMMER_RATE = 0.6;
        private DateTime SUMMER_START = DateTime.Now.Subtract(TimeSpan.FromDays(10));
        private DateTime SUMMER_END = DateTime.Now;

        public int Quantity { get; private set; }
        public int WINTER_RATE { get; private set; }
        public int WinterServiceCharge { get; private set; }

        public double GetCharges(DateTime date)
        {
            return IsSummer(date) ? SummerCharge() : WinterCharge();
            // double charge;

            // if (IsSummer(Date))
            // {
            //     charge = SummerServiceCharge();
            // }
            // else
            // {
            //     charge = WinterCharge();
            // }

            // return charge;
        }

        private bool IsSummer(DateTime date)
        {
            return date < SUMMER_START || date > SUMMER_END;
        }

        private double SummerCharge()
        {
            return Quantity * SUMMER_RATE;
        }

        private int WinterCharge()
        {
            return Quantity * WINTER_RATE + WinterServiceCharge;
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