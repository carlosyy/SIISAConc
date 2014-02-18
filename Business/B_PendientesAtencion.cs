using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_PendientesAtencion
    {
        DM_PendientesAtencion oDMPendientesAtencion = new DM_PendientesAtencion();

        public pendientesAtencion getPendientesAtencion()
        {
            return oDMPendientesAtencion.getPendientesAtencion();
        }

        public pendientesAtencion getPendientesAtencionXidDatosUs(Int32 idDatosUs)
        {
            return oDMPendientesAtencion.getPendientesAtencion(idDatosUs: idDatosUs);
        }

        public Int32 addPendientesAtencion(pendientesAtencionEntidad oPendientesAtencion)
        {
            return oDMPendientesAtencion.addPendientesAtencion(oPendientesAtencion);
        }

        public Int32 updatePertinenciaAtencion(pendientesAtencionEntidad oPendientesAtencion)
        {
            return oDMPendientesAtencion.updatePendientesAtencion(oPendientesAtencion);
        }
    }
}
