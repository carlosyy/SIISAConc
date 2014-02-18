using System;
using System.Web.Services;
using Business;
using System.Web.Script.Services;

namespace SIISAConc
{
    /// <summary>
    /// Summary description for wbsSIISAConc
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class WbsSIISAConc : WebService
    {
        [WebMethod]
        public Int32 establecerAuditarWs(Int32 idRadicado)
        {
            B_AtencClinicasXAfiliados oBAtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();
            Int32 retorno = oBAtencClinicasXAfiliados.establecerAuditar(idRadicado: idRadicado);
            return retorno;
        }
    }
}
