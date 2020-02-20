using System.Collections.Generic;

namespace Models.Dao
{
    public class Ciudad
    {
        public int CiudadId { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
    
}
