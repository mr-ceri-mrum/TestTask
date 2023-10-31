using Microsoft.EntityFrameworkCore;
using TestHardCode.Models;

namespace TestHardCode.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options, DbSet<Product> products) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        /*AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);*/
    }

    public DbSet<Product> Products;
    public DbSet<Category> Categories;
}