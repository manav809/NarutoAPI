using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NarutoAPI.Data;

namespace NarutoAPI.Data
{
    public class NarutoAPIDBContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public NarutoAPIDBContext(DbContextOptions<NarutoAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("CustomerDataService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Character> Characters { get; set; } = null!;//tale name for API
        public DbSet<Clan> Clans { get; set; } = null!;

    }
}

