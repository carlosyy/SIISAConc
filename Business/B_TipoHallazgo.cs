using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_TipoHallazgo
    {
        DM_TipoHallazgo oDMTipoHallazgo = new DM_TipoHallazgo();

        public TipoHallazgo getTipoHallazgo()
        {
            return oDMTipoHallazgo.getTipoHallazgo();
        }

        public TipoHallazgo getTipoHallazgoId(Int32 idTipoHallazgo)
        {
            return oDMTipoHallazgo.getTipoHallazgo(idTipoHallazgo: idTipoHallazgo);
        }
    }
}
