using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_TipoFuga
    {
        DM_TipoFuga oDMTipoFuga = new DM_TipoFuga();

        public TipoFuga getTipoFuga()
        {
            return oDMTipoFuga.getTipoFuga();
        }

        public TipoFuga getTipoFugaId(Int32 idTipoFuga)
        {
            return oDMTipoFuga.getTipoFuga(idTipoFuga: idTipoFuga);
        }
    }
}
