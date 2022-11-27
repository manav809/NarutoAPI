using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NarutoAPI.Models;

namespace NarutoAPI.Data
{
    public class DataContext: DbContext
    {

        //public DataContext() { }
        protected readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }


        public DbSet<Character> Characters { get; set; } = null!;//tale name for API
        public DbSet<Clan> Clans { get; set; } = null!;

    }
}

