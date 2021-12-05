using Microsoft.EntityFrameworkCore;
using testStartup.Models;

namespace testStartup.Data
{
    public class DataContext : DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Produto> Produto {get; set;}
    }
}