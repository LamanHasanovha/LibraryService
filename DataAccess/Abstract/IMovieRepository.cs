﻿using Core.DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IMovieRepository : IExtendedRepository<Movie>
    {
        Task<List<Movie>> GetByActor(int actorId);
        Task<List<Movie>> GetByIds(List<int> result);
        Task<string> GetMaxMinValue();
        Task<List<MovieResponseModel>> GetMovies(Expression<Func<Movie, bool>> predicate = null);
        Task<List<MovieResponseModel>> GetPopularMovies();
        Task<MovieResponseModel> GetRandomMovie();
        Task<List<Movie>> GetSameGenre(int movieId, int count);
    }
}
