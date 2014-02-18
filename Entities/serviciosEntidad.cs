using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class serviciosEntidad
    {
        public String codServ { get; set; } //Llave Primaria
        public String descripcion { get; set; }
        public Int32 codConcepto { get; set; }
        public Int32 idArea { get; set; }
        public String codificacion { get; set; }
        public Boolean inactivo { get; set; }        
    }
}
