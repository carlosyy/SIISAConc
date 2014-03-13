using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class EspecialidadEntidad
    {
        public Int32 idEspecialidad { get; set; } //Llave Primaria
        public String especialidad { get; set; }
        public String subMayor { get; set; }
        public String clase { get; set; }
        public Boolean activo { get; set; }
        
    }
}
