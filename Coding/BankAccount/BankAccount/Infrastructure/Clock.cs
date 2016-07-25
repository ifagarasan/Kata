using BankAccount.Infrastructure.Repository;

namespace BankAccount.Infrastructure
{
    public interface Clock
    {
        Date Today();
    }
}