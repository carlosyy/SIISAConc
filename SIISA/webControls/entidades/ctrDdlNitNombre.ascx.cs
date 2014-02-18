using System;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.entidades
{
    public partial class ctrDdlNitNombre : System.Web.UI.UserControl
    {
        B_Entidad oBEntidad = new B_Entidad();

        public delegate void DropDownListCommandEventHandler(DropDownListCommandEventArgs e);
        public event DropDownListCommandEventHandler DropDownListSelectedIndexChanged;

        public class DropDownListCommandEventArgs
        {
            public String nitEntidad { get; protected set; }
            public String nombreEntidad { get; protected set; }

            public DropDownListCommandEventArgs(String nitEntidad, String nombreEntidad)
            {
                this.nitEntidad = nitEntidad;
                this.nombreEntidad = nombreEntidad;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void busqEntidad(String busqEntidad, Boolean entidadCapitada)
        {
            ddlNitNombre.DataSource = oBEntidad.GetNitNombreOpcRecobro(nitNombre: busqEntidad, entidadCapitada: entidadCapitada);
            bindDdlNitNombre();
        }

        private void setItem()
        {
            if (ddlNitNombre.Items.Count == 2)
            {
                ddlNitNombre.SelectedIndex = 1;
                if (DropDownListSelectedIndexChanged != null)
                {
                    DropDownListSelectedIndexChanged(new DropDownListCommandEventArgs(this.ddlNitNombre.SelectedValue, ddlNitNombre.SelectedItem.ToString()));
                }
            }
        }

        public void setEntidad(String nitEntidad)
        {
            ddlNitNombre.DataSource = oBEntidad.getEntidadesxNit(nitEntidad);
            bindDdlNitNombre();
        }

        private void bindDdlNitNombre()
        {
            ddlNitNombre.DataTextField = "entidad";
            ddlNitNombre.DataValueField = "nit";
            ddlNitNombre.DataBind();
            setItem();
        }

        protected void ddlNitNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNitNombre.SelectedValue != "0" && ddlNitNombre.SelectedValue != "")
            {
                Session["nitIPS"] = ddlNitNombre.SelectedValue;
            }
            if (DropDownListSelectedIndexChanged != null)
            {                
                DropDownListSelectedIndexChanged(new DropDownListCommandEventArgs(this.ddlNitNombre.SelectedValue, ddlNitNombre.SelectedItem.ToString()));
            }
        }

        protected void ddlNitNombre_DataBound(object sender, EventArgs e)
        {
            ddlNitNombre.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }        
    }
}