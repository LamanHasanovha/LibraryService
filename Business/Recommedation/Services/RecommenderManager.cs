using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;

namespace Business.Recommedation.Services
{
    public class RecommenderManager : IRecommenderService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IItemBasedFilteringRepository _itemBasedFilteringRepository;
        private readonly IUserBasedFilteringRepository _userBasedFilteringRepository;
        private readonly IAccountRepository _accountRepository;

        public RecommenderManager(IRatingRepository ratingRepository, IActivityRepository activityRepository, IPurchaseRepository purchaseRepository, IItemBasedFilteringRepository itemBasedFilteringRepository, IUserBasedFilteringRepository userBasedFilteringRepository, IBookRepository bookRepository, IMovieRepository movieRepository, IAccountRepository accountRepository)
        {
            _ratingRepository = ratingRepository;
            _activityRepository = activityRepository;
            _purchaseRepository = purchaseRepository;
            _itemBasedFilteringRepository = itemBasedFilteringRepository;
            _userBasedFilteringRepository = userBasedFilteringRepository;
            _bookRepository = bookRepository;
            _movieRepository = movieRepository;
            _accountRepository = accountRepository;
        }

        public async Task<List<Book>> GetBooks(int bookId, int count) // item-based collaborative filtering
        {
            var bookIds = (await _itemBasedFilteringRepository
                .GetAllAsync(i => (i.ItemOneId == bookId | i.ItemTwoId == bookId) & i.ItemType == ProductTypes.Book))
                .OrderByDescending(i => i.Similarity).Take(count);
            var result = new List<int>();

            foreach (var item in bookIds)
            {
                if (item.ItemOneId == bookId)
                    result.Add(item.ItemTwoId);
                else
                    result.Add(item.ItemOneId);
            }

            var books = await _bookRepository.GetByIds(result);

            var purchases = (await _purchaseRepository.GetAllAsync(p => p.ProductType == ProductTypes.Book)).GroupBy(p => p.RecordId).OrderByDescending(p => p.Count()).ToList();

            foreach (var group in purchases)
            {
                if (books.Select(b => b.Id).ToList().Contains(group.FirstOrDefault().RecordId))
                    continue;

                books.Add(await _bookRepository.GetAsync(b => b.Id == group.FirstOrDefault().RecordId));

                if (books.Count == count)
                    return books;
            }

            var activities = (await _activityRepository.GetAllAsync(a => a.ProductType == ProductTypes.Book)).GroupBy(a => a.RecordId).OrderByDescending(a => a.Count()).ToList();

            foreach (var group in activities)
            {
                if (books.Select(b => b.Id).ToList().Contains(group.FirstOrDefault().RecordId))
                    continue;

                books.Add(await _bookRepository.GetAsync(b => b.Id == group.FirstOrDefault().RecordId));

                if (books.Count == count)
                    return books;
            }

            books.AddRange(await _bookRepository.GetSameGenre(bookId, count - books.Count));

            return books;
        }

