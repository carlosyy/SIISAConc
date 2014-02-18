using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Especialidad
    {
        DM_Especialidad oDMEspecialidad = new DM_Especialidad();

        public especialidad getEspecialidad()
        {
            return oDMEspecialidad.GetEspecialidad();
        }

        public especialidad getEspecialidadID(Int32 idEspecialidad)
        {
            return oDMEspecialidad.GetEspecialidad(idEspecialidad: idEspecialidad);
        }

        public especialidad getEspecialidad3ro(String nit)
        {
            return oDMEspecialidad.getEspecialidad3ro(nit: nit);
        }

        public especialidad getEspecialidadEspecialidad(String especialidad)
        {
            return oDMEspecialidad.GetEspecialidad(especialidad: especialidad);
        }

        public Int32 AddEspecialidad(especialidadEntidad oEspecialidad)
        {
            return oDMEspecialidad.AddEspecialidad(oEspecialidad);
        }

        public Int32 UpdateEspecialidad(especialidadEntidad oEspecialidad)
        {
            return oDMEspecialidad.UpdateEspecialidad(oEspecialidad);
        }


        public object GetMaxEspecialidad()
        {
            throw new NotImplementedException();
        }
    }
}
