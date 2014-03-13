using System;

namespace Entities
{
    public class PendientesAtencionEntidad
    {
        public Int32 idPdtesAtencion { get; set; } //Llave Primaria
        public Int32 idDatosUS { get; set; }
        public Int32 idAreaAtencion { get; set; }
        public Int32 idPatologia { get; set; }
        public String codServ { get; set; }
        public Int32 cantServ { get; set; }
        public String descripServ { get; set; }

    }
}
