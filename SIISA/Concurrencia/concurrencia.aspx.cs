using System;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}