using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_TipoAtenc
    {
        DM_TipoAtenc oDMTipoAtenc = new DM_TipoAtenc();

        public TipoAtenc getTipoAtenc()
        {
            return oDMTipoAtenc.getTipoAtenc();
        }

        public TipoAtenc getTipoAtencId(Int32 idTipoAtenc)
        {
            return oDMTipoAtenc.getTipoAtenc(idTipoAtenc: idTipoAtenc);
        }

        public TipoAtenc getTipoAtencAbrevTipoAtenc(String abrevTipoAtenc)
        {
            return oDMTipoAtenc.getTipoAtenc(abrevTipoAtenc: abrevTipoAtenc);
        }

        public Int32 addTipoAtenc(TipoAtencEntidad oTipoAtenc)
        {
            return oDMTipoAtenc.AddTipoAtenc(oTipoAtenc);
        }

        public Int32 updateTipoAtenc(TipoAtencEntidad oTipoAtenc)
        {
            return oDMTipoAtenc.UpdateTipoAtenc(oTipoAtenc);
        }

    }
}
