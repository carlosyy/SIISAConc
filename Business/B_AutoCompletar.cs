using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_AutoCompletar
    {
        DM_AutoCompletar oDMAutoCompletar = new DM_AutoCompletar();

        public AutoCompletar getAutoCompletar(String prefixText, Int32 proceso)
        {
            return oDMAutoCompletar.getAutoCompletar(prefixText: prefixText, proceso: proceso);
        }

        public Int32 addAutoCompletar(AutoCompletarEntidad oAutoCompletar)
        {
            return oDMAutoCompletar.addAutoCompletar(oAutoCompletar);
        }
    }
}
