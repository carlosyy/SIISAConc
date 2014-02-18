using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using SIISAConc.webControls.login;



namespace SIISAConc
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrLogin1.ButtonClickCommand += new ctrLogin.ButtonCommandEventHandler(ctrLogin1_ButtonClickCommand);

            if (Session["idUser"] != null)
                ctrLogin1.Visible = false;
        }

        void ctrLogin1_ButtonClickCommand(ctrLogin.ButtonClickEventArgs e)
        {            
            B_Objetos oBObjetos = new B_Objetos();
            Repeater rpt = (Repeater)Master.FindControl("ctrMenuPpal").FindControl("FirstLevelMenuRepeater");
            rpt.DataSource = oBObjetos.getObjetosXPerfil(Int32.Parse(Session["idPerfil"].ToString()), 0);
            rpt.DataBind();            
            Master.FindControl("pnlMenu").Visible = true;            
            Master.FindControl("pnlUsuarioLogueado").Visible = true;
            //Master.FindControl("pnlRedesSoc").Visible = false;
            Label lblUsuario = (Label)Master.FindControl("lblUsuario");
            lblUsuario.Text = e.nombreUsuario;
            Session["nombreUsuario"] = e.nombreUsuario;
            Label lblPerfil = (Label)Master.FindControl("lblPerfil");
            lblPerfil.Text = e.perfil;
            Session["nombrePerfil"] = e.perfil;
            pnlLogin.Visible = false;
            MessageBox.show("Bienvenido " + lblPerfil.Text + " " + lblUsuario.Text, tipoAlerta: 4, posicion: "bottom right");
        }
    }
}