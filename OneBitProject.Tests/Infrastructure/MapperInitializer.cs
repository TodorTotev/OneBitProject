using OneBitProject.Tests.Infrastructure.Seeding;

namespace OneBitProject.Tests.Infrastructure
{
    using System.Reflection;
    using OneBitProject.Application.Common.Models;
    using OneBitProject.Application.Infrastructure.Automapper;

    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CustomerLookupModel).GetTypeInfo().Assembly,
                typeof(ITestSeeder).GetTypeInfo().Assembly);
        }
    }
}
