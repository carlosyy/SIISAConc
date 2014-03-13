using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Patologias
    {
        DM_Patologias oDMPatologias = new DM_Patologias();

        public Patologias getPatologias()
        {
            return oDMPatologias.GetPatologias();
        }

        public Patologias getPatologiasIdPatologia(Int32 idPatologia)
        {
            return oDMPatologias.GetPatologias(idPatologia: idPatologia);
        }

        public Int32 AddPatologias(PatologiasEntidad oPatologias)
        {
            return oDMPatologias.AddPatologias(oPatologias);
        }

        public Int32 UpdatePatologias(PatologiasEntidad oPatologias)
        {
            return oDMPatologias.UpdatePatologias(oPatologias);
        }

    }
}
