using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
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

        }

        protected void txtBusqDx_OnTextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBusqDx.Text))
            {
                MessageBox.show("Determine el texto a buscar.");
            }
            else
            {
                ctrDdlDx1.busqDx(txtBusqDx.Text);
            }
        }

        protected void btnEditarDx_OnClick(object sender, EventArgs e)
        {
            DropDownList ddlCodDescrip = (DropDownList)ctrDdlDx1.FindControl("ddlCodDescrip");
            if (hfEditarDx.Value == "1")
            {
                txtDxCie.Text = ddlCodDescrip.SelectedValue == "0" ? "" : ddlCodDescrip.SelectedItem.Text;
                hfCodDxCie.Value = ddlCodDescrip.SelectedValue == "0" ? "" : ddlCodDescrip.SelectedValue;
            }
            else if (hfEditarDx.Value == "2")
            {
                txtDxRel.Text = ddlCodDescrip.SelectedValue == "0" ? "" : ddlCodDescrip.SelectedItem.Text;
                hfCodDxRel.Value = ddlCodDescrip.SelectedValue == "0" ? "" : ddlCodDescrip.SelectedValue;
            }
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
            eAten.nitClinica = ddlContrato.SelectedValue;
            //eAten.programa = Int32.Parse(txtContrato.Text == "" ? "0" : txtContrato.Text);
            eAten.tipoAtencion = txtTipoAtencionIngreso.Text;
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