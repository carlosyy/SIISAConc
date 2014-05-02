using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_ServiciosAtencion
    {
        DM_ServiciosAtencion oDMServicios = new DM_ServiciosAtencion();

        public ServiciosAtencion getServiciosAtencion()
        {
            return oDMServicios.getServiciosAtencion();
        }
        public ServiciosAtencion getServiciosAtencionxRadicado(String radicado)
        {
            return oDMServicios.getServiciosAtencion(radicado: radicado);
        }
        public ServiciosAtencion getServiciosAtencionxCodServ(String codServ)
        {
            return oDMServicios.getServiciosAtencion(codServ: codServ);
        }
        public Int32 AddServiciosAtencion(ServiciosAtencionEntidad oServiciosAtencion)
        {
            return oDMServicios.AddServiciosAtencion(oServiciosAtencion);
        }
        public Int32 UpdateServiciosAtencion(ServiciosAtencionEntidad oServicios)
        {
            return oDMServicios.UpdateServiciosAtencion(oServicios);
        }

        public Int32 setServPpal(ServiciosAtencionEntidad oServAtencion)
        {
            return oDMServicios.setServPpal(oServAtencion: oServAtencion);
        }

    }
}