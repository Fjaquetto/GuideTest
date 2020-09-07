using GuideAPI.Domain.Models;
using GuideAPI.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideAPI.Infra.Data.Context
{
    public class GuideContext : DbContext
    {
        public GuideContext(DbContextOptions<GuideContext> options) : base(options) { }

        public DbSet<Autores> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoresMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
