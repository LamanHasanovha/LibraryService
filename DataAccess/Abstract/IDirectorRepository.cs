﻿using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IDirectorRepository : IExtendedRepository<Director>
    {
        Task<Director> GetRandomDirector();
    }
}
