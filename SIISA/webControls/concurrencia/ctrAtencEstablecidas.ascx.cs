using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.concurrencia
{
    public partial class CtrAtencEstablecidas : UserControl
    {
        B_AtencClinicasXAfiliados oB_AtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();               

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Session["idUser"] != null) return;
            //Session.Clear();
            //Response.Redirect("../../default.aspx");
        }
        public void llenarGrilla(DateTime fecha)
        {
            gvAuditorias.DataSource = oB_AtencClinicasXAfiliados.getAuditorias(Int32.Parse(Session["idUser"] == null ? "3" : Session["idUser"].ToString()), DateTime.Parse(fecha.ToString()).ToShortDateString());
            gvAuditorias.DataBind();
        }

        protected void btnGetAtencEstab_Click(object sender, EventArgs e)
        {
            llenarGrilla(DateTime.Now);
        }                
    }
}
