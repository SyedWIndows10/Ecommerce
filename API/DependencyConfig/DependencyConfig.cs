using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace API.DependencyConfig
{
    public static class DependencyConfig
    {
           public static void AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<IProductRepository,ProductRepository>();

        //     var types = Assembly.Load(new AssemblyName("Infrastructure"))
        //                         .DefinedTypes
        //                         .ToList();
        //     //Key: Repository interface
        //     //Value: Repository implementation
        //     var repos = new Dictionary<Type, Type>();
        //     foreach (var typeInfo in types)
        //     {
        //         var repoInterface = typeInfo.ImplementedInterfaces.FirstOrDefault(e=>e.GetInterface());
        //         if (repoInterface == null)
        //             continue;

        //         repos.Add(repoInterface, typeInfo);
        //     }

        //     foreach (var repo in repos)
        //     {
        //         services.AddScoped(repo.Key, repo.Value);
        //     }
        // }
    }
}

}