using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PersonDb;

namespace Achilles_Navid_Demo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<PersonRepository, PersonRepository>();
            builder.Services.AddDbContext<PersonSqlite>();
        }
    }
}

