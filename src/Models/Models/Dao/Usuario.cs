using System;
using System.Collections.Generic;
using System.Text;
using Models.Enums;

namespace Models.Dao
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public string DireccionResidencia { get; set; }
        public int CiudadId { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

        //
        public Ciudad Ciudad { get; set; }
    }
}
