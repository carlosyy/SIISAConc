using Business;
using System;
using System.Data;

namespace SIISAConc.webControls.procedimientos
{
    public partial class ctrProcedimientos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindEncabezadoGrilla();
            }
        }

        private void bindEncabezadoGrilla()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("codServ");
                dt.Columns.Add("descripServ");
                dt.Columns.Add("noAutorizacion");
                dt.Columns.Add("concepto");
                dt.Columns.Add("pxPpal");
                dt.Rows.Add();
                gvServiciosAtencion.DataSource = dt;
                gvServiciosAtencion.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.show(ex.Message);
            }
            
        }
    }
}