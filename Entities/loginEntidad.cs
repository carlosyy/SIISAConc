using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class loginEntidad
    {
        public Int32 idUser { get; set; } //Llave Primaria        
        public String claveUsuario { get; set; }
        public String nick { get; set; }
        public Boolean activo { get; set; }        
    }
}