        public async Task<List<Book>> GetBooksByAccount(int accountId, int count) // user-based collaborative filtering
        {
            var result = new List<Book>();
            var userBased = (await _userBasedFilteringRepository.GetAllAsync(u => u.UserOneId == accountId | u.UserTwoId == accountId)).OrderByDescending(u => u.SimilarityForBook);

            foreach (var item in userBased)
            {
                var similarAcc = item.UserOneId == accountId ? item.UserTwoId : item.UserOneId;
                var currentRecs = await _ratingRepository.GetAllAsync(r => r.AccountId == accountId & r.Type == RatingTypes.Book & r.Value >= 3);
                var similarRecs = await _ratingRepository.GetAllAsync(r => r.AccountId == similarAcc & r.Type == RatingTypes.Book & r.Value >= 3);

                var recordIds = similarRecs.Select(s => s.RecordId).ToList();

                foreach (var rec in currentRecs)
                {
                    recordIds.RemoveAll(i => i == rec.RecordId);
                }

                foreach (var id in recordIds)
                {
                    result.Add(await _bookRepository.GetAsync(b => b.Id == id));
                    if (result.Count == count)
                        return result;
                }
            }

            var purchases = (await _purchaseRepository.GetAllAsync(p => p.ProductType == ProductTypes.Book)).GroupBy(p => p.RecordId).OrderByDescending(p => p.Count()).ToList();

            foreach (var group in purchases)
            {
                if (result.Select(b => b.Id).ToList().Contains(group.FirstOrDefault().RecordId))
                    continue;

                result.Add(await _bookRepository.GetAsync(b => b.Id == group.FirstOrDefault().RecordId));

                if (result.Count == count)
                    return result;
            }

            var activities = (await _activityRepository.GetAllAsync(a => a.ProductType == ProductTypes.Book)).GroupBy(a => a.RecordId).OrderByDescending(a => a.Count()).ToList();

            foreach (var group in activities)
            {
                if (result.Select(b => b.Id).ToList().Contains(group.FirstOrDefault().RecordId))
                    continue;

                result.Add(await _bookRepository.GetAsync(b => b.Id == group.FirstOrDefault().RecordId));

                if (result.Count == count)
                    return result;
            }

            return result;
        }

        public async Task<List<Movie>> GetMovies(int movieId, int count) // item-based collaborative filtering
        {
            var bookIds = (await _itemBasedFilteringRepository
                .GetAllAsync(i => (i.ItemOneId == movieId | i.ItemTwoId == movieId) & i.ItemType == ProductTypes.Movie))
                .OrderByDescending(i => i.Similarity).Take(count);
            var result = new List<int>();

            foreach (var item in bookIds)
            {
                if (item.ItemOneId == movieId)
                    result.Add(item.ItemTwoId);
                else
                    result.Add(item.ItemOneId);
            }

            var movies = await _movieRepository.GetByIds(result);

            var purchases = (await _purchaseRepository.GetAllAsync(p => p.ProductType == ProductTypes.Movie)).GroupBy(p => p.RecordId).OrderByDescending(p => p.Count()).ToList();

            foreach (var group in purchases)
            {
                if (movies.Select(b => b.Id).ToList().Contains(group.FirstOrDefault().RecordId))
                    continue;

                movies.Add(await _movieRepository.GetAsync(b => b.Id == group.FirstOrDefault().RecordId));

                if (movies.Count == count)
                    return movies;
            }

            var activities = (await _activityRepository.GetAllAsync(a => a.ProductType == ProductTypes.Book)).GroupBy(a => a.RecordId).OrderByDescending(a => a.Count()).ToList();

            foreach (var group in activities)
            {
                if (movies.Select(b => b.Id).ToList().Contains(group.FirstOrDefault().RecordId))
                    continue;

                movies.Add(await _movieRepository.GetAsync(b => b.Id == group.FirstOrDefault().RecordId));

                if (movies.Count == count)
                    return movies;
            }

            movies.AddRange(await _movieRepository.GetSameGenre(movieId, count - movies.Count));

            return movies;
        }

