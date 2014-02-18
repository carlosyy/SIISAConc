using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Entities
{
    public class UsuarioEntidad
    {
        public Boolean Activo { get; set; }        
        public String Documento { get; set; }
        public String Email { get; set; }
        public Int32 PerfilID { get; set; }
        public String Perfil { get; set; }
        public Int32 UsuarioID { get; set; }
        public String Nick { get; set; }
        public String claveUsuario { get; set; }
        public String Nombre { get; set; }
        public String Ruta { get; set; } 
        public String Sucursal { get; set; }
        public Int32 Tratamiento { get; set; }
    }
}

