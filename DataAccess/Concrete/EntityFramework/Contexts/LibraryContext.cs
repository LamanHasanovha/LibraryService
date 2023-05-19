using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class LibraryContext : DbContext
    {
        protected IConfiguration Configuration { get; }

        #region DbSet

        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BookWishList> BookWishLists { get; set; }
        public DbSet<MovieWishList> MovieWishLists { get; set; }
        public DbSet<BookFavList> BookFavLists { get; set; }
        public DbSet<MovieFavList> MovieFavLists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<BookGenreList> BookGenreLists { get; set; }
        public DbSet<MovieGenreList> MovieGenreLists { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MenuContent> MenuContents { get; set; }
        public DbSet<MenuObject> MenuObjects { get; set; }

        #endregion

        public LibraryContext(DbContextOptions<LibraryContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
        }
    }
}
