using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_DxAtencion
    {
        DM_DxAtencion oDMDx = new DM_DxAtencion();

        public DxAtencion getDxAtencion()
        {
            return oDMDx.getDxAtencion();
        }
        public DxAtencion getDxAtencionInic(String radicado)
        {
            return oDMDx.getDxAtencionInic(radicado: radicado);
        }

        public DxAtencion getDxAtencionxRadicado(String radicado)
        {
            return oDMDx.getDxAtencion(radicado: radicado);
        }
        public DxAtencion getDxAtencionxCodDx(String codDx)
        {
            return oDMDx.getDxAtencion(codDx: codDx);
        }
        public Int32 addDxAtencion(DxAtencionEntidad oDxAtencion)
        {
            return oDMDx.addDxAtencion(oDxAtencion);
        }
        public Int32 setDxPpal(DxAtencionEntidad oDxAtencion)
        {
            return oDMDx.setDxPpal(oDxAtencion: oDxAtencion);
        }

    }
}