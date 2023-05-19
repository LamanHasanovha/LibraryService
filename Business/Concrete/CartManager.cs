using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.Models.ResponseModels;

namespace Business.Concrete
{
    public class CartManager : ManagerRepositoryBase<Cart, ICartRepository>, ICartService
    {
        public CartManager(ICartRepository repository) : base(repository)
        {
            //base.SetValidator(new CartValidator());
        }

        public async Task<bool> Check(int accountId, int recordId, ProductTypes type)
        {
            var result = await Repository.GetAllAsync(c => c.AccountId == accountId & c.RecordId == recordId & c.Type == type);

            return result.Any();
        }

        public Task<List<CartResponseModel>> GetByAccount(int id)
        {
            return Repository.GetByAccount(id);
        }

        public async Task RemoveByAccount(int accountId, int recordId, ProductTypes type)
        {
            var result = await Repository.GetAsync(c => c.AccountId == accountId & c.RecordId == recordId & c.Type == type);

            await Repository.DeleteAsync(result);
        }
    }
}