        public async Task<List<Movie>> GetMoviesByAccount(int accountId, int count) // user-based collaborative filtering
        {
            var result = new List<Movie>();
            var userBased = (await _userBasedFilteringRepository.GetAllAsync(u => u.UserOneId == accountId | u.UserTwoId == accountId)).OrderByDescending(u => u.SimilarityForMovie);

            foreach (var item in userBased)
            {
                var similarAcc = item.UserOneId == accountId ? item.UserTwoId : item.UserOneId;
                var currentRecs = await _ratingRepository.GetAllAsync(r => r.AccountId == accountId & r.Type == RatingTypes.Movie & r.Value >= 3);
                var similarRecs = await _ratingRepository.GetAllAsync(r => r.AccountId == similarAcc & r.Type == RatingTypes.Movie & r.Value >= 3);

                var recordIds = similarRecs.Select(s => s.RecordId).ToList();

                foreach (var rec in currentRecs)
                {
                    recordIds.RemoveAll(i => i == rec.RecordId);
                }

                foreach (var id in recordIds)
                {
                    result.Add(await _movieRepository.GetAsync(b => b.Id == id));
                    if (result.Count == count)
                        return result;
                }
            }

            var purchases = (await _purchaseRepository.GetAllAsync(p => p.ProductType == ProductTypes.Movie)).GroupBy(p => p.RecordId).OrderByDescending(p => p.Count()).ToList();

            foreach (var group in purchases)
            {
                if (result.Select(b => b.Id).ToList().Contains(group.FirstOrDefault().RecordId))
                    continue;

                result.Add(await _movieRepository.GetAsync(b => b.Id == group.FirstOrDefault().RecordId));

                if (result.Count == count)
                    return result;
            }

            var activities = (await _activityRepository.GetAllAsync(a => a.ProductType == ProductTypes.Book)).GroupBy(a => a.RecordId).OrderByDescending(a => a.Count()).ToList();

            foreach (var group in activities)
            {
                if (result.Select(b => b.Id).ToList().Contains(group.FirstOrDefault().RecordId))
                    continue;

                result.Add(await _movieRepository.GetAsync(b => b.Id == group.FirstOrDefault().RecordId));

                if (result.Count == count)
                    return result;
            }

            return result;
        }

