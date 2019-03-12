using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.Infrastructure.Identity
{
    public static class IdentitySeedData
    {
        private static Dictionary<string, string> Keys = new Dictionary<string, string>
        {
            {"Admin","Admin"},
            {"Fomin","Fomin"},
            {"Sorokin","Sorokin"},
            {"Bergman","Bergman"},
            {"Stepanov","Stepanov"},
            {"Frolova","Frolova"} 
        };


        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                foreach (var key in Keys)
                {
                    var user = await userManager.FindByNameAsync(key.Key);
                    if (user != null) continue;

                    user = new IdentityUser(key.Key);
                    var res = await userManager.CreateAsync(user, key.Value);
                }
            }
        }
    }
}
