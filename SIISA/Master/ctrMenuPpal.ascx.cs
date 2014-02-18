using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIISAConc.Master
{
    public partial class ctrMenuPpal : System.Web.UI.UserControl
    {
        B_Objetos oBObjetos = new B_Objetos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["idPerfil"] != null)
                {
                    llenaMenu(int.Parse(Session["idPerfil"].ToString()));
                }
            }
        }

        public void llenaMenu(Int32 idPerfil)
        {
            FirstLevelMenuRepeater.DataSource = oBObjetos.getObjetosXPerfil(idPerfil, 0);            
            FirstLevelMenuRepeater.DataBind();
            Label lbl = (Label)Page.Master.FindControl("lblPerfil");
            lbl.Text = Session["nombrePerfil"].ToString();
            Label lbl1 = (Label)Page.Master.FindControl("lblUsuario");
            lbl1.Text = Session["nombreUsuario"].ToString();
        }

        protected void FirstLevelMenuRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void FirstLevelMenuRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                Int32 nivel = Int32.Parse(DataBinder.Eval(e.Item.DataItem, "idObjeto").ToString().Trim());
                Repeater subMenu = (Repeater)e.Item.FindControl("SecondLevelMenuRepeater");
                subMenu.DataSource = oBObjetos.getObjetosXPerfil(Int32.Parse(Session["idPerfil"].ToString()), nivel);
                subMenu.DataBind();
                //GetSubMenuItems(nivel);                
                ////FourthLevelMenuRepeater.DataSource = SecondLevelMenuItems;
                //FourthLevelMenuRepeater.DataBind();
            } 
        }
    }
}