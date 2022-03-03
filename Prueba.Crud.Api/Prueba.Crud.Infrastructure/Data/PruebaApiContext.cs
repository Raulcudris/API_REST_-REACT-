using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Prueba.Crud.Core.Entities;
using Prueba.Crud.Infrastructure.Data.Configurations;

#nullable disable

namespace Prueba.Crud.Infrastructure.Data
{
    public partial class PruebaApiContext : DbContext
    {
        public PruebaApiContext()
        {
        }

        public PruebaApiContext(DbContextOptions<PruebaApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
        }
    }
}
