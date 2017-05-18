using System.Collections.Generic;

namespace UnitTesting.FullFx.BrownField
{
    public class BookKeeping
    {
        public List<Account> Accounts { get; private set; } = new List<Account>();

        public Account AddAccount(string name)
        {
            var acc = new Account(name);
            Accounts.Add(acc);
            return acc;
        }
    }
}
