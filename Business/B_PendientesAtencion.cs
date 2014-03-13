using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_PendientesAtencion
    {
        DM_PendientesAtencion oDMPendientesAtencion = new DM_PendientesAtencion();

        public PendientesAtencion getPendientesAtencion()
        {
            return oDMPendientesAtencion.getPendientesAtencion();
        }

        public PendientesAtencion getPendientesAtencionXidDatosUs(Int32 idDatosUs)
        {
            return oDMPendientesAtencion.getPendientesAtencion(idDatosUs: idDatosUs);
        }

        public Int32 addPendientesAtencion(PendientesAtencionEntidad oPendientesAtencion)
        {
            return oDMPendientesAtencion.addPendientesAtencion(oPendientesAtencion);
        }

        public Int32 updatePertinenciaAtencion(PendientesAtencionEntidad oPendientesAtencion)
        {
            return oDMPendientesAtencion.updatePendientesAtencion(oPendientesAtencion);
        }
    }
}
