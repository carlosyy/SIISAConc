using System;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.concurrencia
{
    public partial class CtrPtesConcur : System.Web.UI.UserControl
    {
        B_PendientesAtencion oBPendientesAtencion = new B_PendientesAtencion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarGrilla();
            }
        }

        private void llenarGrilla()
        {
            gvServAtencConcur.DataSource = oBPendientesAtencion.getPendientesAtencionXidDatosUs(Int32.Parse(Session["idDatosUS"] == null ? "0" : Session["idDatosUS"].ToString()));
            gvServAtencConcur.DataBind();
        }
        

        protected void txtBusqServ_TextChanged(object sender, EventArgs e)
        {
            txtBusqServ.Text = txtBusqServ.Text.Replace("*", "%");
            lblErrorValid.Text = "";
            if (txtBusqServ.Text.Length < 5)
            {
                lblErrorValid.Text = "Debe especificar un criterio de busqueda mas largo.";
                txtBusqServ.Focus();
            }
            else
            {
                busqServicio(txtBusqServ.Text);
                ddlServicio.Focus();
            }
        }

        public void busqServicio(String servBuscar)
        {
            B_Servicios oBServicios = new B_Servicios();
            Entities.Servicios lServicios = oBServicios.getServiciosXBusq(servBuscar);
            if (lServicios.Count > 0)
            {
                ddlServicio.DataSource = lServicios;
                ddlServicio.DataTextField = "descripcion";
                ddlServicio.DataValueField = "codServ";
                ddlServicio.DataBind();
                ddlServicio.Enabled = true;

                if (ddlServicio.Items.Count != 2) return;
                ddlServicio.SelectedIndex = 1;                    
                txtCantidad.Focus();
            }
            else
            {
                ddlServicio.Enabled = false;
            }
        }

        protected void btnGuardarServ_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Entities.PendientesAtencionEntidad ePendientes = new Entities.PendientesAtencionEntidad();
            ePendientes.idDatosUS = Int32.Parse(Session["idDatosUS"].ToString());
            ePendientes.idAreaAtencion = Int32.Parse(((DropDownList)ctrAreasAtencion1.FindControl("ddlAreaAtencion")).SelectedValue);
            ePendientes.idPatologia = Int32.Parse(((DropDownList)ctrDdlPatologias.FindControl("ddlPatologia")).SelectedValue);
            ePendientes.codServ = ddlServicio.SelectedValue;
            ePendientes.cantServ = Int32.Parse(txtCantidad.Text);
            oBPendientesAtencion.addPendientesAtencion(ePendientes);
            llenarGrilla();
            MessageBox.show("Pendiente agregado.");
        }
    }
}