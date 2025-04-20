using Microsoft.EntityFrameworkCore;
using SharpAPI.Models;

namespace SharpAPI.Data;

public class AppDbContext : DbContext, IDataRepository
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<DataModel> Data { get; set; }

    public async Task SaveDataAsync(DataModel data)
    {
        await Data.AddAsync(data);
        await SaveChangesAsync();
    }
}