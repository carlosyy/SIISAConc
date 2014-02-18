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
            lblUsuario.Text = e.nombreUsuario.ToString();
            Session["nombreUsuario"] = e.nombreUsuario.ToString();
            Label lblPerfil = (Label)Master.FindControl("lblPerfil");
            lblPerfil.Text = e.perfil.ToString();
            Session["nombrePerfil"] = e.perfil.ToString();
            pnlLogin.Visible = false;            
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
					SendEmail sem = new SendEmail();
					MessageBox.show(sem.SendingEmail("carlos.yy@gmail.com", "Hola Mundo", "Test de prueba"));
        }
    }
}