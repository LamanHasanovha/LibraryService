using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Features.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Repos;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region DataAccess

            builder.RegisterType<EfBookRepository>().As<IBookRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfMovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfBookGenreRepository>().As<IBookGenreRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfMovieGenreRepository>().As<IMovieGenreRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfLanguageRepository>().As<ILanguageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfAccountRepository>().As<IAccountRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfBookWishListRepository>().As<IBookWishListRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfMovieWishListRepository>().As<IMovieWishListRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfBookFavListRepository>().As<IBookFavListRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfMovieFavListRepository>().As<IMovieFavListRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfCartRepository>().As<ICartRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfBookGenreListRepository>().As<IBookGenreListRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfMovieGenreListRepository>().As<IMovieGenreListRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfDirectorRepository>().As<IDirectorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfAuthorRepository>().As<IAuthorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfActorRepository>().As<IActorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfMovieActorRepository>().As<IMovieActorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfMenuContentRepository>().As<IMenuContentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfMenuObjectRepository>().As<IMenuObjectRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfRatingRepository>().As<IRatingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfReviewRepository>().As<IReviewRepository>().InstancePerLifetimeScope();

            #endregion

            #region Business

            builder.RegisterType<BookManager>().As<IBookService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieManager>().As<IMovieService>().InstancePerLifetimeScope();
            builder.RegisterType<BookGenreManager>().As<IBookGenreService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieGenreManager>().As<IMovieGenreService>().InstancePerLifetimeScope();
            builder.RegisterType<LanguageManager>().As<ILanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<AccountManager>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<BookWishListManager>().As<IBookWishListService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieWishListManager>().As<IMovieWishListService>().InstancePerLifetimeScope();
            builder.RegisterType<BookFavListManager>().As<IBookFavListService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieFavListManager>().As<IMovieFavListService>().InstancePerLifetimeScope();
            builder.RegisterType<CartManager>().As<ICartService>().InstancePerLifetimeScope();
            builder.RegisterType<BookGenreListManager>().As<IBookGenreListService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieGenreListManager>().As<IMovieGenreListService>().InstancePerLifetimeScope();
            builder.RegisterType<DirectorManager>().As<IDirectorService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorManager>().As<IAuthorService>().InstancePerLifetimeScope();
            builder.RegisterType<ActorManager>().As<IActorService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieActorManager>().As<IMovieActorService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuContentManager>().As<IMenuContentService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuObjectManager>().As<IMenuObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<RatingManager>().As<IRatingService>().InstancePerLifetimeScope();
            builder.RegisterType<ReviewManager>().As<IReviewService>().InstancePerLifetimeScope();

            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                }).InstancePerLifetimeScope();
        }
    }
}
