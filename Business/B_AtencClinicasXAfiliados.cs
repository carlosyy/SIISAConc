using DataManagement;
using Entities;
using System;

namespace Business
{
    public class B_AtencClinicasXAfiliados
    {
        private readonly DM_AtencClinicasXAfiliados _oDmAtencClinicas = new DM_AtencClinicasXAfiliados();

        public atencClinicasXAfiliado Buscar(String docIden, Int32 programa, String nit, String codDx, String fecDesde,
            String fecHasta, String filtroNombre, Int32 limitInf, Int32 limitSup, Int32 orden)
        {
            return _oDmAtencClinicas.Buscar(docIden: docIden, programa: programa, nit: nit, codDx: codDx,
                fecDesde: fecDesde, fecHasta: fecHasta, filtroNombre: filtroNombre, limitInf: limitInf,
                limitSup: limitSup, orden: orden);
        }

        public Int32 contarAtenciones(String docIden, Int32 programa, String nit, String codDx, String fecDesc,
            String fecHasta, String filtroNombre)
        {
            return _oDmAtencClinicas.contarAtenciones(docIden: docIden, programa: programa, nit: nit, codDx: codDx,
                fecDesc: fecDesc, fecHasta: fecHasta, filtroNombre: filtroNombre);
        }

        public Int32 establecerAuditar(Int32 idRadicado)
        {
            return _oDmAtencClinicas.establecerAuditar(idRadicado: idRadicado);
        }

        public Int32 addAtencClinicasXAfiliados(atencClinicasEntidad eAten)
        {
            return _oDmAtencClinicas.addAtencClinicasXAfiliados(eAten);
        }
}
}
