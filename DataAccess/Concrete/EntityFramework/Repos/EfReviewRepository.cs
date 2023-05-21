﻿using Core.DataAccess.Repositories.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repos
{
    public class EfReviewRepository : EfRepositoryBase<Review, LibraryContext>, IReviewRepository
    {
        public EfReviewRepository(LibraryContext context) : base(context)
        {
        }
    }
}
