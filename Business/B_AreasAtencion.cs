using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_AreasAtencion
    {
        DM_AreasAtencion oDMAreasAtencion = new DM_AreasAtencion();

        public AreasAtencion getAreasAtencion()
        {
            return oDMAreasAtencion.GetAreasAtencion();
        }

        public Int32 AddAreasAtencion(AreasAtencionEntidad oAreasAtencion)
        {
            return oDMAreasAtencion.AddAreasAtencion(oAreasAtencion);
        }

        public Int32 UpdateAreasAtencion(AreasAtencionEntidad oAreasAtencion)
        {
            return oDMAreasAtencion.UpdateAreasAtencion(oAreasAtencion);
        }
    }
}
