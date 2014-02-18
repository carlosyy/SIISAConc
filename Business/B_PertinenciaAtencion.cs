using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_PertinenciaAtencion
    {
        DM_PertinenciaAtencion oDMPertinenciaAtencion = new DM_PertinenciaAtencion();

        public pertinenciaAtencion getPertinenciaAtencion()
        {
            return oDMPertinenciaAtencion.GetPertinenciaAtencion();
        }

        public Int32 AddPertinenciaAtencion(pertinenciaAtencionEntidad oPertinenciaAtencion)
        {
            return oDMPertinenciaAtencion.AddPertinenciaAtencion(oPertinenciaAtencion);
        }

        public Int32 UpdatePertinenciaAtencion(pertinenciaAtencionEntidad oPertinenciaAtencion)
        {
            return oDMPertinenciaAtencion.UpdatePertinenciaAtencion(oPertinenciaAtencion);
        }
    }
}
