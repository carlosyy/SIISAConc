using System;
using System.Web.UI;
using Business;

namespace SIISAConc.webControls.especialidad
{
    public partial class CtrListaEspecialidad : UserControl
    {
        B_Especialidad BEspecialidad = new B_Especialidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptEspecialidades.DataSource = BEspecialidad.getEspecialidad();
                rptEspecialidades.DataBind();
            } 
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Archivo/Especialidades.aspx?IdEspecialidad=0");
                      
        }
    }
}