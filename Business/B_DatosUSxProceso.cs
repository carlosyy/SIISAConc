using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_DatosUSxProceso
    {
        DM_DatosUSXProceso oDMDatosUSxProceso = new DM_DatosUSXProceso();

        public DatosUSxProceso GetDatosUSXProceso(String radicado,Int32 idDatosUS)
        {
            return oDMDatosUSxProceso.GetDatosUSXProceso(radicado: radicado, idDatosUS: idDatosUS);
        }

        public Int32 AddDatosUSXProceso(DatosUSxProcesoEntidad oDatosUSxProceso)
        {
            return oDMDatosUSxProceso.AddDatosUSXProceso(oDatosUSxProceso);
        }

        public Int32 UpdateDatosUSXProceso(DatosUSxProcesoEntidad oDatosUSxProceso)
        {
            return oDMDatosUSxProceso.UpdateDatosUSXProceso(oDatosUSxProceso);
        }

        public Int32 DeleteDatosUSXProceso(String radicado, Int32 idDatosUS,Int32 proceso)
        {
            return oDMDatosUSxProceso.DeleteDatosUSXProceso(radicado: radicado, idDatosUS: idDatosUS, proceso: proceso);
        }
        

    }
}
