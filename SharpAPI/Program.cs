using SharpAPI.Data;
using SharpAPI.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; 

namespace SharpAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddScoped<IDataRepository, AppDbContext>();
        builder.Services.AddScoped<DataService>();
        builder.Services.AddControllers();
        
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}