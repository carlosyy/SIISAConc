using DataManagement;
using Entities;
using System;

namespace Business
{
    public class B_AtencClinicasXAfiliados
    {
        private readonly DM_AtencClinicasXAfiliados _oDmAtencClinicas = new DM_AtencClinicasXAfiliados();

        public AtencClinicasXAfiliado buscar(String docIden, Int32 programa, String nit, String codDx, String fecDesde,
            String fecHasta, String filtroNombre, Int32 limitInf, Int32 limitSup, Int32 orden, Int32 idEstadoAtenc)
        {
            return _oDmAtencClinicas.buscar(docIden: docIden, programa: programa, nit: nit, codDx: codDx,
                fecDesde: fecDesde, fecHasta: fecHasta, filtroNombre: filtroNombre, limitInf: limitInf,
                limitSup: limitSup, orden: orden, idEstadoAtenc: idEstadoAtenc);
        }

        public AtencClinicasXAfiliado getAuditorias(Int32 idUserEstablece, String fecAuditoria)
        {
            return _oDmAtencClinicas.getAuditorias(idUserEstablece: idUserEstablece, fecAuditoria: fecAuditoria);
        }

        public Int32 contarAtenciones(String docIden, Int32 programa, String nit, String codDx, String fecDesc,
            String fecHasta, String filtroNombre)
        {
            return _oDmAtencClinicas.contarAtenciones(docIden: docIden, programa: programa, nit: nit, codDx: codDx,
                fecDesc: fecDesc, fecHasta: fecHasta, filtroNombre: filtroNombre);
        }

        public AtencClinicasXAfiliado getDatosAuditoria(String radicado)
        {
            return _oDmAtencClinicas.getDatosAuditoria(radicado: radicado);
        }

        public String establecerAuditar(Int32 idAtencion, Int32 idUser)
        {
            return _oDmAtencClinicas.establecerAuditar(idAtencion: idAtencion, idUser: idUser);
        }

        public String addAtencClinicasXAfiliados(AtencClinicasEntidad eAten)
        {
            return _oDmAtencClinicas.addAtencClinicasXAfiliados(eAten);
        }
    }
}
