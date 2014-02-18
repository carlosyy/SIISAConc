using System;

namespace Entities
{
    public class atencClinicasXAfiliadoEntidad
    {
        public String nombre_a { get; set; }
        public String nombre_b { get; set; }
        public String apellido_a { get; set; }
        public String apellido_b { get; set; }
        public String mesIngreso { get; set; }
        public String docIden { get; set; }
        public Int32 programa { get; set; }
        public String nitIps { get; set; }
        public String entidad { get; set; }
        public String fecIngreso { get; set; }
        public String fecEgreso { get; set; }
        public Int32 diasEstancia { get; set; }
        public String especialidad { get; set; }
        public String codDx { get; set; }
        public String dx { get; set; }
        public String codDxRel { get; set; }
        public String dxRel { get; set; }
        public String medico { get; set; }
        public String cama { get; set; }
        public String tipoAtencion { get; set; }
        public String motivoSalida { get; set; }
        public String tipoEstancia { get; set; }
        public Int32 puntaje { get; set; }
        public String estadoRad { get; set; }
        public Int32 idRadicado { get; set; }
    }
}
