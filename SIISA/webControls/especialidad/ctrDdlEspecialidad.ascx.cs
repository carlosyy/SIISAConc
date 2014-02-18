using System;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.especialidad
{
    public partial class CtrEspecialidad : System.Web.UI.UserControl
    {
        B_Especialidad oBEspecilidad = new B_Especialidad();

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
                ddlEspecialidad.TabIndex = (short)(value++);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlEspecialidad.Attributes["onkeyup"] = "setValorES('" + ddlEspecialidad.ClientID + "');";
            }
        }

        private void llenarDdls()
        {            
            ddlEspecialidad.DataSource = oBEspecilidad.getEspecialidad();
            setPropiedades();            
        }

        private void setItem()
        {
            if (ddlEspecialidad.Items.Count == 2)
            {
                ddlEspecialidad.SelectedIndex = 1;
            }
        }


        private void setPropiedades()
        {
            ddlEspecialidad.DataTextField = "Especialidad";
            ddlEspecialidad.DataValueField = "idEspecialidad";
            ddlEspecialidad.DataBind();
            setItem();
        }

        public void setEspecialidad(String nit)
        {
            ddlEspecialidad.DataSource = oBEspecilidad.getEspecialidad3ro(nit);
            setPropiedades();
        }

        public void setEspecialidadID(Int32 idEspecialidad)
        {
            ddlEspecialidad.DataSource = oBEspecilidad.getEspecialidadID(idEspecialidad);
            setPropiedades();
            
        }

        public void setEspecialidad()
        {
            ddlEspecialidad.DataSource = oBEspecilidad.getEspecialidad();
            setPropiedades();
        }

        protected void ddlEspecialidad_DataBound(object sender, EventArgs e)
        {
            ddlEspecialidad.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }
    }
}