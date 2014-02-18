using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entities;
using System.Data;

namespace SIISAConc.webControls.entidades
{

	#region "Comentario de modificaciones"
	/*<autor>ZD</autor>
		    <fecha>09/09/2013 1521Z</fecha>
		    <justificacion>
	 					Se valida que si el tipo de documento viene NULL o en 0 asigne 1=CC por defecto.
				</justificacion>
		      <anterior>
							EEntidad.idTipoDoc.ToString()
	 			</anterior>
		     <ahora>
		        string.IsNullOrEmpty(EEntidad.idTipoDoc.ToString()) ? "1" : EEntidad.idTipoDoc.ToString();
		     </ahora>*/
	#endregion
	public partial class ctrAddEntidad : System.Web.UI.UserControl
	{
		String Nit = "";
		B_Entidad oBEntidad = null;
		EntidadEntidad OEntidad = new EntidadEntidad();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["Nit"] != "null")
			{
				if (Request.QueryString["Nit"] != null)
				{
					Nit = ManejoTextos.Desencriptar(Request.QueryString["Nit"].ToString());
					ActivaFormulario(this);
				}
				else
				{
					Nit = "";
				}
			}

			if (Nit == "nuevo")
			{
				btnGuardar.Visible = true;
				btnEditar.Visible = false;
				ActivaFormulario(this, true);
			}
			else
			{
				btnGuardar.Visible = false;
			}

			if (Request.QueryString["ed"] != null)
			{
				btnGuardar.Visible = true;
				btnEditar.Visible = false;
				ActivaFormulario(this, true);
			}

