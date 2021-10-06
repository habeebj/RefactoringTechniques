using System;

namespace Refactor.Sample.SimplifyingConditionalExpressions.ReplaceConditionalWithPolymorphism
{
    public class Solution
    {
        public abstract class Bird
        {
            public abstract double GetSpeed();
            protected double GetBaseSpeed(double voltage = 0)
            {
                throw new NotImplementedException();
            }
        }

        public class European : Bird
        {
            public override double GetSpeed() => GetBaseSpeed();
        }

        public class African : Bird
        {
            public readonly int _numberOfCoconuts;
            private double GetLoadFactor() => 10;
            public African(int numberOfCoconuts)
            {
                _numberOfCoconuts = numberOfCoconuts;
            }
            public override double GetSpeed() => GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts;
        }

        public class NorwegianBlue : Bird
        {
            private readonly bool _isNailed;
            private readonly int _voltage;


            public NorwegianBlue(bool isNailed, int voltage)
            {
                _isNailed = isNailed;
                _voltage = voltage;
            }

            public override double GetSpeed()
            {
                return _isNailed ? 0 : GetBaseSpeed(_voltage);
            }
        }
    }
}

// Problem
// You have a conditional that performs various actions depending on object type or properties.

// Solution
// Create subclasses matching the branches of the conditional. In them, create a shared method and move code from the corresponding branch of the conditional to it. Then replace the conditional with the relevant method call. The result is that the proper implementation will be attained via polymorphism depending on the object class.

// Why Refactor
// This refactoring technique can help if your code contains operators performing various tasks that vary based on:

// - Class of the object or interface that it implements

// - Value of an object’s field

// - Result of calling one of an object’s methods

// If a new object property or type appears, you will need to search for and add code in all similar conditionals. Thus the benefit of this technique is multiplied if there are multiple conditionals scattered throughout all of an object’s methods.