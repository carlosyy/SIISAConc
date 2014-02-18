using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.Controls.programas
{
    public partial class ctrDdlProgramas : System.Web.UI.UserControl
    {
        B_Programas oBProgramas = new B_Programas();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        private void setItem()
        {
            if (ddlProgramas.Items.Count == 2)
            {
                ddlProgramas.SelectedIndex = 1;
            }
        }

        public void buscaProgramaxNombre(String busqPrograma)
        {
            ddlProgramas.DataSource = oBProgramas.getProgramasPrograma(busqPrograma);
            ddlProgramas.DataTextField = "programa";
            ddlProgramas.DataValueField = "idPrograma";
            ddlProgramas.DataBind();
            setItem();
        }        

        protected void ddlProgramas_DataBound(object sender, EventArgs e)
        {
            ddlProgramas.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }
    }
}