        public async Task TrainItems()
        {
            // Books
            var books = await _bookRepository.GetAllAsync();
            var bookItems = new List<ItemBasedFiltering>();
            for (int i = 0; i < books.Count - 1; i++)
            {
                for (int j = i + 1; j < books.Count; j++)
                {
                    var ratings = await _ratingRepository.GetAllAsync(r => (r.RecordId == books[i].Id | r.RecordId == books[j].Id) & r.Type == RatingTypes.Book);
                    var accounts = ratings.Select(r => r.AccountId).Distinct().ToList();
                    foreach (var account in accounts)
                    {
                        if (ratings.Where(r => r.AccountId == account).Count() < 2)
                            ratings.RemoveAll(r => r.AccountId == account);
                    }

                    if (ratings.Count > 2)
                    {
                        var bookItem = new ItemBasedFiltering
                        {
                            ItemOneId = books[i].Id,
                            ItemTwoId = books[j].Id,
                            ItemType = ProductTypes.Book,
                            Similarity = ComputeSimilarity
                                            (ratings.Where(r => r.RecordId == books[i].Id).Select(r => r.Value).ToArray(),
                                             ratings.Where(r => r.RecordId == books[j].Id).Select(r => r.Value).ToArray())
                        };

                        bookItems.Add(bookItem);
                        //await _itemBasedFilteringRepository.AddAsync(bookItem);
                    }
                }
            }

            var allBookRatings = await _ratingRepository.GetAllAsync(r => r.Type == RatingTypes.Book);
            var allAccounts = await _accountRepository.GetAllAsync(a => a.Status == true);
            var computedBookRatings = new List<Rating>();
            for (var i = 0; i < allAccounts.Count; i++)
            {
                for (int j = 0; j < books.Count; j++)
                {
                    if (allBookRatings.Any(r => r.AccountId == allAccounts[i].Id & r.RecordId == books[j].Id))
                        continue;

                    var filteredRatingList = allBookRatings.Where(r => r.AccountId == allAccounts[i].Id).ToList();
                    double numerator = 0, denominator = 0;
                    for (int k = 0; k < books.Count; k++)
                    {
                        if (k == j | allBookRatings.FirstOrDefault(rating => rating.AccountId == allAccounts[i].Id & rating.RecordId == books[k].Id) == null)
                            continue;
                        var similarity = bookItems.FirstOrDefault(b => b.ItemOneId == Math.Min(books[j].Id, books[k].Id) & b.ItemTwoId == Math.Max(books[j].Id, books[k].Id)) ?? new ItemBasedFiltering { Similarity = 0 };
                        denominator += similarity.Similarity;
                        var temp = allBookRatings.FirstOrDefault(rating => rating.AccountId == allAccounts[i].Id & rating.RecordId == books[k].Id);
                        numerator += similarity.Similarity * (temp is null ? 0 : temp.Value);
                    }

                    var generatedRating = new Rating
                    {
                        AccountId = allAccounts[i].Id,
                        Type = RatingTypes.Book,
                        RecordId = books[j].Id,
                        Value = denominator == 0 ? 0 : (int)Math.Round(numerator / denominator)
                    };
                    if (generatedRating.Value == 0)
                        continue;
                    computedBookRatings.Add(generatedRating);
                    await _ratingRepository.AddAsync(generatedRating);
                }
            }

            for (int i = 0; i < books.Count - 1; i++)
            {
                for (int j = i + 1; j < books.Count; j++)
                {
                    if (bookItems.Any(item => item.ItemOneId == books[i].Id & item.ItemTwoId == books[j].Id))
                        continue;

                    var ratings = await _ratingRepository.GetAllAsync(r => (r.RecordId == books[i].Id | r.RecordId == books[j].Id) & r.Type == RatingTypes.Book);
                    var accounts = ratings.Select(r => r.AccountId).Distinct().ToList();
                    foreach (var account in accounts)
                    {
                        if (ratings.Where(r => r.AccountId == account).Count() < 2)
                            ratings.RemoveAll(r => r.AccountId == account);
                    }

                    if (ratings.Count > 2)
                    {
                        var bookItem = new ItemBasedFiltering
                        {
                            ItemOneId = books[i].Id,
                            ItemTwoId = books[j].Id,
                            ItemType = ProductTypes.Book,
                            Similarity = ComputeSimilarity
                                            (ratings.Where(r => r.RecordId == books[i].Id).Select(r => r.Value).ToArray(),
                                             ratings.Where(r => r.RecordId == books[j].Id).Select(r => r.Value).ToArray())
                        };

                        bookItems.Add(bookItem);
                        //await _itemBasedFilteringRepository.AddAsync(bookItem);
                    }
                }
            }

            foreach (var item in bookItems)
            {
                await _itemBasedFilteringRepository.AddAsync(item); // if it exists should be update 
            }

            // Movies
            var movies = await _movieRepository.GetAllAsync();
            var movieItems = new List<ItemBasedFiltering>();
            for (int i = 0; i < movies.Count - 1; i++)
            {
                for (int j = i + 1; j < movies.Count; j++)
                {
                    var ratings = await _ratingRepository.GetAllAsync(r => (r.RecordId == movies[i].Id | r.RecordId == movies[j].Id) & r.Type == RatingTypes.Movie);
                    var accounts = ratings.Select(r => r.AccountId).Distinct().ToList();
                    foreach (var account in accounts)
                    {
                        if (ratings.Where(r => r.AccountId == account).Count() < 2)
                            ratings.RemoveAll(r => r.AccountId == account);
                    }

                    if (ratings.Count > 2)
                    {
                        var movieItem = new ItemBasedFiltering
                        {
                            ItemOneId = books[i].Id,
                            ItemTwoId = books[j].Id,
                            ItemType = ProductTypes.Movie,
                            Similarity = ComputeSimilarity
                                            (ratings.Where(r => r.RecordId == books[i].Id).Select(r => r.Value).ToArray(),
                                             ratings.Where(r => r.RecordId == books[j].Id).Select(r => r.Value).ToArray())
                        };

                        movieItems.Add(movieItem);
                    }
                }
            }

            var allMovieRatings = await _ratingRepository.GetAllAsync(r => r.Type == RatingTypes.Movie);
            var computedMovieRatings = new List<Rating>();
            for (int i = 0; i < allAccounts.Count; i++)
            {
                for (int j = 0; j < movies.Count; j++)
                {
                    if (allMovieRatings.Any(r => r.AccountId == allAccounts[i].Id & r.RecordId == movies[j].Id))
                        continue;

                    var filteredRatingList = allMovieRatings.Where(r => r.AccountId == allAccounts[i].Id).ToList();
                    double numerator = 0, denominator = 0;
                    for (int k = 0; k < movies.Count; k++)
                    {
                        if (k == j)
                            continue;
                        var similarity = movieItems.FirstOrDefault(m => m.ItemOneId == Math.Min(movies[j].Id, movies[k].Id) & m.ItemTwoId == Math.Max(movies[j].Id, movies[k].Id)) ?? new ItemBasedFiltering { Similarity = 0 };
                        denominator += similarity.Similarity;
                        var temp = allMovieRatings.FirstOrDefault(rating => rating.AccountId == allAccounts[i].Id & rating.RecordId == movies[k].Id);
                        numerator += similarity.Similarity * (temp is null ? 0 : temp.Value);
                    }

                    var generatedRating = new Rating
                    {
                        AccountId = allAccounts[i].Id,
                        Type = RatingTypes.Movie,
                        RecordId = movies[j].Id,
                        Value = denominator == 0 ? 0 : (int)Math.Round(numerator / denominator)
                    };
                    if (generatedRating.Value == 0)
                        continue;
                    computedMovieRatings.Add(generatedRating);
                    await _ratingRepository.AddAsync(generatedRating);
                }
            }

            for (int i = 0; i < movies.Count - 1; i++)
            {
                for (int j = i + 1; j < movies.Count; j++)
                {
                    var ratings = await _ratingRepository.GetAllAsync(r => (r.RecordId == movies[i].Id | r.RecordId == movies[j].Id) & r.Type == RatingTypes.Movie);
                    var accounts = ratings.Select(r => r.AccountId).Distinct().ToList();
                    foreach (var account in accounts)
                    {
                        if (ratings.Where(r => r.AccountId == account).Count() < 2)
                            ratings.RemoveAll(r => r.AccountId == account);
                    }

                    if (ratings.Count > 2)
                    {
                        var movieItem = new ItemBasedFiltering
                        {
                            ItemOneId = books[i].Id,
                            ItemTwoId = books[j].Id,
                            ItemType = ProductTypes.Movie,
                            Similarity = ComputeSimilarity
                                            (ratings.Where(r => r.RecordId == books[i].Id).Select(r => r.Value).ToArray(),
                                             ratings.Where(r => r.RecordId == books[j].Id).Select(r => r.Value).ToArray())
                        };

                        movieItems.Add(movieItem);
                    }
                }
            }

            foreach (var item in movieItems)
            {
                await _itemBasedFilteringRepository.AddAsync(item); // if it exists should be update
            }
        }

