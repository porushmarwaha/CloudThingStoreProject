using CloudThingStore.Services.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CloudThingStore.Services.Service
{
    public static class ExceptionInstance
    {
        //public readonly Host host;
        static ExceptionInstance()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<CategoryNotExistException>();
                    services.AddSingleton<DuplicateCategoryException>();
                    services.AddSingleton<DuplicateSubCategoryException>();
                    services.AddSingleton<ProductNotExistException>();
                    services.AddSingleton<SubCategoryNotExistException>();
                })
                .Build();
        }
        //public static CategoryNotExistException CategoryNotExistExceptionInstance()
        //{
            

        //    return ActivatorUtilities.CreateInstance<CategoryNotExistException>(host.Services);

        //}
    }
}
