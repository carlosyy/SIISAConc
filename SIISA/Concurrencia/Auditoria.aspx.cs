using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Business;
using Entities;
using System.Web;
using System.Collections;


namespace SIISAConc.Concurrencia
{
    public partial class Auditoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static List<ServiciosEntidad> getServicios(String busqDx)
        {
            B_Servicios oBServicios = new B_Servicios();
            var query = from item in oBServicios.getServiciosXBusq(busqDx).AsEnumerable()
                        select new ServiciosEntidad
                        {
                            codServ = item.codServ,
                            descripcion = item.descripcion,
                            nombreConcepto = item.nombreConcepto
                        };
            return query.ToList<ServiciosEntidad>();
        }

        [WebMethod]
        public static List<AutoCompletarEntidad> getAutoCompletar(String prefixText, Int32 proceso)
        {
            B_AutoCompletar oBAutoCompletar = new B_AutoCompletar();
            var query = from item in oBAutoCompletar.getAutoCompletar(prefixText: prefixText, proceso: proceso)
                        select new AutoCompletarEntidad
                        {
                            indexSeleccion = item.indexSeleccion,
                            textoAutoCompletar = item.textoAutoCompletar
                        };
            return query.ToList<AutoCompletarEntidad>();
        }

        [WebMethod]
        public static ServiciosAtencionEntidad[] getServiciosAtencionxRadicado(String radicado)
        {
            B_ServiciosAtencion oBServiciosAtencion = new B_ServiciosAtencion();
            IEnumerable query = from item in oBServiciosAtencion.getServiciosAtencionxRadicado(radicado).AsEnumerable()
                                select new ServiciosAtencionEntidad
                                {
                                    idServ = item.idServ,
                                    codServ = item.codServ,
                                    descripServ = item.descripServ,
                                    concepto = item.concepto,
                                    noAutorizacion = item.noAutorizacion,
                                    servPpal = item.servPpal
                                };
            return query.Cast<ServiciosAtencionEntidad>().ToArray();
        }

        [WebMethod]
        public static Int32 AddServiciosAtencion(Int32 tipoAutorizacion, String noAutorizacion, String codServ, Int32 idUser, String radicado, Int32 indice, String txtBuscado, Int32 cantServ, Int32 vrTotal)
        {
            ServiciosAtencionEntidad oServiciosAtencion = new ServiciosAtencionEntidad();
            oServiciosAtencion.tipoAutorizacion = tipoAutorizacion;
            oServiciosAtencion.noAutorizacion = noAutorizacion;
            oServiciosAtencion.codServ = codServ;
            oServiciosAtencion.radicado = radicado;
            oServiciosAtencion.indexSeleccion = indice;
            oServiciosAtencion.txtBuscado = txtBuscado;
            oServiciosAtencion.idUser = idUser;
            oServiciosAtencion.cantServ = cantServ;
            oServiciosAtencion.vrTotal = vrTotal;
            B_ServiciosAtencion oB_ServiciosAtencion = new B_ServiciosAtencion();
            return oB_ServiciosAtencion.AddServiciosAtencion(oServiciosAtencion);            
        }

        [WebMethod]
        public static Int32 setServPpal(String radicado, Int32 idServ)
        {
            ServiciosAtencionEntidad oServAtencion = new ServiciosAtencionEntidad();
            oServAtencion.radicado = radicado;
            oServAtencion.idServ = idServ;
            B_ServiciosAtencion oB_ServiciosAtencion = new B_ServiciosAtencion();
            return oB_ServiciosAtencion.setServPpal(oServAtencion);
        }

        [WebMethod]
        public static DxAtencionEntidad[] getDxAtencionInic(String radicado)
        {
            B_DxAtencion oBDxAtencion = new B_DxAtencion();
            IEnumerable query = from item in oBDxAtencion.getDxAtencionInic(radicado).AsEnumerable()
                                select new DxAtencionEntidad
                                {                                    
                                    codDx = item.codDx,
                                    descripDx = item.descripDx                                    
                                };
            return query.Cast<DxAtencionEntidad>().ToArray();
        }

