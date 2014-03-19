using System;
using System.Data;

namespace SIISAConc.webControls.auditoria
{
    public partial class ctrListaAuditoria : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnBuscarAtencEstab_Click(object sender, EventArgs e)
        {
            ctrAtencEstablecidas.llenarGrilla(DateTime.Parse(txtFechaAtencion.Text == "" ? DateTime.Now.ToShortDateString() : txtFechaAtencion.Text));
        }
        
    }
}