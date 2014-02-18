using System;

namespace SIISAConc
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblError.Text = Session["error"].ToString();
            }
        }
    }
}