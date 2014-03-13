using System;
using Business;
using Entities;

namespace SIISAConc.webControls.concurrencia
{
    public partial class ctrNotas1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var nombrePaciente = Session["PatientName"];

            if (nombrePaciente != null)

                lblPaciente.Text = string.Format("Notas de {0}", nombrePaciente);
        }


        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            B_Notes notes = new B_Notes();

            String id = Session["idDatosUS"] == null ? "" : Session["idDatosUS"].ToString();

            if (id == null) return;
            notes.AddNotes(new NotesEntidad
            {
                idDatosUS = Convert.ToInt32(id),
                nota = txtNota.Text,
            });
        }
    }
}