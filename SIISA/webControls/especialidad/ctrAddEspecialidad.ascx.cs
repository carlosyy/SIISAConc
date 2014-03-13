using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entities;

namespace SIISAConc.webControls.especialidad
{
    public partial class Ctrespecialidad : UserControl
    {
        Int32 _idEspecialidad = 0;
        B_Especialidad oBEspecialidad = new B_Especialidad();
        EspecialidadEntidad OEspecialidad = new EspecialidadEntidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            _idEspecialidad = Request.QueryString["IdEspecialidad"] != null ? Int32.Parse(Request.QueryString["IdEspecialidad"].ToString()) : 0;


            if (IsPostBack) return;
            if (_idEspecialidad == 0)
            {
                LimpiaFormulario(this);
                txtIdEspecialidad.Text = oBEspecialidad.GetMaxEspecialidad().ToString();
            }
            txtIdEspecialidad.Enabled = false;
            llenarEspecialidades();
        }

        public void llenarEspecialidades()
        {
            if (_idEspecialidad != 0)
            {
                foreach (EspecialidadEntidad eEspecialidad in oBEspecialidad.getEspecialidadID(_idEspecialidad))
                {
                    txtIdEspecialidad.Text = eEspecialidad.idEspecialidad.ToString();
                    txtEspecialidad.Text = eEspecialidad.especialidad;
                    txtSubMayor.Text = eEspecialidad.subMayor;
                    chbActivo.Checked = eEspecialidad.activo;
                    txtClase.Text = eEspecialidad.clase;
                }
            }
        }
        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            OEspecialidad.activo = chbActivo.Checked;
            OEspecialidad.idEspecialidad =Int32.Parse(txtIdEspecialidad.Text);
            OEspecialidad.clase = txtClase.Text;
            OEspecialidad.especialidad = txtEspecialidad.Text;
            OEspecialidad.subMayor = txtSubMayor.Text;

            if (_idEspecialidad == 0)
            {
                //Indica que es uno nuevo

                oBEspecialidad.AddEspecialidad(OEspecialidad);
                Response.Redirect("/Archivo/EspecialidadesListado.aspx");
            }
            else
            {
                // Indica que es un update de uno existente
                oBEspecialidad.UpdateEspecialidad(OEspecialidad);
                Response.Redirect("/Archivo/EspecialidadesListado.aspx");
            }
           }


        #region Metodos

        private void LimpiaFormulario(Control parent)
        {
            foreach (Control ctrControl in parent.Controls)
            {
                if (object.ReferenceEquals(ctrControl.GetType(), typeof(TextBox)))
                {
                    //textbox 
                    ((TextBox)ctrControl).Text = string.Empty;
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(DropDownList)))
                {
                    //dropdownlist 
                    ((DropDownList)ctrControl).SelectedIndex = -1;
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(CheckBox)))
                {
                    //checkboxes
                    ((CheckBox)ctrControl).Checked = false;
                }

                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(RadioButton)))
                {
                    //RadioButtons
                    ((RadioButton)ctrControl).Checked = false;
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(GridView)))
                {
                    //GridView
                    ((GridView)ctrControl).DataSource = null;
                    ((GridView)ctrControl).DataBind();
                }
                if (ctrControl.Controls.Count > 0)
                {
                    //Recursividad
                    LimpiaFormulario(ctrControl);
                }
            }
        }
        #endregion
    }
}