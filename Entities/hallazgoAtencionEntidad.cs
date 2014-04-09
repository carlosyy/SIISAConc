using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class HallazgoAtencionEntidad
    {
        public Int32 idhallazgoAtencion { get; set; }
        public String hallazgoAtencion { get; set; }
        public Int32 idDatosUS { get; set; }
        public Int32 idAuditor { get; set; }
        public String nAuditor { get; set; }
        public Int32 idArea { get; set; }
        public String nArea { get; set; }
        public Int32 idPertinenciaAtencion { get; set; }
        public String nPertinenciaAtencion { get; set; }
        public Int32 idInoportunidadAtencion { get; set; }
        public String nInoportunidadAtencion { get; set; }
        public Int32 idNoCalidadAtencion { get; set; }
        public String nNoCalidadAtencion { get; set; }
        public Int32 idEventosAdversosAtencion { get; set; }
        public String nEventosAdversosAtencion { get; set; }
        public String radicado { get; set; }
    }
}
