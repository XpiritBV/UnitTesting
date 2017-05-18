using System;
using System.Collections.Generic;

namespace UnitTesting.FullFx.BrownField
{
    public abstract class TransactionHandler
    {
        private Account account;

        public TransactionHandler(Account account)
        {
            this.account = account ?? throw new System.ArgumentNullException(nameof(account));
        }

        public Transaction AddTransaction(double amount)
        {
            //violation 1
            if (this is CreditTransactionHandler)
            {
                //violation 2
                var tran = new Transaction(TransactionType.Credit, amount);
                ((List<Transaction>)account.Transactions).Add(new Transaction(TransactionType.Credit, amount));
                return tran;
            }
            else if (this is DebitTransactionHandler)
            {
                //violation 2
                var tran = new Transaction(TransactionType.Credit, amount);
                ((List<Transaction>)account.Transactions).Add(new Transaction(TransactionType.Debit, amount));
                return tran;
            }

            throw new InvalidOperationException("No known handler");
        }
    }
}