using System;
using System.Web.UI;
using Business;
using Entities;
using System.Web.UI.WebControls;

namespace SIISAConc.webControls.concurrencia
{
    public partial class ctrNotas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarGrid();
            }
        }

        private void llenarGrid()
        {
            B_HallazgosAtencion oBHallazgosAtencion = new B_HallazgosAtencion();
            gvServAtencConcur.DataSource = oBHallazgosAtencion.GetHallazgoAtencionXidDatosUS(Int32.Parse(Session["idDatosUS"] == null ? "0" : Session["idDatosUS"].ToString()));
            gvServAtencConcur.DataBind();
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            HallazgoAtencionEntidad eHallazgo = new HallazgoAtencionEntidad();
            eHallazgo.hallazgoAtencion = txtHallazgo.Text;
            eHallazgo.idArea = Int32.Parse(((DropDownList)ctrAreasAtencion.FindControl("ddlAreaAtencion")).SelectedValue);
            eHallazgo.idAuditor = Int32.Parse(Session["idUser"].ToString());
            eHallazgo.idDatosUS = Int32.Parse(Session["idDatosUS"].ToString());
            eHallazgo.idEventosAdversosAtencion = Int32.Parse(((DropDownList)ctrEventosAdversos.FindControl("ddlEventosAdversos")).SelectedValue);
            eHallazgo.idInoportunidadAtencion = Int32.Parse(((DropDownList)ctrInoportunidad.FindControl("ddlInoportunidad")).SelectedValue);
            eHallazgo.idNoCalidadAtencion = Int32.Parse(((DropDownList)ctrNoCalidad.FindControl("ddlNoCalidad")).SelectedValue);
            eHallazgo.idPertinenciaAtencion = Int32.Parse(((DropDownList)ctrPertinencia.FindControl("ddlPertinencia")).SelectedValue);

            B_HallazgosAtencion oBHallazgosAtencion = new B_HallazgosAtencion();
            oBHallazgosAtencion.AddHallazgosAtencion(eHallazgo);
            MessageBox.show("Se agrego correctamente el hallazgo.");
            llenarGrid();
        }

        private void limpiarControles()
        {
            ((DropDownList)ctrEventosAdversos.FindControl("ddlEventosAdversos")).SelectedValue = "0";
            ((DropDownList)ctrAreasAtencion.FindControl("ddlAreaAtencion")).SelectedValue = "0";
            ((DropDownList)ctrInoportunidad.FindControl("ddlInoportunidad")).SelectedValue = "0";
            ((DropDownList)ctrNoCalidad.FindControl("ddlNoCalidad")).SelectedValue = "0";
            ((DropDownList)ctrPertinencia.FindControl("ddlPertinencia")).SelectedValue = "0";
            txtHallazgo.Text = "";
        }


        protected void gvServAtencConcur_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}