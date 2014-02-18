using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Patologias
    {
        DM_Patologias oDMPatologias = new DM_Patologias();

        public patologias getPatologias()
        {
            return oDMPatologias.GetPatologias();
        }

        public patologias getPatologiasIdPatologia(Int32 idPatologia)
        {
            return oDMPatologias.GetPatologias(idPatologia: idPatologia);
        }

        public Int32 AddPatologias(patologiasEntidad oPatologias)
        {
            return oDMPatologias.AddPatologias(oPatologias);
        }

        public Int32 UpdatePatologias(patologiasEntidad oPatologias)
        {
            return oDMPatologias.UpdatePatologias(oPatologias);
        }

    }
}
