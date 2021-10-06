using static Refactor.Sample.Organizing_Data.ReplaceTypeCodeWithStateAndStrategy.Solution;

namespace Refactor.Sample.Organizing_Data.ReplaceTypeCodeWithStateAndStrategy
{
    public class Client
    {
        void Main()
        {
            var account = new Account("1245367", false) { State = new Closed(), CurrentBalance = 100 };
            account.Withdraw(30);
        }
    }
}