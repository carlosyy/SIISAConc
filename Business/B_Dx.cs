using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Dx
    {
        DM_dx oDMDx = new DM_dx();

        public dx getDx(Boolean unido)
        {
            return oDMDx.GetDx(unido: unido);
        }

        public dx getDxCodDx(String codDx)
        {
            return oDMDx.GetDx(codDx: codDx);
        }

        public dx getDxDescDx(String descDx)
        {
            return oDMDx.GetDx(descDx: descDx);
        }

        public dx GetCodDesc(String codDesc)
        {
            return oDMDx.GetCodDesc(codDesc: codDesc);
        }        
    }
}
