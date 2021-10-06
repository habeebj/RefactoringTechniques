using static Refactor.Sample.SimplifyingConditionalExpressions.ReplaceConditionalWithPolymorphism.Solution;

namespace Refactor.Sample.SimplifyingConditionalExpressions.ReplaceConditionalWithPolymorphism
{
    public class Clients
    {
        void Main()
        {
            var bird = new African(40);
            bird.GetSpeed();
        }
    }
}