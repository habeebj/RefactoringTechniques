namespace Refactor.Sample.SimplifyingMethodCall.ReplaceConstructorWithFactoryMethod
{
    public class Problem
    {
        public class Employee
        {
            private readonly int _type;

            public Employee(int type)
            {
                this._type = type;
            }
        }
    }
}
// Problem
// You have a complex constructor that does something more than just setting parameter values in object fields.

// Solution
// Create a factory method and use it to replace constructor calls.