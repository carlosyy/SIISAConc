using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_PertinenciaAtencion
    {
        DM_PertinenciaAtencion oDMPertinenciaAtencion = new DM_PertinenciaAtencion();

        public PertinenciaAtencion getPertinenciaAtencion()
        {
            return oDMPertinenciaAtencion.GetPertinenciaAtencion();
        }

        public Int32 AddPertinenciaAtencion(PertinenciaAtencionEntidad oPertinenciaAtencion)
        {
            return oDMPertinenciaAtencion.AddPertinenciaAtencion(oPertinenciaAtencion);
        }

        public Int32 UpdatePertinenciaAtencion(PertinenciaAtencionEntidad oPertinenciaAtencion)
        {
            return oDMPertinenciaAtencion.UpdatePertinenciaAtencion(oPertinenciaAtencion);
        }
    }
}
