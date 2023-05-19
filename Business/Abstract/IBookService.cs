﻿using Core.Business.Abstract;
using Entities.Concrete;
using Entities.Models.ResponseModels;

namespace Business.Abstract
{
    public interface IBookService : IExtendedServiceRepository<Book>
    {
        Task<BookResponseModel> GetBookById(int id);
        Task<List<BookResponseModel>> GetBooks();
        Task<List<Book>> GetByAuthor(int id);
        Task<BookResponseModel> GetRandomBook();
    }
}
