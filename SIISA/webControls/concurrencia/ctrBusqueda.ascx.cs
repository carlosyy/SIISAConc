using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entities;
using System.Text;

namespace SIISAConc.webControls.concurrencia
{
    public partial class CtrBusqueda : UserControl
    {
        B_AtencClinicasXAfiliados oB_AtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();

        private const int TamPage = 10;
        private static int _grupoPage = 1;
        private const int TamMuestraPages = 50;
        private int _limitInf = 0, _limitSup = 0, _limit = 0;
        private static decimal _numReg = 0;
        private static decimal _numPages = 0;
        private decimal _start = 1;
        private decimal _end = 0;
        private static decimal _currentSection = 0;
        private static int _pagina = 0;
        private bool _firstSection = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Session["idUser"] != null) return;
            //Session.Clear();
            //Response.Redirect("../../default.aspx");
        }


        public void llenarGrilla(Int32 orden)
        {
            Int32 cantRegs = oB_AtencClinicasXAfiliados.contarAtenciones(docIden: txtBusqDoc.Text, programa: Int32.Parse(hfPrograma.Value == "" ? "0" : hfPrograma.Value), nit: Session["nitIPS"].ToString(), codDx: hfCodDx.Value, fecDesc: txtFecDesde.Text, fecHasta: txtFecHasta.Text, filtroNombre: txtBusqNombre.Text);
            gvResultados.DataSource = paginacion(cantRegs: cantRegs, orden: orden);
            gvResultados.DataBind();
        }

        private atencClinicasXAfiliado paginacion(Int32 cantRegs, Int32 orden)
        {
            atencClinicasXAfiliado eCenso = null;
            btnLast.Visible = true;
            btnNext.Visible = true;
            btnFirst.Visible = true;
            btnPrev.Visible = true;
            ddlPagina.Visible = true;
            lblPagina.Text = "Pagina Actual: ";
            lblFiltrado.Text = " de 1";

            try
            {
                if (cantRegs > 100)
                {
                    ddlPagina.Items.Clear();
                    if (hfPagina.Value == "" && Session["pagina"] != null)
                    {
                        hfPagina.Value = Session["pagina"].ToString();
                    }

                    _numReg = cantRegs;
                    _numPages = Math.Ceiling((_numReg / TamPage));
                    if (((float)(_numPages - Math.Truncate(_numPages))) >= .5f)
                    {
                        _numPages = Math.Round((_numPages + (decimal)(.5))) + 1;
                    }
                    if ((hfPagina.Value == ""))
                    {
                        _pagina = 1;
                        _start = 1;
                        _end = TamPage;
                    }
                    else
                    {
                        _pagina = Int32.Parse(hfPagina.Value) > Int32.Parse(_numPages.ToString()) ? Int32.Parse(_numPages.ToString()) : Int32.Parse(hfPagina.Value);
                    }

                    //calculo el limite inferior
                    _limitInf = (_pagina - 1) * TamPage;
                    _limitSup = _pagina * TamPage;
                    _limit = _limitInf;

                    if (_limitInf == 0)
                        _limitInf = 1;

                    if (_limit == _limitInf)
                        _limitInf += 1;

                    if ((hfPagina.Value == ""))
                    {
                        _pagina = 1;
                        _start = 1;
                        _end = TamPage;
                    }
                    else
                    {
                        _currentSection = Math.Round((_pagina - 1) / TamPage + (decimal)(0.5));
                        if (_firstSection && _currentSection == 0)
                        {
                            _currentSection = 1;
                            _firstSection = false;
                        }
                        _start = (Int32)(_currentSection * TamPage) + 1;

                        if (_pagina < _numPages)
                        {
                            _end = _start + TamPage - 1;
                        }
                        else
                        {
                            _end = _numPages;
                        }

                        if (_end > _numPages)
                        {
                            _end = _numPages;
                        }
                    }

                    hfPagina.Value = _pagina.ToString();

                    Int32 j, index = 0, indexj = TamMuestraPages;
                    _grupoPage = Int32.Parse((Int32.Parse(hfPagina.Value) % TamMuestraPages == 0 ? Int32.Parse(hfPagina.Value) - 1 : Int32.Parse(hfPagina.Value)).ToString()) / TamMuestraPages;

                    if (_grupoPage > 0)
                    {
                        ddlPagina.Items.Insert(index, new ListItem("...", (_grupoPage * TamMuestraPages).ToString()));
                        index++;
                        indexj++;
                    }

                    for (j = ((_grupoPage * TamMuestraPages) + 1); index < indexj && j <= _numPages; j++, index++)
                    {
                        ddlPagina.Items.Insert(index, new ListItem((j).ToString(), (j).ToString()));
                    }

                    if (j < _numPages)
                    {
                        ddlPagina.Items.Insert(index, new ListItem("...", (j).ToString()));
                    }

                    ddlPagina.SelectedValue = hfPagina.Value;

                    if (_numPages == Decimal.Parse(hfPagina.Value))
                    {
                        btnLast.Visible = false;
                        btnNext.Visible = false;
                    }
                    else
                    {
                        btnLast.Visible = true;
                        btnNext.Visible = true;
                    }

                    lblFiltrado.Text = " de " + _numPages.ToString();
                    eCenso = oB_AtencClinicasXAfiliados.Buscar(docIden: txtBusqDoc.Text, programa: Int32.Parse(hfPrograma.Value == "" ? "0" : hfPrograma.Value), nit: hfNit.Value, codDx: hfCodDx.Value, fecDesde: txtFecDesde.Text, fecHasta: txtFecHasta.Text, filtroNombre: txtBusqNombre.Text, limitInf: _limitInf, limitSup: _limitSup, orden: orden);
                }
                else if (cantRegs == 0)
                {
                    _limitInf = 0;
                    _limitSup = 0;
                    btnLast.Visible = false;
                    btnNext.Visible = false;
                    btnFirst.Visible = false;
                    btnPrev.Visible = false;
                    ddlPagina.Visible = false;
                    MessageBox.show("No se han encontrado registros.");
                }
                else
                {
                    _limitInf = 0;
                    _limitSup = 0;
                    btnLast.Visible = false;
                    btnNext.Visible = false;
                    btnFirst.Visible = false;
                    btnPrev.Visible = false;
                    ddlPagina.Visible = false;
                    lblPagina.Text = "Pagina Actual: 1 ";
                    eCenso = oB_AtencClinicasXAfiliados.Buscar(docIden: txtBusqDoc.Text, programa: Int32.Parse(hfPrograma.Value == "" ? "0" : hfPrograma.Value), nit: hfNit.Value, codDx: hfCodDx.Value, fecDesde: txtFecDesde.Text, fecHasta: txtFecHasta.Text, filtroNombre: txtBusqNombre.Text, limitInf: 0, limitSup: 0, orden: orden);
                }
            }
            catch (Exception ex)
            {
                MessageBox.show("Ha ocurrido el siguiente error: " + ex.Message);
            }
            
            return eCenso;
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                llenarGrilla(orden: Int32.Parse(hfOrden.Value));
            }
            catch (Exception ex)
            {
                MessageBox.show("Ha ocurrido el siguiente error: " + ex.Message);
            }
        }

        protected void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            hfPagina.Value = ("1");
            llenarGrilla(orden: Int32.Parse(hfOrden.Value));
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if ((Int32.Parse(hfPagina.Value) <= 1)) return;
            hfPagina.Value = (Int32.Parse(hfPagina.Value) - 1).ToString();
            llenarGrilla(orden: Int32.Parse(hfOrden.Value));
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if ((Int32.Parse(hfPagina.Value) >= _numPages)) return;
            hfPagina.Value = (Int32.Parse(hfPagina.Value) + 1).ToString();
            llenarGrilla(orden: Int32.Parse(hfOrden.Value));
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            hfPagina.Value = _numPages.ToString();
            llenarGrilla(orden: Int32.Parse(hfOrden.Value));
        }

        protected void txtBusqEntidad_TextChanged(object sender, EventArgs e)
        {
            busqEntidad(txtBusqEntidad.Text);
        }

        public void busqEntidad(String busqEntidad)
        {
            B_Entidad oBEntidad = new B_Entidad();
            ddlNitNombre.DataSource = oBEntidad.GetNitNombre(nitNombre: busqEntidad);
            bindDdlNitNombre();
        }

        private void bindDdlNitNombre()
        {
            ddlNitNombre.DataTextField = "entidad";
            ddlNitNombre.DataValueField = "nit";
            ddlNitNombre.DataBind();
            setItem(ddlNitNombre);
        }

        protected void ddlNitNombre_DataBound(object sender, EventArgs e)
        {
            ddlNitNombre.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }

        protected void txtBusqDx_TextChanged(object sender, EventArgs e)
        {
            busqDx(txtBusqDx.Text);
        }

        protected void ddlPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfPagina.Value = ddlPagina.SelectedValue;
            Session["paginaRad"] = hfPagina.Value;
            llenarGrilla(orden: Int32.Parse(hfOrden.Value));
        }

        //private void llenarDdls()
        //{
        //    B_Dx oBDx = new B_Dx();
        //    ddlCodDescrip.DataSource = oBDx.getDx(true);
        //    ddlCodDescrip.DataTextField = "codYDx";
        //    ddlCodDescrip.DataValueField = "codDx";
        //    ddlCodDescrip.DataBind();
        //}

        public void busqDx(String busqDx)
        {
            B_Dx oBDx = new B_Dx();
            ddlCodDescrip.DataSource = oBDx.GetCodDesc(busqDx);
            ddlCodDescrip.DataTextField = "codYDx";
            ddlCodDescrip.DataValueField = "codDx";
            ddlCodDescrip.DataBind();
        }

        private void setItem(DropDownList ddl)
        {
            if (ddl.Items.Count == 2)
            {
                ddl.SelectedIndex = 1;
            }
        }

        public void buscaProgramaxNombre(String busqPrograma)
        {
            B_Programas oBProgramas = new B_Programas();
            ddlProgramas.DataSource = oBProgramas.getProgramasPrograma(busqPrograma);
            ddlProgramas.DataTextField = "programa";
            ddlProgramas.DataValueField = "idPrograma";
            ddlProgramas.DataBind();
            setItem(ddlProgramas);
        }

        protected void ddlProgramas_DataBound(object sender, EventArgs e)
        {
            ddlProgramas.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }

        protected void gvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:

                    e.Row.Cells[0].Attributes.Add("onmouseover", "showImg(2, true);");
                    e.Row.Cells[0].Attributes.Add("onmouseout", "showImg(2, false);");
                    e.Row.Cells[1].Attributes.Add("onmouseover", "showImg(6, true);");
                    e.Row.Cells[1].Attributes.Add("onmouseout", "showImg(6, false);");
                    e.Row.Cells[2].Attributes.Add("onmouseover", "showImg(0, true);");
                    e.Row.Cells[2].Attributes.Add("onmouseout", "showImg(0, false);");
                    e.Row.Cells[3].Attributes.Add("onmouseover", "showImg(1, true);");
                    e.Row.Cells[3].Attributes.Add("onmouseout", "showImg(1, false);");
                    e.Row.Cells[4].Attributes.Add("onmouseover", "showImg(3, true);");
                    e.Row.Cells[4].Attributes.Add("onmouseout", "showImg(3, false);");
                    e.Row.Cells[5].Attributes.Add("onmouseover", "showImg(4, true);");
                    e.Row.Cells[5].Attributes.Add("onmouseout", "showImg(4, false);");
                    e.Row.Cells[6].Attributes.Add("onmouseover", "showImg(5, true);");
                    e.Row.Cells[6].Attributes.Add("onmouseout", "showImg(5, false);");
                    e.Row.Cells[7].Attributes.Add("onmouseover", "showImg(8, true);");
                    e.Row.Cells[7].Attributes.Add("onmouseout", "showImg(8, false);");
                    e.Row.Cells[8].Attributes.Add("onmouseover", "showImg(7, true);");
                    e.Row.Cells[8].Attributes.Add("onmouseout", "showImg(7, false);");
                    break;
                case DataControlRowType.DataRow:
                    Label lblBtnEstablecer = (Label) e.Row.FindControl("lblBtnEstablecer");
                    lblBtnEstablecer.Text = " " + "<a ID=\"btnPage\" OnClick=\"javascript:establecerAuditar('" +
                                            gvResultados.DataKeys[e.Row.RowIndex].Values[0].ToString() + "', '" +
                                            ((Label)e.Row.FindControl("lblNombreUsuario")).Text +
                                            "','" + lblBtnEstablecer.ClientID + "');\"><img alt=\"sendMail\" src=\"../../Images/icons/bi/agregarenc.png\" style=\"width: 25px; height: 25px; cursor: pointer;\" /></a>";
                    break;

            }
        }

        protected void btnOrdenar_OnClick(object sender, EventArgs e)
        {
            llenarGrilla(orden: Int32.Parse(hfOrden.Value));
        }

        protected void btnNuevoPaciente_OnClick(object sender, EventArgs e)
        {
            /*Control ctrAddPacteConcurr = LoadControl("~/webControls/concurrencia/ctrAddPacteConcurr.ascx");
            ctrAddPacteConcurr.ID = "ctrAddPacteConcurr";
            pchControlNvoPaciente.Controls.Add(ctrAddPacteConcurr);*/
        }

        protected void txtBusqPrograma_TextChanged(object sender, EventArgs e)
        {
            buscaProgramaxNombre(txtBusqPrograma.Text);
        }
    }
}
