﻿using System;
using System.Web.UI;
using Business;
using Entities;
using System.Web.UI.WebControls;
using System.Data;

namespace SIISAConc.webControls.Hallazgos
{
    public partial class ctrHallazgos : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //llenarGrid();
                llenarDdlTipoHallazgo();
                bindEncabezadoGrilla();
            }
        }

        private void bindEncabezadoGrilla()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("codServ");
                dt.Columns.Add("descripServ");
                dt.Columns.Add("noAutorizacion");
                dt.Columns.Add("concepto");
                dt.Columns.Add("Notif");
                dt.Rows.Add();
                gvHallAtencion.DataSource = dt;
                gvHallAtencion.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.show(ex.Message);
            }

        }

        private void llenarDdlTipoHallazgo()
        {
            B_TipoHallazgo oB_TipoHallazgo = new B_TipoHallazgo();
            ddlTipoHallazgo.DataSource = oB_TipoHallazgo.getTipoHallazgo();
            ddlTipoHallazgo.DataTextField = "tipoHallazgo";
            ddlTipoHallazgo.DataValueField = "idTipoHallazgo";
            ddlTipoHallazgo.DataBind();
        }

        protected void BtnEnviarMail_Click(object sender, EventArgs e)
        {
            SendEmail sMail = new SendEmail();
            String okEnviado= sMail.SendingEmail(TxtPara.Text, TxtAsunto.Text, TxtMsj.Text);
            switch (okEnviado)
            {
                case "Enviado":
                    MessageBox.show("El correo se envio satisfactoriamente.", 2);
                    break;
                default:
                    MessageBox.show(okEnviado);
                    break;
            }
        }

        //public void llenarGrid()
        //{
        //    B_HallazgosAtencion oBHallazgosAtencion = new B_HallazgosAtencion();
        //    gvServAtencConcur.DataSource = oBHallazgosAtencion.GetHallazgoAtencionXRadicado(Session["idDatosUS"] == null ? "0" : Session["idDatosUS"].ToString());
        //    gvServAtencConcur.DataBind();
        //}

        //protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        //{
        //    HallazgoAtencionEntidad eHallazgo = new HallazgoAtencionEntidad();
        //    eHallazgo.hallazgoAtencion = txtHallazgo.Text;
        //    eHallazgo.idArea = Int32.Parse(((DropDownList)ctrAreasAtencion.FindControl("ddlAreaAtencion")).SelectedValue);
        //    eHallazgo.idAuditor = Int32.Parse(Session["idUser"].ToString());
        //    eHallazgo.idDatosUS = Int32.Parse(Session["idDatosUS"].ToString());
        //    eHallazgo.idEventosAdversosAtencion = Int32.Parse(((DropDownList)ctrEventosAdversos.FindControl("ddlEventosAdversos")).SelectedValue);
        //    eHallazgo.idInoportunidadAtencion = Int32.Parse(((DropDownList)ctrInoportunidad.FindControl("ddlInoportunidad")).SelectedValue);
        //    eHallazgo.idNoCalidadAtencion = Int32.Parse(((DropDownList)ctrNoCalidad.FindControl("ddlNoCalidad")).SelectedValue);
        //    eHallazgo.idPertinenciaAtencion = Int32.Parse(((DropDownList)ctrPertinencia.FindControl("ddlPertinencia")).SelectedValue);

        //    B_HallazgosAtencion oBHallazgosAtencion = new B_HallazgosAtencion();
        //    oBHallazgosAtencion.AddHallazgosAtencion(eHallazgo);
        //    MessageBox.show("Se agrego correctamente el hallazgo.");
        //    llenarGrid();
        //}

        //private void limpiarControles()
        //{
        //    ((DropDownList)ctrEventosAdversos.FindControl("ddlEventosAdversos")).SelectedValue = "0";
        //    ((DropDownList)ctrAreasAtencion.FindControl("ddlAreaAtencion")).SelectedValue = "0";
        //    ((DropDownList)ctrInoportunidad.FindControl("ddlInoportunidad")).SelectedValue = "0";
        //    ((DropDownList)ctrNoCalidad.FindControl("ddlNoCalidad")).SelectedValue = "0";
        //    ((DropDownList)ctrPertinencia.FindControl("ddlPertinencia")).SelectedValue = "0";
        //    txtHallazgo.Text = "";
        //}


        //protected void gvServAtencConcur_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}
    }
}