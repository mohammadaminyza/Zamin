using Microsoft.EntityFrameworkCore;
using MiniBlog.Core.Domain.Blogs.Entities;
using MiniBlog.Core.Domain.EventTests;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Infra.Data.Sql.Commands;

namespace MiniBlog.Infra.Data.Sql.Commands.Common
{
    public class MiniblogCommandDbContext : BaseCommandDbContext
    {
        public MiniblogCommandDbContext(DbContextOptions<MiniblogCommandDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<EventTest> EventTests => Set<EventTest>();

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
            configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
