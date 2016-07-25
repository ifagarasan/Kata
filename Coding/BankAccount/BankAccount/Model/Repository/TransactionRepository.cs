namespace BankAccount.Model.Repository
{
    public interface TransactionRepository
    {
        void AddDeposit(int amount);
        void AddWithdraw(int amount);
        Transactions Transactions();
    }
}