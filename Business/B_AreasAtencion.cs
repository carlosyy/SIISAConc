using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_AreasAtencion
    {
        DM_AreasAtencion oDMAreasAtencion = new DM_AreasAtencion();

        public areasAtencion getAreasAtencion()
        {
            return oDMAreasAtencion.GetAreasAtencion();
        }

        public Int32 AddAreasAtencion(areasAtencionEntidad oAreasAtencion)
        {
            return oDMAreasAtencion.AddAreasAtencion(oAreasAtencion);
        }

        public Int32 UpdateAreasAtencion(areasAtencionEntidad oAreasAtencion)
        {
            return oDMAreasAtencion.UpdateAreasAtencion(oAreasAtencion);
        }
    }
}
