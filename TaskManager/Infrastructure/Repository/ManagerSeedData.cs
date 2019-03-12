using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Models;

namespace TaskManager.Infrastructure.Repository
{
    public static class ManagerSeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                if (dbContext.Manger.Any()) return;

                dbContext.AddRange(
                    new Manager
                    {
                        FirstName = "Иван", SurName = "Сергеевич", LastName = "Фомин", Position = "Team Leader"
                    },
                    new Manager
                    {
                        FirstName = "Вячеслав", SurName = "Генадьевич", LastName = "Сорокин", Position = "Designer"
                    },
                    new Manager
                    {
                        FirstName = "Семен", SurName = "Леонидович", LastName = "Бергман", Position = "Mathematician"
                    },
                    new Manager
                    {
                        FirstName = "Петр", SurName = "Игнатьевич", LastName = "Степанов", Position = "Tester"
                    },
                    new Manager
                    {
                        FirstName = "Ирина", SurName = "Валерьевна", LastName = "Фролова", Position = "Developer"
                    }
                );

                dbContext.SaveChanges();
            }
        }
    }
}