			if (!IsPostBack)
			{
				llenaDdls();
				LLenarEntidad();
			}
		}

		private void llenaDdls()
		{
			oBEntidad = new B_Entidad();
			ddlTipoDoc.DataSource = oBEntidad.getTipoDoc();
			ddlTipoDoc.DataTextField = "TipoDoc";
			ddlTipoDoc.DataValueField = "idTipoDoc";
			ddlTipoDoc.DataBind();
			ddlZona.DataSource = oBEntidad.getZona();
			ddlZona.DataTextField = "zona";
			ddlZona.DataValueField = "idZona";
			ddlZona.DataBind();
		}

		public void LLenarEntidad()
		{
			DropDownList ddlDepartamento = (DropDownList)ctrDeptoMpio1.FindControl("ddlDepartamento");
			DropDownList ddlMunicipio = (DropDownList)ctrDeptoMpio1.FindControl("ddlMunicipio");

			if (Nit != "")
			{
				foreach (var EEntidad in oBEntidad.getEntidadesxNit(Nit))
				{
					txtNIT.Enabled = false;
					ddlTipoDoc.SelectedValue = string.IsNullOrEmpty(EEntidad.idTipoDoc.ToString()) ? "1" : EEntidad.idTipoDoc.ToString();
					txtNIT.Text = EEntidad.nit.ToString();
					txtDigVerif.Text = EEntidad.digitoVerif.ToString();
					txtEntidad.Text = EEntidad.entidad.ToString();
					ddlDepartamento.SelectedValue = EEntidad.codDepto;
					ddlMunicipio.SelectedValue = EEntidad.codMpio;
					txtDireccion.Text = EEntidad.direccion.ToString();
					txtTelefono.Text = EEntidad.telefono.ToString();
					ddlZona.SelectedValue = EEntidad.zona.ToString();
					txtRegion.Text = EEntidad.nombreReg.ToString();
					txtMail.Text = EEntidad.correoElectronico.ToString();
					ctrDeptoMpio1.llenarDane(EEntidad.codDane);
				}
			}
		}

		protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
		{
			LimpiaFormulario(this);
			txtNIT.Enabled = true;
		}

		protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
		{
			lblMensaje.Text = "";
			if (validarDatos())
			{
				oBEntidad = new B_Entidad();
				TextBox codDane = (TextBox)ctrDeptoMpio1.FindControl("codDane");
				OEntidad.nit = txtNIT.Text.ToString();
				OEntidad.TipoDoc = ddlTipoDoc.SelectedValue.ToString();
				OEntidad.digitoVerif = Int32.Parse(txtDigVerif.Text.ToString());
				OEntidad.entidad = txtEntidad.Text.ToString();
				OEntidad.codDane = codDane.Text;
				OEntidad.direccion = txtDireccion.Text;
				OEntidad.telefono = txtTelefono.Text;
				OEntidad.idZona = Int32.Parse(ddlZona.SelectedValue.ToString());
				OEntidad.nombreReg = txtRegion.Text.ToString();
				OEntidad.correoElectronico = txtMail.Text;
				if (txtNIT.Enabled == true)
				{
					// Indica que es un registro nuevo para agregar y se redirecciona a la pagina inicial
					int result = 0;
					try
					{
						String nombEntidad = oBEntidad.GetNombrexNit(txtNIT.Text.ToString());
						if (nombEntidad == "")
						{
							result = oBEntidad.AddEntidad(OEntidad);

							Response.Redirect("/Archivo/EntidadListado.aspx?msj=" + ManejoTextos.Encriptar("Se ha creado la entidad en el sistema."));
						}
						else
						{
							Response.Redirect("/Archivo/EntidadListado.aspx?msj=" + ManejoTextos.Encriptar("La entidad: " + nombEntidad + " ya se encuentra en el sistema."));
						}
					}
					catch
					{

					}

				}
				else
				{
					int result = 0;
					result = oBEntidad.UpdateEntidad(OEntidad);
					Response.Redirect("/Archivo/EntidadListado.aspx?msj=" + ManejoTextos.Encriptar("Se ha actualizado correctamente la informacion de la entidad en el sistema."));
				}
			}

		}

		private bool validarDatos()
		{
			Boolean validar = true;
			if (((TextBox)ctrDeptoMpio1.FindControl("codDane")).Text.Length != 5)
			{
				lblMensaje.Text += "</br>Debe establecer el municipio de la entidad.";
				validar = false;
			}

			if (txtNIT.Text.Length < 5)
			{
				lblMensaje.Text += "</br>Debe establecer el NIT de la entidad.";
				validar = false;
			}

			if (txtEntidad.Text.Length < 5)
			{
				lblMensaje.Text += "</br>Debe establecer el nombre de la entidad.";
				validar = false;
			}

			if (ddlTipoDoc.SelectedValue == "" || ddlTipoDoc.SelectedValue == "NULL")
			{
				lblMensaje.Text += "</br>Debe establecer el tipo de Documento de la entidad.";
				validar = false;
			}

			return validar;
		}


		protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("/Archivo/EntidadListado.aspx");
		}

		protected void txtNIT_TextChanged(object sender, EventArgs e)
		{
			lblMensaje.Text = "";
			oBEntidad = new B_Entidad();
			String nombEntidad = oBEntidad.GetNombrexNit(txtNIT.Text.ToString());
			if (nombEntidad != "")
			{
				lblMensaje.Text = "La entidad: " + nombEntidad + " ya se encuentra en el sistema.";
			}
		}

		protected void btnEditar_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("/Archivo/Entidad.aspx?nit=" + ManejoTextos.Encriptar(txtNIT.Text) + "&ed=1");
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

		private void ActivaFormulario(Control parent, Boolean si = false)
		{
			foreach (Control ctrControl in parent.Controls)
			{
				if (object.ReferenceEquals(ctrControl.GetType(), typeof(TextBox)))
				{
					//textbox 
					((TextBox)ctrControl).Enabled = si;
				}
				else if (object.ReferenceEquals(ctrControl.GetType(), typeof(DropDownList)))
				{
					//dropdownlist 
					((DropDownList)ctrControl).Enabled = si;
				}
				else if (object.ReferenceEquals(ctrControl.GetType(), typeof(CheckBox)))
				{
					//checkboxes
					((CheckBox)ctrControl).Enabled = si;
				}

				else if (object.ReferenceEquals(ctrControl.GetType(), typeof(RadioButton)))
				{
					//RadioButtons
					((RadioButton)ctrControl).Enabled = si;
				}
				if (ctrControl.Controls.Count > 0)
				{
					//Recursividad
					ActivaFormulario(ctrControl);
				}

			}
		}
		#endregion
	}
}