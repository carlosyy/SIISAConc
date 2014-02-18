using System;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.dane
{
    public partial class ctrDeptoMpio : System.Web.UI.UserControl
    {
        B_Entidad oBEntidad = new B_Entidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenaDdls();
                LLenarMunicipios();
                LlenarcodDane();
            }
        }

        private void llenaDdls()
        {            

            ddlDepartamento.DataSource = oBEntidad.getDeptos();
            ddlDepartamento.DataTextField = "depto";
            ddlDepartamento.DataValueField = "codDepto";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarMunicipios();
        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
           codDane.Text = ddlDepartamento.SelectedValue + ddlMunicipio.SelectedValue;
        }

        public void LLenarMunicipios()
        {
            ddlMunicipio.DataSource = oBEntidad.getMpiosDeptos(ddlDepartamento.SelectedValue);
            ddlMunicipio.DataTextField = "municipio";
            ddlMunicipio.DataValueField = "codMpio";
            ddlMunicipio.DataBind();
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccione...", "0")); 
        }
        public void LlenarcodDane()
        {
            codDane.Text = ddlDepartamento.SelectedValue + ddlMunicipio.SelectedValue;
        }

        public void llenarDane(String codDane)
        {

            ddlDepartamento.SelectedValue = ManejoTextos.obtenerTexto(codDane, 2, 0);
            LLenarMunicipios();
            ddlMunicipio.SelectedValue = ManejoTextos.obtenerTexto(codDane, 3, 2);

        }

    }
}