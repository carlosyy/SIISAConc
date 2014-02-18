using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Business;
using Entities;


namespace SIISAConc.webControls.entidades
{
    public partial class ctrlistaEntidad : System.Web.UI.UserControl
    {
        B_Entidad BEntidad = null;

        //
        private static int tamPage = 10;
        private int limitInf = 0, limitSup = 0, limit = 0;
        private static decimal numReg = 0;
        private static decimal numPages = 0;
        private decimal start = 1;
        private decimal end = 0;
        private static decimal currentSection = 0;
        private static int pagina = 0;
        private bool firstSection = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            BEntidad = new B_Entidad();
            numReg = BEntidad.getCantEntidades(nombreEntidad: txtBuscarEnt.Text.Trim());
            if (!IsPostBack)
            {                
                hfEstado.Value = "n";                                  
                
                if (Request.QueryString["Page"] != null)
                {
                    hfEstado.Value = "r";
                    hfPagina.Value = Request.QueryString["Page"];                    
                }

                if (Request.QueryString["msj"] != null)
                {
                    lblMensaje.Text = ManejoTextos.Desencriptar(Request.QueryString["msj"].ToString());
                }

                LlenarGrid();
                
            }
            if (Request.Params["__EVENTTARGET"] == "ctrLblPages")
            {                
                LlenarGrid(txtBuscarEnt.Text.Trim());
            }
            
        }

        public void LlenarGrid(String busqEntidad ="")
        {
            gvEntidad.DataSource = Paginacion(busqEntidad);
            gvEntidad.DataBind();
        }

