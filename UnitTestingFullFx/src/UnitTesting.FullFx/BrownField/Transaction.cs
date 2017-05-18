namespace UnitTesting.FullFx.BrownField
{
    public class Transaction
    {
        public Transaction(TransactionType transactionType, double amount)
        {
            Amount = amount;
            TransactionType = transactionType;
        }

        public double Amount { get; }

        public TransactionType TransactionType { get;  }
    }
}
