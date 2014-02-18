using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_InoportunidadAtencion
    {
        DM_InoportunidadAtencion oDMInoportunidadAtencion = new DM_InoportunidadAtencion();

        public inoportunidadAtencion getInoportunidadAtencion()
        {
            return oDMInoportunidadAtencion.GetInoportunidadAtencion();
        }

        public Int32 AddInoportunidadAtencion(inoportunidadAtencionEntidad oInoportunidadAtencion)
        {
            return oDMInoportunidadAtencion.AddInoportunidadAtencion(oInoportunidadAtencion);
        }

        public Int32 UpdateInoportunidadAtencion(inoportunidadAtencionEntidad oInoportunidadAtencion)
        {
            return oDMInoportunidadAtencion.UpdateInoportunidadAtencion(oInoportunidadAtencion);
        }
    }
}
