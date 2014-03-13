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
                txtFechaIngreso_CalendarExtender.StartDate = DateTime.Now.AddMonths(-1);
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
            AtencClinicasEntidad eAten = new AtencClinicasEntidad();
            eAten.docIden = txtDocumento.Text;
            eAten.idTipoDoc = Int32.Parse(((DropDownList)ctrDdlTiposDoc.FindControl("ddlTipoDoc")).SelectedValue);
            eAten.apellidoA = txtApellido_a.Text;
            eAten.apellidoB = txtApellido_b.Text;
            eAten.nombreA = txtNombre_a.Text;
            eAten.nombreB = txtNombre_b.Text;
            eAten.sexo = txtSexo.Text;
            eAten.fecIngreso = txtFechaIngreso.Text;
            eAten.horaIngreso = txtHoraIngreso.Text;
            eAten.diasEstancia = Int32.Parse(txtDiasEstancia.Value);
            eAten.especialidad = ((DropDownList) ctrDdlEspecialidad.FindControl("ddlEspecialidad")).SelectedValue;
            eAten.codDx = hfCodDxCie.Value;
            eAten.codDxRel = hfCodDxRel.Value;
            eAten.fecNacimiento = txtFecNacimiento.Text;
            eAten.edad = Int32.Parse(txtEdad.Value);
            eAten.tipoEdad= Int32.Parse(ddlTipoEdad.SelectedValue);
            eAten.medico = txtMedico.Text;
            eAten.contrato= Int32.Parse(((DropDownList)ctrDdlProgramas1.FindControl("ddlProgramas")).SelectedValue);
            eAten.tipoContrato = Int32.Parse(ddlTipoContrato.SelectedValue);
            eAten.idTipoAtencion = Int32.Parse(ddlTipoAtencion.SelectedValue);
            eAten.cama = txtCama.Text;
            eAten.pabellon = txtPabellon.Text;
            eAten.idUser = Int32.Parse(Session["idUser"].ToString());
            B_AtencClinicasXAfiliados oB_AtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();
            String radicado = oB_AtencClinicasXAfiliados.addAtencClinicasXAfiliados(eAten);
            limpiarControles();
            MessageBox.show("Se ha radicado exitosamente la atención con el número:" + radicado, 4, false);
        }

        private void limpiarControles()
        {
            txtDocumento.Text = "";
            txtApellido_a.Text = "";
            txtApellido_b.Text = "";
            txtNombre_a.Text = "";
            txtNombre_b.Text = "";
            txtSexo.Text = "";
            txtFechaIngreso.Text = "";
            txtHoraIngreso.Text = "";
            txtDiasEstancia.Value = "";
            hfCodDxCie.Value = "";
            hfCodDxRel.Value = "";
            txtFecNacimiento.Text = "";
            txtEdad.Value = "";
            ddlTipoEdad.SelectedValue = "0";
            txtMedico.Text = "";
            ddlTipoContrato.SelectedValue = "0";
            ddlTipoAtencion.SelectedValue = "0";
            txtCama.Text = "";
            txtPabellon.Text = "";
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
                txtSexo.Text = eAfil.sexo;
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
                txtSexo.Text = "";
                ((DropDownList)ctrDdlTiposDoc.FindControl("ddlTipoDoc")).SelectedValue = "0";
                ((DropDownList)ctrDdlTiposDoc.FindControl("ddlTipoDoc")).Focus();
            }
        }
        
    }
}