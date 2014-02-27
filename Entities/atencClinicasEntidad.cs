using System;

namespace Entities
{
    public class atencClinicasEntidad
    {
        public String mesIngreso { get; set; }        
        public String docIden { get; set; }
        public Int32 programa { get; set; }
        public String nitClinica { get; set; }
        public String fecIngreso { get; set; }
        public String fecEgreso { get; set; }
        public Int32 diasEstancia { get; set; }
        public String especialidad { get; set; }
        public String codDx { get; set; }
        public String codDxRel { get; set; }
        public String medico { get; set; }
        public String cama { get; set; }
        public Int32 idTipoAtencion { get; set; }
        public String tipoAtencion { get; set; }
        public String motivoSalida { get; set; }
    }

}
