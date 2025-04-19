using DevHabbit.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace DevHabbit.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task ApplyMigrationsAsync(this WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();
            await using ApplicationDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            try
            {
                await dbContext.Database.MigrateAsync();
                app.Logger.LogInformation("Database migrations applied successfully.");
            }
            catch (Exception e)
            {
                app.Logger.LogError("An Error occured while applying database migrations.");
                throw;
            }

            
        }
    }
}
