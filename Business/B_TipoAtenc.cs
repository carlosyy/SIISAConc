using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_TipoAtenc
    {
        DM_TipoAtenc oDMTipoAtenc = new DM_TipoAtenc();

        public tipoAtenc getTipoAtenc()
        {
            return oDMTipoAtenc.getTipoAtenc();
        }

        public tipoAtenc getTipoAtencId(Int32 idTipoAtenc)
        {
            return oDMTipoAtenc.getTipoAtenc(idTipoAtenc: idTipoAtenc);
        }

        public tipoAtenc getTipoAtencAbrevTipoAtenc(String abrevTipoAtenc)
        {
            return oDMTipoAtenc.getTipoAtenc(abrevTipoAtenc: abrevTipoAtenc);
        }

        public Int32 addTipoAtenc(tipoAtencEntidad oTipoAtenc)
        {
            return oDMTipoAtenc.AddTipoAtenc(oTipoAtenc);
        }

        public Int32 updateTipoAtenc(tipoAtencEntidad oTipoAtenc)
        {
            return oDMTipoAtenc.UpdateTipoAtenc(oTipoAtenc);
        }

    }
}
