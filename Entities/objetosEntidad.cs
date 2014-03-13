using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ObjetosEntidad
    {
        public Int32 idObjeto { get; set; } //Llave Primaria
        public String menuObjeto { get; set; }
        public String descripObjeto { get; set; }
        public String url { get; set; }
        public Int32 nivel { get; set; } 
    }
}
