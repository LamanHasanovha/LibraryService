using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Concrete
{
    public class MovieFavListManager : ManagerRepositoryBase<MovieFavList, IMovieFavListRepository>, IMovieFavListService
    {
        public MovieFavListManager(IMovieFavListRepository repository) : base(repository)
        {
            //base.SetValidator(new MovieFavListValidator());
        }

        public async Task<List<MovieResponseModel>> GetByAccount(int id)
        {
            return await Repository.GetByAccount(id);
        }

        public async Task RemoveByAccount(int accountId, int movieId)
        {
            var result = await Repository.GetAsync(l => l.AccountId == accountId & l.MovieId == movieId);

            await Repository.DeleteAsync(result);
        }
    }
}