        private DataTable EntitieToDataTable(String busqEntidad = "")
        {
            Entities.Entidad eEntidad = null;
            BEntidad = new B_Entidad();
            if (limitInf == 0)
                eEntidad = BEntidad.GetEntidad(nombreEntidad: busqEntidad, limitInf: limitInf, limitSup: limitSup);
            else
                eEntidad = BEntidad.GetEntidad(nombreEntidad: busqEntidad, limitInf: limitInf, limitSup: limitSup);
            DataTable dt = new DataTable("Entidades");
            dt.Columns.Add(new DataColumn("capitado", typeof(int)));
            dt.Columns.Add(new DataColumn("codDane", typeof(string)));
            dt.Columns.Add(new DataColumn("codDepto", typeof(string)));            
            dt.Columns.Add(new DataColumn("codMpio", typeof(string)));            
            dt.Columns.Add(new DataColumn("depto", typeof(string)));
            dt.Columns.Add(new DataColumn("municipio", typeof(string)));
            dt.Columns.Add(new DataColumn("codTipoContrato", typeof(string)));
            dt.Columns.Add(new DataColumn("codTipoPrestador", typeof(string)));
            dt.Columns.Add(new DataColumn("correoElectronico", typeof(string)));
            dt.Columns.Add(new DataColumn("digitoVerif", typeof(string)));
            dt.Columns.Add(new DataColumn("direccion", typeof(string)));
            dt.Columns.Add(new DataColumn("entidad", typeof(string)));
            dt.Columns.Add(new DataColumn("nit", typeof(string)));
            dt.Columns.Add(new DataColumn("nitDV", typeof(string)));
            dt.Columns.Add(new DataColumn("nombreReg", typeof(string)));
            dt.Columns.Add(new DataColumn("represLegal", typeof(string)));
            dt.Columns.Add(new DataColumn("revision", typeof(string)));
            dt.Columns.Add(new DataColumn("telefono", typeof(string)));
            dt.Columns.Add(new DataColumn("idTipoDoc", typeof(string)));
            dt.Columns.Add(new DataColumn("TipoDoc", typeof(string)));
            dt.Columns.Add(new DataColumn("idZona", typeof(string)));
            dt.Columns.Add(new DataColumn("zona", typeof(string)));
            DataRow row;
            foreach (EntidadEntidad eEntidadEnt in eEntidad)
            {
                row = dt.NewRow();
                row["capitado"] = eEntidadEnt.capitado;
                row["codDane"] = eEntidadEnt.codDane;
                row["codDepto"] = eEntidadEnt.codDepto;
                row["codMpio"] = eEntidadEnt.codMpio;
                row["depto"] = eEntidadEnt.depto + "-" + eEntidadEnt.municipio;
                row["codTipoContrato"] = eEntidadEnt.codTipoContrato;
                row["codTipoPrestador"] = eEntidadEnt.codTipoPrestador;
                row["correoElectronico"] = eEntidadEnt.correoElectronico;
                row["digitoVerif"] = eEntidadEnt.digitoVerif;
                row["direccion"] = eEntidadEnt.direccion;
                row["entidad"] = eEntidadEnt.entidad;
                row["nit"] = eEntidadEnt.nit;
                row["nitDV"] = eEntidadEnt.nitDV;
                row["nombreReg"] = eEntidadEnt.nombreReg;
                row["represLegal"] = eEntidadEnt.represLegal;
                row["revision"] = eEntidadEnt.revision;
                row["telefono"] = eEntidadEnt.telefono;
                row["idTipoDoc"] = eEntidadEnt.idTipoDoc;
                row["TipoDoc"] = eEntidadEnt.TipoDoc;
                row["idZona"] = eEntidadEnt.idZona;
                row["zona"] = eEntidadEnt.zona;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private DataTable Paginacion(String busqEntidad = "")
        {
            numPages = (numReg / tamPage);
            //if (((float)(numPages - Math.Truncate(numPages))) >= .5f)
            //{
                numPages = Math.Round((numPages + (decimal)(.5)));
            //}
            if ((hfPagina.Value == ""))
            {
                pagina = 1;
                start = 1;
                end = tamPage;
            }
            else
            {                
                pagina = Int32.Parse(Math.Round(Decimal.Parse(hfPagina.Value)).ToString());
            }

            //calculo el limite inferior
            limitInf = (Int32)(pagina - 1) * tamPage;
            limitSup = (Int32)(pagina) * tamPage;
            limit = limitInf;

            if (limitInf == 0)
                limitInf = 1;

            if (limit == limitInf)
                limitInf += 1;

            if ((hfPagina.Value == ""))
            {
                pagina = 1;
                start = 1;
                end = tamPage;
            }
            else
            {
                currentSection = Math.Round(((decimal)(pagina - 1) / tamPage) + (decimal)(0.4));
                if (firstSection && currentSection == 0)
                {
                    currentSection = 1;
                    firstSection = false;
                }
                start = (int)(currentSection * tamPage) + 1;

                if (pagina < numPages)
                {
                    end = start + tamPage - 1;
                }
                else
                {
                    end = numPages;
                }

                if (end > numPages)
                {
                    end = numPages;
                }
            }
            hfPagina.Value = pagina.ToString();
            ctrLblPages.Text = "";
            if (ctrLblPages.Text == "")
            {
                Int32 j = 0;

                if (Int32.Parse(hfPagina.Value) > 3)
                    j = Int32.Parse(hfPagina.Value) - 3;
                else
                    j = Int32.Parse(hfPagina.Value) - 1;

                Int32 i;

                for (i = j; i < numPages && i < j + 5; i++)
                {
                    ctrLblPages.Text += " " + "<input type=\"button\" ID=\"btnPage\" runat=\"server\" OnClick=\"javascript:Paginacion(" + (i + 1) + ");\" value=\"" + (i + 1) + "\" />";
                }
                if (i < numPages)
                {
                    ctrLblPages.Text += " " + "<input type=\"button\" ID=\"btnPage\" runat=\"server\" OnClick=\"javascript:Paginacion(" + numPages + ");\" value=\"" + numPages + "\" />";
                }
            }

            return (EntitieToDataTable(busqEntidad));
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            hfPagina.Value = "1";
            gvEntidad.DataSource = Paginacion(busqEntidad:txtBuscarEnt.Text.Trim());
            gvEntidad.DataBind();
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Archivo/Entidad.aspx?nit=" + ManejoTextos.Encriptar("nuevo"));
        }

        protected void gvEntidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LinkButton lnkNIT = (e.CommandSource) as LinkButton;
            if (hfEstado.Value == "n")
            {
                Response.Redirect("/Archivo/Entidad.aspx?nit=" + ManejoTextos.Encriptar(lnkNIT.Text));
            }
            else if (hfEstado.Value == "r")
            {
                BEntidad = new B_Entidad();
                if (e.CommandName == "Select")
                {                    
                    String NIT = lnkNIT.Text;
                    Session["Entidad"] = BEntidad.getEntidadesxNit(NIT, 0, 0);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "close", "window.close();", true);
                }
            }
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            hfPagina.Value = ("1");
            LlenarGrid();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if ((int.Parse(hfPagina.Value) > 1))
            {
                hfPagina.Value = (int.Parse(hfPagina.Value) - 1).ToString();
                LlenarGrid();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if ((int.Parse(hfPagina.Value) < numPages))
            {
                hfPagina.Value = (int.Parse(hfPagina.Value) + 1).ToString();
                firstSection = true;
                LlenarGrid();
            }
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            hfPagina.Value = numPages.ToString();
            LlenarGrid();
        }
    }
}