using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ProgramasEntidad
    {
        public Int32 idPrograma { get; set; } //Llave Primaria
        public String programa { get; set; }
        public Int32 idProgEquiv { get; set; }
        public Boolean activo { get; set; }
        public Int32 cantIdDatosUS { get; set; }
        public Int32 idProgramaRad { get; set; }
        public String programaRad { get; set; }
    }
}
