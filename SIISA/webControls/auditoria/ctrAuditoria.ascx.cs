using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entities;

namespace SIISAConc.webControls.auditoria
{
    public partial class ctrAuditoria : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["rad"] != null)
                {
                    hfRadicado.Value = ManejoTextos.Desencriptar(Request.QueryString["rad"]);
                    llenarControles(hfRadicado.Value);
                }
            }
        }

        private void llenarControles(string radicado)
        {
            B_AtencClinicasXAfiliados oB_AtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();
            foreach (AtencClinicasXAfiliadoEntidad eAtencClinicasEntidad in oB_AtencClinicasXAfiliados.getDatosAuditoria(radicado))
            {
                txtDocumento.Text = eAtencClinicasEntidad.docIden;
                txtTipoDoc.Text = eAtencClinicasEntidad.tipoDoc;
                txtApellido_a.Text = eAtencClinicasEntidad.apellidoA;
                txtApellido_b.Text = eAtencClinicasEntidad.apellidoB;
                txtNombre_a.Text = eAtencClinicasEntidad.nombreA;
                txtNombre_b.Text = eAtencClinicasEntidad.nombreB;
                txtCama.Text = eAtencClinicasEntidad.cama;
                txtDiasEstancia.Text = eAtencClinicasEntidad.diasEstancia.ToString();
                txtDxCie.Text = eAtencClinicasEntidad.codDx + "-" + eAtencClinicasEntidad.dx;
                txtDxRel.Text = eAtencClinicasEntidad.codDxRel;
                txtFechaIngreso.Text = DateTime.Parse(eAtencClinicasEntidad.fecIngreso).ToShortDateString();
                txtHoraIngreso.Text = DateTime.Parse(eAtencClinicasEntidad.fecIngreso).ToShortTimeString();
                txtMedico.Text = eAtencClinicasEntidad.medico;
                txtSexo.Text = eAtencClinicasEntidad.sexo;
                txtEspecialidad.Text = eAtencClinicasEntidad.especialidad;
            }
        }
    }
}