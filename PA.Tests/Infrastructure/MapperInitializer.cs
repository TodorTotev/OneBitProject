using PA.Tests.Infrastructure.Seeding;

namespace PA.Tests.Infrastructure
{
    using System.Reflection;
    using Application.Common.Models;
    using Application.Infrastructure.Automapper;

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
