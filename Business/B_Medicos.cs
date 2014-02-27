using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Medicos
    {
        DM_Medicos oDMMedicos = new DM_Medicos();

        public medicos getMedicos()
        {
            return oDMMedicos.getMedicos();
        }

        public medicos getMedicosFiltro(String nombreMedico)
        {
            return oDMMedicos.getMedicos(nombreMedico: nombreMedico);
        }

        public Int32 addMedico(medicosEntidad oMedicos)
        {
            return oDMMedicos.addMedico(oMedicos);
        }

        public Int32 updateMedico(medicosEntidad oMedicos)
        {
            return oDMMedicos.updateMedico(oMedicos);
        }
    }
}
