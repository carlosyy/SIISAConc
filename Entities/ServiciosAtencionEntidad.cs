using System;

namespace Entities
{
    public class ServiciosAtencionEntidad
    {
        public Int32 idServ { get; set; }
        public String radicado { get; set; }        
        public String codServ { get; set; }
        public String noAutorizacion { get; set; }
        public Int32 tipoAutorizacion { get; set; }
        public Int32 idUser { get; set; }
        public String concepto { get; set; }
        public String descripServ { get; set; }
        public String txtBuscado { get; set; }
        public Int32 indexSeleccion { get; set; }
        public Int32 cantServ { get; set; }
        public Int32 vrTotal { get; set; }
    }
}
