using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Programas
    {
        DM_Programas oDMProgramas = new DM_Programas();

        public programas getProgramas()
        {
            return oDMProgramas.GetProgramas();
        }

        public programas getProgramasID(Int32 idPrograma)
        {
            return oDMProgramas.GetProgramas(idPrograma: idPrograma);
        }

        public programas getProgramasPrograma(String programa)
        {
            return oDMProgramas.GetProgramas(programa: programa);
        }

        public programas getProgramas3ro(String nit)
        {
            return oDMProgramas.getProgramas3ro(nit: nit);
        }

        public programas getProgramaValidaVsRad(String radicado)
        {
            return oDMProgramas.getProgramaValidaVsRad(radicado: radicado);
        }

        public programas getProgramasActivo(Boolean activo)
        {
            return oDMProgramas.GetProgramas(activo: activo);
        }

        public Int32 AddProgramas(programasEntidad oProgramas)
        {
            return oDMProgramas.AddProgramas(oProgramas);
        }

        public Int32 updateProgramaValidRadVsAud(String radicado, Int32 programa, Int32 programaRad, String actualizaEn)
        {
            return oDMProgramas.updateProgramaValidRadVsAud(radicado: radicado, programa: programa, programaRad: programaRad, actualizaEn: actualizaEn);
        }
        public Int32 UpdateProgramas(programasEntidad oProgramas)
        {
            return oDMProgramas.UpdateProgramas(oProgramas);
        }

    }
}
