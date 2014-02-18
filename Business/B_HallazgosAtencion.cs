using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_HallazgosAtencion
    {
        DM_HallazgoAtencion oDMHallazgosAtencion = new DM_HallazgoAtencion();

        public hallazgoAtencion getHallazgosAtencion()
        {
            return oDMHallazgosAtencion.GetHallazgoAtencion();
        }

        public hallazgoAtencion GetHallazgoAtencionXidDatosUS(Int32 idDatosUS)
        {
            return oDMHallazgosAtencion.GetHallazgoAtencionXidDatosUS(idDatosUS: idDatosUS);
        }

        public Int32 AddHallazgosAtencion(hallazgoAtencionEntidad oHallazgosAtencion)
        {
            return oDMHallazgosAtencion.AddHallazgoAtencion(oHallazgosAtencion);
        }

        public Int32 UpdateHallazgosAtencion(hallazgoAtencionEntidad oHallazgosAtencion)
        {
            return oDMHallazgosAtencion.UpdateHallazgoAtencion(oHallazgosAtencion);
        }
    }
}
