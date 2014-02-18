using System;
using System.Web.UI;
using Business;

namespace SIISAConc.webControls.tiposDoc
{
    public partial class CtrDdlTiposDoc : UserControl
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
            B_TiposDoc oBTiposDoc = new B_TiposDoc();
            ddlTipoDoc.DataSource = oBTiposDoc.getTiposDoc();
            ddlTipoDoc.DataTextField = "tipoDoc";
            ddlTipoDoc.DataValueField = "idTipoDoc";
            ddlTipoDoc.DataBind();

        }

        private short _tabIndex;
        public short tabIndex

        {
            get
            {
                return _tabIndex;
            }
            set
            {
                _tabIndex = value;
                ddlTipoDoc.TabIndex = (short)(value++);

            }
        }   
    }
}