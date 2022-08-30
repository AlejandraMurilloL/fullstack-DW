using DW.Domain;
using DW.Infrastructure.Database;
using DW.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace DW.Infrastructure.Extentions
{
    public static class UnitOfWorkExtension
    {
        public static IServiceCollection SetupUnitOfWork([NotNullAttribute] this IServiceCollection serviceCollection)
        {
            //TODO: Find a way to inject the repositories and share the same context without creating a instance.
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(f =>
            {
                var scopeFactory = f.GetRequiredService<IServiceScopeFactory>();
                var context = f.GetService<PruebaDWContext>();
                return new UnitOfWork(
                    context,
                    new CategoryRepository(context.Categories),
                    new CustomerRepository(context.Customers)
                );
            });
            return serviceCollection;
        }
    }
}
