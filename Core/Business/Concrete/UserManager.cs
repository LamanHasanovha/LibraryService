using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;

namespace Core.Business.Concrete
{
    public class UserManager : ManagerRepositoryBase<User, IUserRepository>, IUserService
    {
        public UserManager(IUserRepository repository) : base(repository)
        {
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return Repository.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return Repository.Get(u => u.Email == email);
        }
    }
}
