using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entities;

namespace SIISAConc.Concurrencia
{
    public partial class concurrencia : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnlConcurrencia.Visible = false;
                txtBusqIPS.Text = "860066191";
                buscarEntidad();
            }
        }

        protected void txtBusqIPS_TextChanged(object sender, EventArgs e)
        {
            buscarEntidad();
        }

        private void buscarEntidad()
        {
            ctrDdlNitNombre.busqEntidad(txtBusqIPS.Text, false);
            DropDownList ddlNitNombre = ((DropDownList) ctrDdlNitNombre.FindControl("ddlNitNombre"));

            if (ddlNitNombre.SelectedValue != "0" && ddlNitNombre.SelectedValue != "")
            {
                Session["nitIPS"] = ddlNitNombre.SelectedValue;
                btnBuscar.Focus();
            }
            else
            {
                ddlNitNombre.Focus();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Session["nitIPS"] == null || Session["nitIPS"].ToString() == "")
            {
                pnlConcurrencia.Visible = false;
                pnlEstablecerIPS.Visible = true;
            }
            else
            {
                pnlConcurrencia.Visible = true;
                pnlEstablecerIPS.Visible = false;
                ctrBusqueda.llenarGrilla(orden: 7);
            }
        }

        [WebMethod]
        public static List<DxEntidad> getDx(String busqDx, Int32 top)
        {
            B_Dx oBDx = new B_Dx();
            var query = from item in oBDx.getBusqDx(busqDx, top).AsEnumerable()
                select new DxEntidad
                {
                    codDx = item.codDx,
                    codYDx = item.codYDx
                };
            return query.ToList<DxEntidad>();
        }

        [WebMethod]
        public static String getEdad(String fechaNacimiento)
        {
            DateTime fechaNac = DateTime.Parse(fechaNacimiento);
            int years = -1, months = -1, days = -1;
            timeSpanToDate(DateTime.Now, fechaNac, out years, out months, out days);
            String retorno = null;
            if (years > 0)
            {
                retorno = years + ",1";
            }
            else
            {
                if (months > 0)
                {
                    retorno = months + ",2";
                }
                else
                {
                    if (days > 0)
                    {
                        retorno = days + ",3";
                    }
                }
            }
            return retorno;
        }

        public static void timeSpanToDate(DateTime d1, DateTime d2, out int years, out int months, out int days)
        {
            if (d1 < d2)
            {
                DateTime d3 = d2;
                d2 = d1;
                d1 = d3;
            }

            // compute difference in total months
            months = 12 * (d1.Year - d2.Year) + (d1.Month - d2.Month);

            // based upon the 'days',
            // adjust months & compute actual days difference
            if (d1.Day < d2.Day)
            {
                months--;
                days = DateTime.DaysInMonth(d2.Year, d2.Month) - d2.Day + d1.Day;
            }
            else
            {
                days = d1.Day - d2.Day;
            }
            // compute years & actual months
            years = months / 12;
            months -= years * 12;
        }

        [WebMethod]
        public static List<MedicosEntidad> getMedicos(String nombreMedico)
        {
            B_Medicos oBMedicos = new B_Medicos();
            var query = from item in oBMedicos.getMedicosFiltro(nombreMedico: nombreMedico).AsEnumerable()
                select new MedicosEntidad
                {
                    idMedico = item.idMedico,
                    nombreMedico = item.nombreMedico
                };
            return query.ToList<MedicosEntidad>();
        }
    }
}