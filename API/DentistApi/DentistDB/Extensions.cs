namespace DentistDB
{
    using DentistDB.Repositories.Gebiss;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Extensions
    {
        public static void AddExtensions(this IServiceCollection services)
        {
            services.AddScoped<IGebissRepository, GebissRepository>();
        }
    }
}
