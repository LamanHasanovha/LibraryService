using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LanguageManager : ManagerRepositoryBase<Language, ILanguageRepository>, ILanguageService
    {
        public LanguageManager(ILanguageRepository repository) : base(repository)
        {
            //base.SetValidator(new LanguageValidator());
        }
    }
}
