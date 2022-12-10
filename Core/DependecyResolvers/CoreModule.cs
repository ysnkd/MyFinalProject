using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Cashing.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependecyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager,MemoryCacheManager>();
            //senden IMemoryCashe talebinde MemoryCasheManager'i ver.
            serviceCollection.AddMemoryCache();
            // bu kod .NET'ten geliyor.
            //Otomatik injection yapıyor,->IMemoryCache _memoryCache;(MemoryCacheManager)
            serviceCollection.AddSingleton<Stopwatch>();
            //timer arkaplanda oluştur.
        }

    }
}
