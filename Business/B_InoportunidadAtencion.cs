using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_InoportunidadAtencion
    {
        DM_InoportunidadAtencion oDMInoportunidadAtencion = new DM_InoportunidadAtencion();

        public InoportunidadAtencion getInoportunidadAtencion()
        {
            return oDMInoportunidadAtencion.GetInoportunidadAtencion();
        }

        public Int32 AddInoportunidadAtencion(InoportunidadAtencionEntidad oInoportunidadAtencion)
        {
            return oDMInoportunidadAtencion.AddInoportunidadAtencion(oInoportunidadAtencion);
        }

        public Int32 UpdateInoportunidadAtencion(InoportunidadAtencionEntidad oInoportunidadAtencion)
        {
            return oDMInoportunidadAtencion.UpdateInoportunidadAtencion(oInoportunidadAtencion);
        }
    }
}
