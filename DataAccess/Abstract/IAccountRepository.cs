using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAccountRepository : IExtendedRepository<Account>
    {
    }
}
