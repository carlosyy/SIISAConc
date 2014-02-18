using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public  class AfiliadoEntidad
    {
        public String apellido1 { get; set; }
        public String apellido2 { get; set; }
        public String documento { get; set; } //Llave Primaria
        public Int32 usuarioId { get; set; }
        public String nombre1 { get; set; }
        public String nombre2 { get; set; }
        public String sexo { get; set; }
        public Int32 tipoDocId { get; set; }
        public String tipoDocumento { get; set; }
        public DateTime fecNac { get; set; }
        public DateTime fecAfil { get; set; }            
        //public String TipoDocDescripcion { get; set; }        
    }
}