        [WebMethod]
        public static DxAtencionEntidad[] getDxAtencionxRadicado(String radicado)
        {
            B_DxAtencion oBDxAtencion = new B_DxAtencion();
            IEnumerable query = from item in oBDxAtencion.getDxAtencionxRadicado(radicado).AsEnumerable()
                                select new DxAtencionEntidad
                                {
                                    idDx = item.idDx,
                                    codDx = item.codDx,
                                    descripDx = item.descripDx,
                                    dxPpal = item.dxPpal
                                };
            return query.Cast<DxAtencionEntidad>().ToArray();
        }

        [WebMethod]
        public static Int32 AddDxAtencion(String codDx, Int32 idUser, String radicado, Boolean dxPpal)
        {
            DxAtencionEntidad oDxAtencion = new DxAtencionEntidad();            
            oDxAtencion.codDx = codDx;
            oDxAtencion.idUser = idUser;
            oDxAtencion.radicado = radicado;
            oDxAtencion.dxPpal = dxPpal;            
            B_DxAtencion oB_DxAtencion = new B_DxAtencion();
            return oB_DxAtencion.addDxAtencion(oDxAtencion);        
        }

        [WebMethod]
        public static Int32 setDxPpal(String radicado, Int32 idDx)
        {
            DxAtencionEntidad oDxAtencion = new DxAtencionEntidad();
            oDxAtencion.radicado = radicado;
            oDxAtencion.idDx = idDx;
            B_DxAtencion oB_DxAtencion = new B_DxAtencion();
            return oB_DxAtencion.setDxPpal(oDxAtencion);

        }

        [WebMethod]
        public static Int32 AddHallazgoAtencion(Int32 tipoHallazgo, DateTime fecHallazgo, String hallazgoAtencion, String radicado, Int32 idArea, Int32 idDatoHallazgo, Int32 idUser)
        {
            HallazgoAtencionEntidad oHallazgoAtencion = new HallazgoAtencionEntidad();
            oHallazgoAtencion.idTipoHallazgo = tipoHallazgo;
            oHallazgoAtencion.fecHallazgo = fecHallazgo;
            oHallazgoAtencion.hallazgoAtencion = hallazgoAtencion.Replace("'", "\"");
            oHallazgoAtencion.radicado = radicado;
            oHallazgoAtencion.idArea = idArea;
            switch (tipoHallazgo)
            {
                case 1:
                    oHallazgoAtencion.idPertinenciaAtencion = idDatoHallazgo;
                    break;
                case 2:
                    oHallazgoAtencion.idInoportunidadAtencion = idDatoHallazgo;
                    break;
                case 3:
                    oHallazgoAtencion.idNoCalidadAtencion = idDatoHallazgo;
                    break;
                case 4:
                    oHallazgoAtencion.idEventosAdversosAtencion = idDatoHallazgo;
                    break;
            }
            
            oHallazgoAtencion.idAuditor = idUser;
            B_HallazgosAtencion oB_HallazgosAtencion = new B_HallazgosAtencion();
            return oB_HallazgosAtencion.AddHallazgosAtencion(oHallazgoAtencion);
        }

        [WebMethod]
        public static HallazgoAtencionEntidad[] getHallazgoAtencionxRadicado(String radicado)
        {
            B_HallazgosAtencion oB_HallazgosAtencion = new B_HallazgosAtencion();
            IEnumerable query = from item in oB_HallazgosAtencion.GetHallazgoAtencionXRadicado(radicado).AsEnumerable()
                                select new HallazgoAtencionEntidad
                                {
                                    nTipoHallazgo = item.nTipoHallazgo,
                                    hallazgoAtencion = item.hallazgoAtencion,
                                    nArea = item.nArea,
                                    nPertinenciaAtencion = item.nPertinenciaAtencion,
                                    nInoportunidadAtencion = item.nInoportunidadAtencion,
                                    nNoCalidadAtencion = item.nNoCalidadAtencion,
                                    nEventosAdversosAtencion = item.nEventosAdversosAtencion,
                                    idhallazgoAtencion = item.idhallazgoAtencion
                                };
            return query.Cast<HallazgoAtencionEntidad>().ToArray();
        }

        [WebMethod]
        public static String getCorreoNotifHallazgo(String area, String radicado)
        {
            B_HallazgosAtencion oB_HallazgosAtencion = new B_HallazgosAtencion();
            return oB_HallazgosAtencion.getCorreoNotifHallazgo(area: area, radicado: radicado);
        }
    }
}