        public async Task TrainUsers()
        {
            var userFiltering = new List<UserBasedFiltering>();
            var accounts = await _accountRepository.GetAllAsync(a => a.Status == true);

            for (int i = 0; i < accounts.Count; i++)
            {
                for (int j = i + 1; j < accounts.Count; j++)
                {
                    var bookRatings = await _ratingRepository.GetAllAsync(r => (r.AccountId == accounts[i].Id | r.AccountId == accounts[j].Id) & r.Type == RatingTypes.Book);
                    var books = bookRatings.Select(r => r.RecordId).Distinct().ToList();
                    foreach (var book in books)
                    {
                        if (bookRatings.Where(r => r.RecordId == book).Count() < 2)
                            bookRatings.RemoveAll(r => r.RecordId == book);
                    }
                    var userOneBook = bookRatings.Where(r => r.AccountId == accounts[i].Id);
                    var avgOfUserOneBook = userOneBook.Any() == false ? 0 : userOneBook.Select(r => r.Value).Average();
                    var userTwoBook= bookRatings.Where(r => r.AccountId == accounts[j].Id);
                    var avgOfUserTwoBook = userTwoBook.Any() == false ? 0 : userTwoBook.Select(r => r.Value).Average();

                    var userOneBookRatings = bookRatings.Where(r => r.AccountId == accounts[i].Id).Select(r => { r.Value -= avgOfUserOneBook; return r; }).ToList();
                    var userTwoBookRatings = bookRatings.Where(r => r.AccountId == accounts[j].Id).Select(r => { r.Value -= avgOfUserTwoBook; return r; }).ToList();

                    var movieRatings = await _ratingRepository.GetAllAsync(r => (r.AccountId == accounts[i].Id | r.AccountId == accounts[j].Id) & r.Type == RatingTypes.Movie);
                    var movies = movieRatings.Select(r => r.RecordId).Distinct().ToList();
                    foreach (var movie in movies)
                    {
                        if (movieRatings.Where(r => r.RecordId == movie).Count() < 2)
                            movieRatings.RemoveAll(r => r.RecordId == movie);
                    }
                    var userOneMovie = movieRatings.Where(r => r.AccountId == accounts[i].Id);
                    var avgOfUserOneMovie = userOneMovie.Any() == false ? 0 : userOneMovie.Select(r => r.Value).Average();
                    var userTwoMovie = movieRatings.Where(r => r.AccountId == accounts[j].Id);
                    var avgOfUserTwoMovie = userTwoMovie.Any() == false ? 0 : userTwoMovie.Select(r => r.Value).Average();

                    var userOneMovieRatings = movieRatings.Where(r => r.AccountId == accounts[i].Id).Select(r => { r.Value -= avgOfUserOneMovie; return r; }).ToList();
                    var userTwoMovieRatings = movieRatings.Where(r => r.AccountId == accounts[j].Id).Select(r => { r.Value -= avgOfUserTwoMovie; return r; }).ToList();

                    var userItem = new UserBasedFiltering
                    {
                        UserOneId = accounts[i].Id,
                        UserTwoId = accounts[j].Id,
                        SimilarityForMovie = ComputeSimilarity(userOneMovieRatings, userTwoMovieRatings),
                        SimilarityForBook = ComputeSimilarity(userOneBookRatings, userTwoBookRatings)
                    };
                    if (double.IsNaN(userItem.SimilarityForBook))
                        userItem.SimilarityForBook = 0;
                    if(double.IsNaN(userItem.SimilarityForMovie)) 
                        userItem.SimilarityForMovie = 0;
                    userFiltering.Add(userItem);
                }
            }

            await _userBasedFilteringRepository.DeleteAllAsync();
            foreach (var item in userFiltering)
            {
                await _userBasedFilteringRepository.AddAsync(item);
            }
        }

        private double ComputeSimilarity(List<Rating> userOne, List<Rating> userTwo)
        {
            double numerator = 0, denominator = 0;
            for (int i = 0; i < userOne.Count; i++)
            {
                numerator += userOne[i].Value * userTwo[i].Value;
            }

            denominator = Math.Sqrt(userOne.Select(r => Math.Pow(r.Value, 2)).Sum()) * Math.Sqrt(userTwo.Select(r => Math.Pow(r.Value, 2)).Sum());

            return numerator / denominator;
        }

        private double ComputeSimilarity(double[] vector1, double[] vector2)
        {
            double result = MultiplyVectors(vector1, vector2) / (AbsVector(vector1) * AbsVector(vector2));

            return result;
        }

        private double MultiplyVectors(double[] vector1, double[] vector2)
        {
            double result = 0;

            for (int i = 0; i < vector1.Length; i++)
            {
                result += vector1[i] * vector2[i];
            }

            return result;
        }

        private double AbsVector(double[] vector)
        {
            double result = 0;

            foreach (var item in vector)
            {
                result += Math.Pow(item, 2);
            }

            return Math.Sqrt(result);
        }
    }
}
