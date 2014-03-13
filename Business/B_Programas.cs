using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Programas
    {
        DM_Programas oDMProgramas = new DM_Programas();

        public Programas getProgramas()
        {
            return oDMProgramas.GetProgramas();
        }

        public Programas getProgramasID(Int32 idPrograma)
        {
            return oDMProgramas.GetProgramas(idPrograma: idPrograma);
        }

        public Programas getProgramasPrograma(String programa)
        {
            return oDMProgramas.GetProgramas(programa: programa);
        }

        public Programas getProgramas3ro(String nit)
        {
            return oDMProgramas.getProgramas3ro(nit: nit);
        }

        public Programas getProgramaValidaVsRad(String radicado)
        {
            return oDMProgramas.getProgramaValidaVsRad(radicado: radicado);
        }

        public Programas getProgramasActivo(Boolean activo)
        {
            return oDMProgramas.GetProgramas(activo: activo);
        }

        public Int32 AddProgramas(ProgramasEntidad oProgramas)
        {
            return oDMProgramas.AddProgramas(oProgramas);
        }

        public Int32 updateProgramaValidRadVsAud(String radicado, Int32 programa, Int32 programaRad, String actualizaEn)
        {
            return oDMProgramas.updateProgramaValidRadVsAud(radicado: radicado, programa: programa, programaRad: programaRad, actualizaEn: actualizaEn);
        }
        public Int32 UpdateProgramas(ProgramasEntidad oProgramas)
        {
            return oDMProgramas.UpdateProgramas(oProgramas);
        }

    }
}
