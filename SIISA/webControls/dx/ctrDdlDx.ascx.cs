using System;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.dx
{
    public partial class CtrDdlDx : System.Web.UI.UserControl
    {
        B_Dx oBDx = new B_Dx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //llenarDdls();
            }
        }
        
        private void llenarDdls()
        {
            ddlCodDescrip.DataSource = oBDx.getDx(true);
            ddlCodDescrip.DataTextField = "codYDx";
            ddlCodDescrip.DataValueField = "codDx";
            ddlCodDescrip.DataBind();
        }

        public void busqDx(String busqDx)
        {
            ddlCodDescrip.Items.Clear();
            ddlCodDescrip.Items.Add(new ListItem(".::Seleccione::.", "0"));
            ddlCodDescrip.DataSource = oBDx.GetCodDesc(busqDx);
            ddlCodDescrip.DataTextField = "codYDx";
            ddlCodDescrip.DataValueField = "codDx";
            ddlCodDescrip.DataBind();
        }
    }
}