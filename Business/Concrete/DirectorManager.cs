using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DirectorManager : ManagerRepositoryBase<Director, IDirectorRepository>, IDirectorService
    {
        public DirectorManager(IDirectorRepository repository) : base(repository)
        {
            //base.SetValidator(new DirectorValidator());
        }
    }
}
