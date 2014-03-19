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
                                    noAutorizacion = item.noAutorizacion
                                };            
            return query.Cast<ServiciosAtencionEntidad>().ToArray();
        }

        [WebMethod]
        public static Int32 AddServiciosAtencion(Int32 tipoAutorizacion, String noAutorizacion, String codServ, Int32 idUser, String radicado, Int32 indice, String txtBuscado)
        {
            ServiciosAtencionEntidad oServiciosAtencion = new ServiciosAtencionEntidad();
            oServiciosAtencion.tipoAutorizacion = tipoAutorizacion;
            oServiciosAtencion.noAutorizacion = noAutorizacion;
            oServiciosAtencion.codServ = codServ;
            oServiciosAtencion.radicado = radicado;
            oServiciosAtencion.indexSeleccion = indice;
            oServiciosAtencion.txtBuscado = txtBuscado;
            oServiciosAtencion.idUser = Int32.Parse(HttpContext.Current.Session["idUser"].ToString());
            B_ServiciosAtencion oB_ServiciosAtencion = new B_ServiciosAtencion();
            return oB_ServiciosAtencion.AddServiciosAtencion(oServiciosAtencion);
            
        }
    }
}