using Business;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIISAConc.webControls.concurrencia
{

	#region "Modificaciones"
	/* <autor>ZD</autor>
		    <fecha>17/09/2013 1500Z</fecha>
		    <justificacion>
	          Se comentarea la validación de que seleccione la entidad para el módulo de cargue de atenciones clínicas,
	 *				debido a que no es necesario para el proceso de racación, toca validar que cuando se llame se sepa hacia 
	 *				que módulo va o de donde se está llamando, para asi validar o no que el usuario ingrese la entidad.
				</justificacion>
		      <anterior>
							 if (((DropDownList)ctrDdlNitNombre.FindControl("ddlNitNombre")).SelectedValue == "")
            {
                MessageBox.show("Determine la entidad que genero el listado.");
            }
            else
            {
                B_Listados oBListados = new B_Listados();                
                oBListados.AddListadoAtencionClinicaArchivo(Session["ruta"].ToString(), ((DropDownList)ctrDdlNitNombre.FindControl("ddlNitNombre")).SelectedValue);
                Session["ruta"] = null;
                MessageBox.show("Archivo cargado exitosamente.");
            }
					</anterior>
		     <ahora>
		        string.IsNullOrEmpty(ovar.idTipoDoc.ToString()) ? "1" : ovar.idTipoDoc.ToString();
		     </ahora>*/

	#endregion
	public partial class ctrCargueListPacie : System.Web.UI.UserControl
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["error"] != null)
                {                    
                    lblErrores.Text = Session["error"].ToString();
                    Session["error"] = null;
                }
            }

        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            B_Rips oBRips = new B_Rips();
            lblErrores.Text = "";
            if (e.ContentType == "application/vnd.ms-excel" && ManejoTextos.obtenerTexto(e.FileName, 3, e.FileName.Length - 3) == "csv")
            {
                if (hfCarpetaTemporal.Value == "")
                {
                    hfCarpetaTemporal.Value = oBRips.crearCarpetaRips(Int32.Parse(Session["idUser"].ToString())).ToString();
                }

                String filePath = "C:\\Rips\\CarpetasTemporales" + "\\" + hfCarpetaTemporal.Value;
                Directory.CreateDirectory(filePath);
                AjaxFileUpload1.SaveAs(filePath + "\\" + e.FileName);
                hfRuta.Value = filePath;
                Session["ruta"] = filePath + "\\" + e.FileName;
                btnCargar.Enabled = true;                
            }
            else
            {                
                Session["error"] = lblErrores.Text;
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ruta"] == null || Session["error"] != null)
                {
                    MessageBox.show("No ha seleccionado ningún archivo. " + Session["error"] == null ? "" : Session["error"].ToString());
                }
                else
                {
                    B_Listados oBListados = new B_Listados();
                    oBListados.AddListadoAtencionClinicaArchivo(Session["ruta"].ToString(), ((DropDownList)ctrDdlNitNombre.FindControl("ddlNitNombre")).SelectedValue);
                    Session["ruta"] = null;
                    MessageBox.show("Archivo cargado exitosamente.");
                    this.txtBuscarProv.Text = "";
                    ((DropDownList)ctrDdlNitNombre.FindControl("ddlNitNombre")).SelectedValue = "0";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnBuscarEntidad_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["ruta"] == null || Session["error"] != null)
            {
                lblErrores.Text = "No ha seleccionado ningún archivo. " + Session["error"] == null ? "" : Session["error"].ToString();
            }
            else
            {
                if (txtBuscarProv.Text.Length < 6)
                {
                    MessageBox.show("Determine un criterio de busqueda mas largo.");
                }
                else
                {
                    ctrDdlNitNombre.busqEntidad(busqEntidad: txtBuscarProv.Text, entidadCapitada: false);
                    btnCargar.Enabled = true;
                }
            }
        }
    }
}