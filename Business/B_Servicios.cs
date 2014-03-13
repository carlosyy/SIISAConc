using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Servicios
    {
        DM_Servicios oDMServicios = new DM_Servicios();

        public Servicios getServicios()
        {
            return oDMServicios.GetServicios();
        }

        public Servicios GetServicios(String codServ = "", String descripcion = "")
        {
            return oDMServicios.GetServicios(codServ: codServ, descripcion: descripcion);
        }

        public Servicios getServiciosCodServHomol(String codServ, String tipoBusq)
        {
            return oDMServicios.GetServicios(codServ: codServ, tipoBusq: tipoBusq);
        }

        public Servicios getServiciosDescripcionHomol(String descripcion, String tipoBusq)
        {
            return oDMServicios.GetServicios(descripcion: descripcion, tipoBusq: tipoBusq);
        }

        public Servicios getCodDescr(String codDescr, String tipoBusq)
        {
            return oDMServicios.getCodDescr(codDescr: codDescr, tipoBusq: tipoBusq);
        }

        public Servicios getServicioxCod(String codServ)
        {
            return oDMServicios.getServicioxCod(codServ: codServ);
        }

        public String getExisteCodServicios(String codServ)
        {
            return oDMServicios.getExisteServicio(codServ: codServ);
        }

        public String getExisteDescripServicios(String descripServ)
        {
            return oDMServicios.getExisteServicio(descripServ: descripServ);
        }

        public Int32 AddServicios(serviciosEntidad oServicios)
        {
            return oDMServicios.AddServicios(oServicios);
        }

        public Int32 UpdateServicios(serviciosEntidad oServicios)
        {
            return oDMServicios.UpdateServicios(oServicios);
        }

    }
}