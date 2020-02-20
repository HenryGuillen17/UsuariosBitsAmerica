using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Dao;

namespace Persistence.SqlServer.Config
{
    public class UsuarioConfig
    {
        public UsuarioConfig(EntityTypeBuilder<Usuario> entityBuilder)
        {

            entityBuilder.HasKey(x => x.UsuarioId);
            entityBuilder.Property(x => x.PrimerNombre).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.SegundoNombre).HasMaxLength(50);
            entityBuilder.Property(x => x.PrimerApellido).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.SegundoApellido).HasMaxLength(50);
            entityBuilder.Property(x => x.TipoDocumento).IsRequired();
            entityBuilder.Property(x => x.NumeroDocumento).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.CorreoElectronico).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.DireccionResidencia).IsRequired().HasMaxLength(200);
            entityBuilder.Property(x => x.CiudadId).IsRequired();
            entityBuilder.Property(x => x.Telefono).HasMaxLength(25);
            entityBuilder.Property(x => x.Celular).IsRequired().HasMaxLength(25);

            entityBuilder.HasOne(x => x.Ciudad)
                .WithMany(x => x.Usuarios)
                .IsRequired();

        }
    }
}
