using Business;
using System;

namespace SIISAConc.webControls.login
{
    public partial class ctrLogin : System.Web.UI.UserControl
    {
        B_Login oUsr = new B_Login();
        public delegate void ButtonCommandEventHandler(ButtonClickEventArgs e);
        public event ButtonCommandEventHandler ButtonClickCommand;

        public class ButtonClickEventArgs
        {
            public String nombreUsuario { get; protected set; }
            public String perfil { get; protected set; }

            public ButtonClickEventArgs(String nombreUsuario, String perfil)
            {
                this.nombreUsuario = nombreUsuario;
                this.perfil = perfil;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
							TextUsuario.Focus();
            }
        }

				protected void BtnIngresar_Click(object sender, EventArgs e)
				{
					LblMsg.Text = "Usuario o Clave errados.";
					Int32 id = oUsr.LoguinUsuario(TextUsuario.Text, TxtPass.Text);
					if (id > 0)
					{
						B_Usuarios oBUsuario = new B_Usuarios();
						foreach (var EUser in oBUsuario.GetUsuarios(id))
						{
							if (EUser.Activo)
							{
								Session["idUser"] = EUser.UsuarioID;
								Session["idPerfil"] = EUser.PerfilID;
								if (ButtonClickCommand != null)
								{
									ButtonClickCommand(new ButtonClickEventArgs(EUser.Nombre.ToString(), EUser.Perfil.ToString()));
								}
							}
							else
							{
								MessageBox.show("Su usuario esta inactivo, consulte con el administrador del sistema.");
								LblMsg.Text = "Su usuario esta inactivo.";
							}
						}
					}
				}
    }
}