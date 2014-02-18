using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.patologias
{
    public partial class ctrPatologias1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                llenarDdls();
            }
        }

        private void llenarDdls()
        {
            B_Patologias oBPatologias = new B_Patologias();
            ddlPatologia.DataSource = oBPatologias.getPatologias();
            ddlPatologia.DataTextField = "patologia";
            ddlPatologia.DataValueField = "idPatologia";
            ddlPatologia.DataBind();
        }
    }
}