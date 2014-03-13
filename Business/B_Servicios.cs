using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Servicios
    {
        DM_Servicios oDMServicios = new DM_Servicios();

        public Servicios getServiciosXBusq(String codDescr)
        {
            return oDMServicios.getServiciosXBusq(codDescr: codDescr);
        }

        public String getExisteCodServicios(String codServ)
        {
            return oDMServicios.getExisteServicio(codServ: codServ);
        }

        public String getExisteDescripServicios(String descripServ)
        {
            return oDMServicios.getExisteServicio(descripServ: descripServ);
        }

        public Int32 AddServicios(ServiciosEntidad oServicios)
        {
            return oDMServicios.AddServicios(oServicios);
        }

        public Int32 UpdateServicios(ServiciosEntidad oServicios)
        {
            return oDMServicios.UpdateServicios(oServicios);
        }

    }
}