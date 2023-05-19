using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthorManager : ManagerRepositoryBase<Author, IAuthorRepository>, IAuthorService
    {
        public AuthorManager(IAuthorRepository repository) : base(repository)
        {
            //base.SetValidator(new AuthorValidator());
        }
    }
}
