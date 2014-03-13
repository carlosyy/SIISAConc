using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entities;

namespace SIISAConc.webControls.concurrencia
{
    public partial class CtrAddPacteConcurr : UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDdlTipoAtencion();
                ctrDdlEspecialidad.setEspecialidad();
                ctrDdlProgramas1.buscaProgramaxNombre("");
                txtFechaIngreso_CalendarExtender.EndDate = DateTime.Now;
                txtFecNacimiento_CalendarExtender.EndDate = DateTime.Now;
            }
        }

        private void setDdlTipoAtencion()
        {
            B_TipoAtenc oBTipoAtenc= new B_TipoAtenc();
            ddlTipoAtencion.DataSource = oBTipoAtenc.getTipoAtenc();
            ddlTipoAtencion.DataTextField = "tipoAtenc";
            ddlTipoAtencion.DataValueField = "idTipoAtenc";
            ddlTipoAtencion.DataBind();
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
           //MessageBox.show("Registro guardado.");
            atencClinicasEntidad eAten = new atencClinicasEntidad();
            eAten.cama = txtCama.Text;
            eAten.codDx = hfCodDxCie.Value;
            eAten.codDxRel = hfCodDxRel.Value;
            eAten.diasEstancia = Int32.Parse(txtDiasEstancia.Text == "" ? "0" : txtDiasEstancia.Text);
            eAten.docIden = txtDocumento.Text;
            eAten.especialidad = ((DropDownList)ctrDdlEspecialidad.FindControl("ddlEspecialidad")).SelectedValue;
            //eAten.fecEgreso = txtFechaEgreso.Text;
            eAten.fecIngreso = txtFechaIngreso.Text;
            eAten.medico = txtMedico.Text;
            eAten.mesIngreso = txtFechaIngreso.Text;
            //eAten.motivoSalida = ddlMotivoSalida.SelectedValue;
            eAten.nitClinica = ((DropDownList)ctrDdlProgramas1.FindControl("ddlProgramas")).SelectedValue;
            //eAten.programa = Int32.Parse(txtContrato.Text == "" ? "0" : txtContrato.Text);
            eAten.idTipoAtencion = Int32.Parse(ddlTipoAtencion.SelectedValue);
            B_AtencClinicasXAfiliados oB_AtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();
            oB_AtencClinicasXAfiliados.addAtencClinicasXAfiliados(eAten);
        }

        protected void txtDocumento_OnTextChanged(object sender, EventArgs e)
        {
            B_Afiliados oB_Afiliados = new B_Afiliados();
            Boolean encontrado = false;
            foreach (AfiliadoEntidad eAfil in oB_Afiliados.getAfiliadoDoc(txtDocumento.Text))
            {
                txtApellido_a.Text = eAfil.apellido1;
                txtApellido_b.Text = eAfil.apellido2;
                txtNombre_a.Text = eAfil.nombre1;
                txtNombre_b.Text = eAfil.nombre2;
                ((DropDownList)ctrDdlTiposDoc.FindControl("ddlTipoDoc")).SelectedValue = eAfil.tipoDocId.ToString();
                encontrado = true;
                txtFechaIngreso.Focus();
            }
            if (!encontrado)
            {
                txtApellido_a.Text = "";
                txtApellido_b.Text = "";
                txtNombre_a.Text = "";
                txtNombre_b.Text = "";
                ((DropDownList)ctrDdlTiposDoc.FindControl("ddlTipoDoc")).SelectedValue = "0";
                ((DropDownList)ctrDdlTiposDoc.FindControl("ddlTipoDoc")).Focus();
            }
        }
        
    }
}