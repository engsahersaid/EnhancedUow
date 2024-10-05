using Microsoft.Extensions.DependencyInjection;

namespace UOwPoc.Core.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddAutoMapper(typeof(Mapping.MappingProfile).Assembly);
            //services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}