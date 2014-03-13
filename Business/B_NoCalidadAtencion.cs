using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_NoCalidadAtencion
    {
        DM_NoCalidadAtencion oDMNoCalidadAtencion = new DM_NoCalidadAtencion();

        public NoCalidadAtencion getNoCalidadAtencion()
        {
            return oDMNoCalidadAtencion.GetNoCalidadAtencion();
        }

        public Int32 AddNoCalidadAtencion(NoCalidadAtencionEntidad oNoCalidadAtencion)
        {
            return oDMNoCalidadAtencion.AddNoCalidadAtencion(oNoCalidadAtencion);
        }

        public Int32 UpdateNoCalidadAtencion(NoCalidadAtencionEntidad oNoCalidadAtencion)
        {
            return oDMNoCalidadAtencion.UpdateNoCalidadAtencion(oNoCalidadAtencion);
        }
    }
}
