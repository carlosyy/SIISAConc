using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls
{
    public partial class ctrListUsuarios : System.Web.UI.UserControl
    {
        B_Usuarios oBUsuarios = new B_Usuarios();

        public delegate void RepeaterCommandEventHandler(RepeaterCommandEventArgs e);
        public event RepeaterCommandEventHandler RepeaterCommand;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPerfil"] != null)
                {
                    if (Session["idPerfil"].ToString() != "1")
                    {
                        rptUsuarios.DataSource = oBUsuarios.GetUsuarios(Int32.Parse(Session["idUser"].ToString()));
                        btnConsulta.Visible = false;
                        txtConsulta.Visible = false;
                        btnNuevo.Visible = false;
                    }
                    else
                    {
                        rptUsuarios.DataSource = oBUsuarios.GetUsuarios();                        
                    }
                    rptUsuarios.DataBind();
                }
                
            }
        }

        public class RepeaterCommandEventArgs
        {
            public Int32 idUser { get; protected set; }
            public String CommandName { get; protected set; }

            public RepeaterCommandEventArgs(String CommandName, Int32 idUser)
            {
                this.CommandName = CommandName;
                this.idUser = idUser;
            }
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            rptUsuarios.DataSource = oBUsuarios.GetUsuariosXBusq(txtConsulta.Text);
            rptUsuarios.DataBind();            
        }        

        protected void rptUsuarios_ItemCommand1(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            RepeaterItem rpt = (RepeaterItem)(((ImageButton)e.CommandSource).NamingContainer);
            Int32 idU = Int32.Parse(((Label)rpt.FindControl("lblIdUser")).Text);
            if (RepeaterCommand != null)
            {
                RepeaterCommand(new RepeaterCommandEventArgs(e.CommandName, idU));
            }
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (RepeaterCommand != null)
            {
                RepeaterCommand(new RepeaterCommandEventArgs(btnNuevo.CommandName, 0));
            }
        }
    }
}