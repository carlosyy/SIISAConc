using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Medicos
    {
        DM_Medicos oDMMedicos = new DM_Medicos();

        public Medicos getMedicos()
        {
            return oDMMedicos.getMedicos();
        }

        public Medicos getMedicosFiltro(String nombreMedico)
        {
            return oDMMedicos.getMedicos(nombreMedico: nombreMedico);
        }

        public Int32 addMedico(MedicosEntidad oMedicos)
        {
            return oDMMedicos.addMedico(oMedicos);
        }

        public Int32 updateMedico(MedicosEntidad oMedicos)
        {
            return oDMMedicos.updateMedico(oMedicos);
        }
    }
}
