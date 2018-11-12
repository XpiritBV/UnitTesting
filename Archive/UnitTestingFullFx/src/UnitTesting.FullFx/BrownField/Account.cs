using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting.FullFx.BrownField
{
    public class Account
    {
        public Account(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            CreditTransactionHandler = new CreditTransactionHandler(this);
            DebitTransactionHandler = new DebitTransactionHandler(this);
            Name = name;
        }

        public string Name { get; }

        public IReadOnlyList<Transaction> Transactions { get; set; } = new List<Transaction>();

        public CreditTransactionHandler CreditTransactionHandler { get; }

        public DebitTransactionHandler DebitTransactionHandler { get; }

        public double Balance
        {
            get
            {
                return Transactions.Where(t => t.TransactionType == TransactionType.Debit).Sum(t => t.Amount) - Transactions.Where(t => t.TransactionType == TransactionType.Credit).Sum(t => t.Amount);
            }
        }
    }
}
