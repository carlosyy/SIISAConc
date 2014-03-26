using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Dx
    {
        DM_dx oDMDx = new DM_dx();

        public Dx getDx(Boolean unido)
        {
            return oDMDx.GetDx(unido: unido);
        }

        public Dx getDxCodDx(String codDx)
        {
            return oDMDx.GetDx(codDx: codDx);
        }

        public Dx getDxDescDx(String descDx)
        {
            return oDMDx.GetDx(descDx: descDx);
        }

        public Dx GetCodDesc(String codDesc)
        {
            return oDMDx.GetCodDesc(codDesc: codDesc);
        }

        public Dx getBusqDx(String codDesc, Int32 top)
        {
            return oDMDx.GetCodDesc(codDesc: codDesc, top: top);
        }
    }
}
