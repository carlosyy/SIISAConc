using Business;
using System;
using System.Data;

namespace SIISAConc.webControls.dx
{
    public partial class CtrDxLista : System.Web.UI.UserControl
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
                dt.Columns.Add("codDx");
                dt.Columns.Add("descripDx");
                dt.Columns.Add("dxPpal");                
                dt.Rows.Add();
                gvDxAtencion.DataSource = dt;
                gvDxAtencion.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.show(ex.Message);
            }

        }
    }
}