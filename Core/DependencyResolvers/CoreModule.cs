﻿using Core.Business.Abstract;
using Core.Business.Concrete;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Features.IoC;
using Core.Features.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
            serviceCollection.AddSingleton<ITokenHelper, JwtHelper>();
            serviceCollection.AddSingleton<IAuthService, AuthManager>();
            serviceCollection.AddSingleton<IUserService, UserManager>();
            serviceCollection.AddSingleton<IUserRepository, EfUserRepository>();
            serviceCollection.AddSingleton<IUserOperationClaimService, UserOperationClaimManager>();
            serviceCollection.AddSingleton<IUserOperationClaimRepository, EfUserOperationClaimRepository>();
            serviceCollection.AddSingleton<IOperationClaimRepository, EfOperationClaimRepository>();
            serviceCollection.AddSingleton<IOperationClaimService, OperationClaimManager>();
        }
    }
}

