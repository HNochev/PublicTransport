using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            SeedCategories(services);

            return app;
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.VehicleConditions.Any())
            {
                return;
            }

            data.VehicleConditions.AddRange(new[]
            {
                new VehicleCondition { ConditionDescription = "В движение/ Действащ", ClassColor = "table-light", Counter = 1},
                new VehicleCondition { ConditionDescription = "Нов/ Не е работил с пътници", ClassColor = "table-success", Counter = 2},
                new VehicleCondition { ConditionDescription = "Повреден", ClassColor = "table-warning" , Counter = 3},
                new VehicleCondition { ConditionDescription = "Предаден в друг град", ClassColor = "table-info" , Counter = 4 },
                new VehicleCondition { ConditionDescription = "Снет от експлоатация/ Очаква се бракуване", ClassColor = "table-secondary", Counter = 5 },
            });

            data.SaveChanges();
        }
    }
}
