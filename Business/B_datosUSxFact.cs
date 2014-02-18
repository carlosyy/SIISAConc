using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_datosUSxFact
    {
        DM_datosUSxFact oDMdatosUSxFact = new DM_datosUSxFact();

        public DatosUSxFact GetdatosUSxFactxIdDatosUs(Int32 idDatosUS)
        {            
            return oDMdatosUSxFact.GetdatosUSxFact(idDatosUS: idDatosUS);
        }

        public DatosUSxFact GetdatosUSxFactxIdDatosUsXaAuditoria(Int32 idDatosUS, Boolean auditoria)
        {            
            return oDMdatosUSxFact.GetdatosUSxFact(idDatosUS: idDatosUS, auditoria: auditoria);
        }                

        public DatosUSxFact GetdatosUSxFactxRadValores(String radicado)
        {            
            return oDMdatosUSxFact.getDatosUSxFactValores(radicado: radicado);
        }

        public DatosUSxFact getDatosUSxFactListaCtas1Vez(String radicado, Int32 OrigenN,  Int32 auditoria, String nit = "")
        {

					return oDMdatosUSxFact.getDatosUSxFactListaCtas1Vez(radicado: radicado, Origen:OrigenN, auditoria: auditoria, nit: nit);
        }

        public DatosUSxFact GetDatosUsxFactLista(String radicado, Int32 IdDatosUS, Int32 limitInf, Int32 limitSup)
        {
            return oDMdatosUSxFact.GetDatosUsxFactLista(radicado: radicado, IdDatosUS: IdDatosUS, limitInf: limitInf, limitSup: limitSup);
        }

        public DatosUSxFact getDatosUSxFactListaCtas2Vez(String radicado, Int16 OrigenN, Int32 auditoria, String nit = "")
        {            
            return oDMdatosUSxFact.getDatosUSxFactListaCtas2Vez(radicado: radicado, Origen:OrigenN, auditoria: auditoria, nit: nit);
        }

        public DatosUSxFact getDatosUSxFactxValidar(String radicado,String mesRad)
        {
            return oDMdatosUSxFact.getDatosUSxFactxValidar(radicado: radicado, mesRad: mesRad);
        }

        public DatosUSxFact getDUFxAuditar(String radicado)
        {
            return oDMdatosUSxFact.getDUFxAuditar(radicado: radicado);
        }

        public DatosUSxFact GetGlosasEncabezado(String radicado, Int32 tipo)
        {            
            return oDMdatosUSxFact.GetGlosasEncabezado(radicado: radicado, tipo: tipo);
        }

        public DatosUSxFact getDatosUSxFactxAuditar(String radicado)
        {            
            return oDMdatosUSxFact.getDatosUSxFactxAuditar(radicado: radicado);
        }

        public DatosUSxFact getDatosAfiliados(String docIden)
        {
            return oDMdatosUSxFact.getDatosAfiliados(docIden: docIden);
        }

        public DatosUSxFact GetDatosListados(String docIden, String mesListado)
        {
            return oDMdatosUSxFact.GetDatosListados(docIden: docIden, mesListado: mesListado);
        }

        public Int32 contarEncabezados(String radicado)
        {
            return oDMdatosUSxFact.contarEncabezados(radicado: radicado);
        }

        public Int32 getTipoCuentaRadicado(String radicado)
        {
            return oDMdatosUSxFact.getTipoCuentaRadicado(radicado: radicado);
        }

        public String getidRips1(Int32 idDatosUs)
        {
            return oDMdatosUSxFact.getidRips1(idDatosUs: idDatosUs);
        }

        public Int32 getDiferenciaEncVsDet(Int32 idDatosUs)
        {
            return oDMdatosUSxFact.getDiferenciaEncVsDet(idDatosUs: idDatosUs);
        }

        public Int32 AddDetalleAgrupXidDatosUS(Int32 idDatosUs)
        {
            return oDMdatosUSxFact.AddDetalleAgrupXidDatosUS(idDatosUs: idDatosUs);
        }        

        public Int32 AdddatosUSxFact(DatosUSxFactEntidad odatosUSxFact)
        {
            return oDMdatosUSxFact.AdddatosUSxFact(odatosUSxFact);
        }

        public Int32 UpdateDatosUSxFactValidacionUsuarios(DatosUSxFactEntidad odatosUSxFact)
        {            
            return oDMdatosUSxFact.UpdateDatosUSxFactValidacionUsuarios(odatosUSxFact);
        }

        public Int32 UpdateDeleteRecsGlosDetAgrup(Int32 idDatosUS, String radicado, Int32 idUser)
        {
            return oDMdatosUSxFact.UpdateDeleteRecsGlosDetAgrup(idDatosUS: idDatosUS, radicado: radicado, idUser: idUser);
        }

        public Int32 UpdatedatosUSxFactDigitacion(DatosUSxFactEntidad odatosUSxFact, Boolean auditoria)
        {            
            return oDMdatosUSxFact.UpdatedatosUSxFact(odatosUSxFact: odatosUSxFact, auditoria: auditoria);
        }

        public Int32 UpdatedatosUSxFactAuditoria(DatosUSxFactEntidad odatosUSxFact, Boolean auditoria)
        {            
            return oDMdatosUSxFact.UpdatedatosUSxFact(odatosUSxFact: odatosUSxFact, auditoria: auditoria);
        }

        public Int32 UpdateRadicadoValidacionUsuarios(String radicado)
        {
            return oDMdatosUSxFact.UpdateRadicadoValidacionUsuarios(radicado: radicado);
        }

        public Int32 updateGuia(Int32 idDatosUS, Int32 idGuia)
        {
            return oDMdatosUSxFact.updateGuia(idDatosUS: idDatosUS, idGuia: idGuia);
        }
        
    }
}
