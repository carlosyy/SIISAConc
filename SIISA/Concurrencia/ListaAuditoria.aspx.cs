using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Business;

namespace SIISAConc.Concurrencia
{
    public partial class ListaAuditoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<AtencClinicasXAfiliadoEntidad> getAuditoriasXMesRadicado(Int32 idUserAuditoria, String mesAuditoria)
        {
            B_AtencClinicasXAfiliados oBAtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();
            var query = from item in oBAtencClinicasXAfiliados.getAuditoriasXMesRadicado(idUserAuditoria, mesAuditoria).AsEnumerable()
                        select new AtencClinicasXAfiliadoEntidad
                        {
                            fecRadicado = item.fecRadicado,
                            cama = item.cama,
                            nombreCompleto = item.nombreCompleto,
                            radicado = item.radicado,
                            estadoAtenc = item.estadoAtenc,
                            diasEstancia = item.diasEstancia
                        };
            return query.ToList<AtencClinicasXAfiliadoEntidad>();
        }

        [WebMethod]
        public static List<AtencClinicasXAfiliadoEntidad> getDatosAuditoria(String radicado)
        {
            B_AtencClinicasXAfiliados oBAtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();
            var query = from item in oBAtencClinicasXAfiliados.getDatosAuditoria(radicado).AsEnumerable()
                        select new AtencClinicasXAfiliadoEntidad
                        {
                            docIden = item.docIden,
                            tipoDoc = item.tipoDoc,
                            nombreCompleto = item.nombreCompleto,
                            fecIngreso = item.fecIngreso,
                            diasEstancia = item.diasEstancia,
                            codDx = item.codDx,
                            dx = item.dx,
                            medico = item.medico,
                            estadoAtenc = item.estadoAtenc                            
                        };
            return query.ToList<AtencClinicasXAfiliadoEntidad>();
        }
    }
}