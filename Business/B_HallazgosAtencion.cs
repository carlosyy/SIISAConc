using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_HallazgosAtencion
    {
        DM_HallazgoAtencion oDMHallazgosAtencion = new DM_HallazgoAtencion();

        public HallazgoAtencion getHallazgosAtencion()
        {
            return oDMHallazgosAtencion.GetHallazgoAtencion();
        }

        public HallazgoAtencion GetHallazgoAtencionXidDatosUS(Int32 idDatosUS)
        {
            return oDMHallazgosAtencion.GetHallazgoAtencionXidDatosUS(idDatosUS: idDatosUS);
        }

        public Int32 AddHallazgosAtencion(HallazgoAtencionEntidad oHallazgosAtencion)
        {
            return oDMHallazgosAtencion.AddHallazgoAtencion(oHallazgosAtencion);
        }

        public Int32 UpdateHallazgosAtencion(HallazgoAtencionEntidad oHallazgosAtencion)
        {
            return oDMHallazgosAtencion.UpdateHallazgoAtencion(oHallazgosAtencion);
        }
    }
}
