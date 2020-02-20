using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Dao;

namespace Persistence.SqlServer.Config
{
    public class CiudadConfig
    {
        public CiudadConfig(EntityTypeBuilder<Ciudad> entityBuilder)
        {

            entityBuilder.HasKey(x => x.CiudadId);
            entityBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50);


        }
    }
}
