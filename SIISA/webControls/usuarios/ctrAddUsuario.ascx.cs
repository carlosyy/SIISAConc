using System;
using Business;
using Entities;

namespace SIISAConc.webControls
{
    public partial class ctrAddUsuario : System.Web.UI.UserControl
    {
        B_Usuarios oBUsuario = new B_Usuarios();
        B_Login oLogin = new B_Login();
        loginEntidad oLogEnt=new loginEntidad();
        UsuarioEntidad oUsuario = new UsuarioEntidad();

        public delegate void ImageClickEventHandler(ImageClickEventArgs e);
        public event ImageClickEventHandler ImageClick;

        protected void Page_Load(object sender, EventArgs e)
        {            

            if (!IsPostBack)
            {
                ddlPerfil.DataSource = oBUsuario.GetPerfiles();
                ddlPerfil.DataTextField = "Perfil";
                ddlPerfil.DataValueField = "PerfilID";
                ddlPerfil.DataBind();                
            }
        }

        public class ImageClickEventArgs
        {            
            public String CommandName { get; protected set; }

            public ImageClickEventArgs(String CommandName)
            {
                this.CommandName = CommandName;
            }
        }

        private void llenarDatosUsuario(Int32 idUser = 0)
        {
            foreach (var usuario in oBUsuario.GetUsuarios(idUser: idUser))
            {
                txtDocumento.Text = usuario.Documento;
                ddlTratamiento.SelectedValue = usuario.Tratamiento.ToString();
                txtNombres.Text = usuario.Nombre;
                ddlPerfil.SelectedValue = usuario.PerfilID.ToString();
                txtSucursal.Text = usuario.Sucursal;
                txtEmail.Text = usuario.Email;
                txtUsuario.Text = usuario.Nick;
                txtClave.Text = usuario.claveUsuario;
            }
        }

        public void nuevoUsuario()
        {
            hfEstado.Value = "a";
            txtDocumento.Text = "";            
            ddlTratamiento.SelectedValue = "1";
            txtNombres.Text = "";
            ddlPerfil.SelectedValue = "1";
            txtSucursal.Text = "";
            txtEmail.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            lblRespuesta.Text = "";
        }


        public void editarUsuario(Int32 idU, Int32 idPerfil)
        {
            hfUsuario.Value = idU.ToString();
            hfEstado.Value = "e";
            llenarDatosUsuario(idU);
            lblRespuesta.Text = "";
            if (idPerfil != 1)
            {
                ddlPerfil.Enabled = false;
                txtDocumento.Enabled = false;                
                ddlTratamiento.Enabled = false;
                txtSucursal.Enabled = false;
                txtEmail.Enabled = false;
                txtUsuario.Enabled = false;
                fulImagen.Enabled = false;
                txtNombres.Enabled = false;
            }
        }



        protected void btnGuardar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int x = 0;

            lblRespuesta.Text = "";
            if (hfEstado.Value == "a")
            {
                var varUsuario = oBUsuario.GetUsuarioDoc(txtDocumento.Text);

                if (varUsuario.Count == 1)
                {
                    lblRespuesta.Text = "Este usuario ya se encuentra en la base de datos.";
                }

                varUsuario = oBUsuario.GetUsuarioNick(txtUsuario.Text);
                if (varUsuario.Count == 1)
                {
                    lblRespuesta.Text = "Este usuario ya se encuentra en la base de datos.";
                }
            }

            if (txtClave.Text.Length < 6)
            {
                lblRespuesta.Text = "La clave es demasiado corta.";
            }
            if (lblRespuesta.Text == "")
            {
                oUsuario.Documento = txtDocumento.Text;
                oUsuario.Tratamiento = Int32.Parse(ddlTratamiento.SelectedValue);
                oUsuario.Nombre = txtNombres.Text;
                oUsuario.PerfilID = Int32.Parse(ddlPerfil.SelectedValue);
                oUsuario.Sucursal = txtSucursal.Text;
                oUsuario.Email = txtEmail.Text;
                oUsuario.Nick = txtUsuario.Text;
                oUsuario.claveUsuario = txtClave.Text;


                if (hfEstado.Value == "a")
                {
                    oUsuario.Activo = true;
                    x = oBUsuario.AddUsuario(oUsuario);
                }
                else if (hfEstado.Value == "e")
                {
                    oUsuario.UsuarioID = Int32.Parse(hfUsuario.Value);
                    oBUsuario.UpdateUsuarios(oUsuario);
                }

                lblRespuesta.Text = "Usuarios " + oUsuario.Nombre + " guardado en la base de datos";
            }

        }
    

        protected void btnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (ImageClick != null)
            {
                ImageClick(new ImageClickEventArgs(btnCancelar.CommandName));
            }
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            lblRespuesta.Text = "";
            var varUsuario = oBUsuario.GetUsuarioDoc(txtDocumento.Text);
            if (varUsuario.Count == 1)
            {
                lblRespuesta.Text = "Este usuario ya se encuentra en la base de datos.";                
            }
            
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            lblRespuesta.Text = "";
            var varUsuario = oBUsuario.GetUsuarioNick(txtUsuario.Text);
            if (varUsuario.Count == 1)
            {
                lblRespuesta.Text = "Este usuario ya se encuentra en la base de datos.";
            }            
        }       
            
    }
}