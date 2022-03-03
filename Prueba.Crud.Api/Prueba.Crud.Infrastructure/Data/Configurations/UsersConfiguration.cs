using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba.Crud.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Crud.Infrastructure.Data.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(e => e.Id_User);
            builder.Property(e => e.Id_User)
                    .HasColumnName("Id_Usuario");
            builder.Property(e => e.LastName)
                    .HasColumnName("Apellidos")
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            builder.Property(e => e.Civil_Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Estado_Civil");
            builder.Property(e => e.Birth_date)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");
            builder.Property(e => e.Name)
                     .HasColumnName("Nombres")
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            builder.Property(e => e.Document_Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Documento");
            builder.Property(e => e.Value_to_win)
                .HasColumnName("Valor_a_Ganar");
         }
    }
}
