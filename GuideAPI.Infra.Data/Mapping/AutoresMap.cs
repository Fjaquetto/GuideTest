using GuideAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideAPI.Infra.Data.Mapping
{
    public class AutoresMap : IEntityTypeConfiguration<Autores>
    {
        public void Configure(EntityTypeBuilder<Autores> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasMaxLength(100);
        }
    }
}
