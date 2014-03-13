using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Especialidad
    {
        DM_Especialidad oDMEspecialidad = new DM_Especialidad();

        public Especialidad getEspecialidad()
        {
            return oDMEspecialidad.GetEspecialidad();
        }

        public Especialidad getEspecialidadID(Int32 idEspecialidad)
        {
            return oDMEspecialidad.GetEspecialidad(idEspecialidad: idEspecialidad);
        }

        public Especialidad getEspecialidad3ro(String nit)
        {
            return oDMEspecialidad.getEspecialidad3ro(nit: nit);
        }

        public Especialidad getEspecialidadEspecialidad(String especialidad)
        {
            return oDMEspecialidad.GetEspecialidad(especialidad: especialidad);
        }

        public Int32 AddEspecialidad(EspecialidadEntidad oEspecialidad)
        {
            return oDMEspecialidad.AddEspecialidad(oEspecialidad);
        }

        public Int32 UpdateEspecialidad(EspecialidadEntidad oEspecialidad)
        {
            return oDMEspecialidad.UpdateEspecialidad(oEspecialidad);
        }


        public object GetMaxEspecialidad()
        {
            throw new NotImplementedException();
        }
    }
}
