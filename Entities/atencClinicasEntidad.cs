using System;

namespace Entities
{
    public class AtencClinicasEntidad
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
        public Int32 idTipoDoc { get; set; }
        public String apellidoA { get; set; }
        public String apellidoB { get; set; }
        public String nombreA { get; set; }
        public String nombreB { get; set; }
        public String horaIngreso { get; set; }
        public String fecNacimiento { get; set; }
        public Int32 edad { get; set; }
        public Int32 tipoEdad { get; set; }
        public Int32 contrato { get; set; }
        public Int32 tipoContrato { get; set; }
        public String pabellon { get; set; }
        public Int32 idUser { get; set; }
        public String sexo { get; set; }
    }

}
