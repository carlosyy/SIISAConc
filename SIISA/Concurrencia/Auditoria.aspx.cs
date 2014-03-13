using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Business;
using Entities;

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
        public static string GetCustomers()
        {
            string query = "SELECT top 10 CustomerID, ContactName, City FROM Customers";
            SqlCommand cmd = new SqlCommand(query);
            return GetData(cmd).GetXml();
        }
        private static DataSet GetData(SqlCommand cmd)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        return ds;

                    }
                }
            }
        }

        [WebMethod]
        public static Int32 AddServiciosAtencion(Int32 tipoAutorizacion, String noAutorizacion, String codServ, String radicado, Int32 idUser)
        {
            ServiciosAtencionEntidad oServiciosAtencion = new ServiciosAtencionEntidad();
            oServiciosAtencion.tipoAutorizacion = tipoAutorizacion;
            oServiciosAtencion.noAutorizacion = noAutorizacion;
            oServiciosAtencion.codServ = codServ;
            oServiciosAtencion.radicado = radicado;
            oServiciosAtencion.idUser = idUser;
            B_ServiciosAtencion oB_ServiciosAtencion = new B_ServiciosAtencion();
            return oB_ServiciosAtencion.AddServiciosAtencion(oServiciosAtencion);
            
        }
    }
}