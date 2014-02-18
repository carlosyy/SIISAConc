using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.usuarios
{
    public partial class ctrNick : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDdls();
            }
        }

        private void llenarDdls()
        {
            B_Usuarios oUsuarios = new B_Usuarios();
            ddlNick.DataSource = oUsuarios.getNicks(0);
            ddlNick.DataTextField = "Nick";
            ddlNick.DataValueField = "UsuarioID";
            ddlNick.DataBind();
            ddlNick.Items.Insert(0, new ListItem("", "0"));
        }       
    }
}