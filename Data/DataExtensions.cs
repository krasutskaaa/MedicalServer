using Microsoft.EntityFrameworkCore;

namespace CourseworkMedicalServer.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TestsStoreDBContext>();
        await dbContext.Database.MigrateAsync();
    }
}
