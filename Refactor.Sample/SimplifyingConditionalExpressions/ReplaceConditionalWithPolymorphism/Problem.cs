using System;

namespace Refactor.Sample.SimplifyingConditionalExpressions.ReplaceConditionalWithPolymorphism
{
    public class Problem
    {
        public class Bird
        {
            public BirdType Type { get; set; }
            public double Voltage { get; private set; }
            public bool IsNailed { get; private set; }
            public int NumberOfCoconuts { get; private set; }

            public double GetSpeed()
            {
                switch (Type)
                {
                    case BirdType.EUROPEAN:
                        return GetBaseSpeed();
                    case BirdType.AFRICAN:
                        return GetBaseSpeed() - GetLoadFactor() * NumberOfCoconuts;
                    case BirdType.NORWEGIAN_BLUE:
                        return IsNailed ? 0 : GetBaseSpeed(Voltage);
                    default:
                        throw new Exception("Should be unreachable");
                }
            }

            private int GetLoadFactor()
            {
                throw new NotImplementedException();
            }

            private double GetBaseSpeed(double voltage = 0)
            {
                throw new NotImplementedException();
            }
        }

        public enum BirdType
        {
            EUROPEAN, AFRICAN, NORWEGIAN_BLUE
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