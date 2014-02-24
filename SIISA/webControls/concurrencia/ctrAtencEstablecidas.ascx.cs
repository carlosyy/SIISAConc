using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.concurrencia
{
    public partial class CtrAtencEstablecidas : UserControl
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
            gvAuditorias.DataSource = oB_AtencClinicasXAfiliados.getAuditorias(Int32.Parse(Session["idUser"] == null ? "3" : Session["idUser"].ToString()), DateTime.Now.ToShortDateString());
            gvAuditorias.DataBind();
        }


        private void setItem(DropDownList ddl)
        {
            if (ddl.Items.Count == 2)
            {
                ddl.SelectedIndex = 1;
            }
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
                    e.Row.Cells[3].Attributes.Add("onmouseover", "showImg(3, true);");
                    e.Row.Cells[3].Attributes.Add("onmouseout", "showImg(3, false);");
                    e.Row.Cells[4].Attributes.Add("onmouseover", "showImg(4, true);");
                    e.Row.Cells[4].Attributes.Add("onmouseout", "showImg(4, false);");
                    e.Row.Cells[5].Attributes.Add("onmouseover", "showImg(5, true);");
                    e.Row.Cells[5].Attributes.Add("onmouseout", "showImg(5, false);");
                    e.Row.Cells[6].Attributes.Add("onmouseover", "showImg(8, true);");
                    e.Row.Cells[6].Attributes.Add("onmouseout", "showImg(8, false);");
                    e.Row.Cells[7].Attributes.Add("onmouseover", "showImg(7, true);");
                    e.Row.Cells[7].Attributes.Add("onmouseout", "showImg(7, false);");
                    break;
                case DataControlRowType.DataRow:
                    Label lblBtnEstablecer = (Label) e.Row.FindControl("lblBtnEstablecer");
                    lblBtnEstablecer.Text = " " + "<a ID=\"btnPage\" OnClick=\"javascript:establecerAuditar('" +
                                            gvAuditorias.DataKeys[e.Row.RowIndex].Values[0].ToString() + "', '" +
                                            ((Label)e.Row.FindControl("lblNombreUsuario")).Text +
                                            "','" + lblBtnEstablecer.ClientID + "');\"><img alt=\"sendMail\" src=\"../../Images/icons/bi/agregarenc.png\" style=\"width: 25px; height: 25px; cursor: pointer;\" /></a>";
                    break;

            }
        }

        protected void btnGetAtencEstab_OnClick(object sender, EventArgs e)
        {
            llenarGrilla(Int32.Parse("0"/*hfOrden.Value*/));
        }
    }
}
