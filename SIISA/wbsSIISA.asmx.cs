using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Services;
using Business;
using System.Web.Script.Services;
using Entities;

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
        public String establecerAuditarWs(Int32 idAtencion, Int32 idUser)
        {
            B_AtencClinicasXAfiliados oBAtencClinicasXAfiliados = new B_AtencClinicasXAfiliados();
            String radicado = oBAtencClinicasXAfiliados.establecerAuditar(idAtencion: idAtencion, idUser: idUser);
            return radicado;
        }

        [WebMethod]
        public String encriptar(String texto)
        {
            return ManejoTextos.Encriptar(texto: texto);
        }

        [WebMethod]
        public static String desencriptar(String textoEncriptado)
        {
            return ManejoTextos.Desencriptar(textoEncriptado: textoEncriptado);
        }
    }
}
