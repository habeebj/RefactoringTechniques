namespace Refactor.Sample.SimplifyingMethodCall.ReplaceConstructorWithFactoryMethod
{
    public class Solution
    {
        public class Employee
        {
            private readonly int _type;

            private Employee(int type)
            {
                this._type = type;
            }
            public static Employee Create(int type)
            {
                var employee = new Employee(type);
                // Do some heavy lifting.
                return employee;
            }
        }
    }
}
// Problem
// You have a complex constructor that does something more than just setting parameter values in object fields.

// Solution
// Create a factory method and use it to replace constructor calls.

