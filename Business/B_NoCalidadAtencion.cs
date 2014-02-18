using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_NoCalidadAtencion
    {
        DM_NoCalidadAtencion oDMNoCalidadAtencion = new DM_NoCalidadAtencion();

        public noCalidadAtencion getNoCalidadAtencion()
        {
            return oDMNoCalidadAtencion.GetNoCalidadAtencion();
        }

        public Int32 AddNoCalidadAtencion(noCalidadAtencionEntidad oNoCalidadAtencion)
        {
            return oDMNoCalidadAtencion.AddNoCalidadAtencion(oNoCalidadAtencion);
        }

        public Int32 UpdateNoCalidadAtencion(noCalidadAtencionEntidad oNoCalidadAtencion)
        {
            return oDMNoCalidadAtencion.UpdateNoCalidadAtencion(oNoCalidadAtencion);
        }
    }
}
