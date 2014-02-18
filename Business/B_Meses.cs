using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  Entities;
using DataManagement;
using System.Collections.ObjectModel;
namespace Business
{
   public class B_Meses
    {
       DM_Meses oDMMeses = new DM_Meses();

       public Meses GetMeses()
       {
           return oDMMeses.getMeses();
       }

       public Int32 AddMeses(MesesEntidad oMeses)
       {
           return oDMMeses.AddMeses(oMeses);
       }

       public Int32 UpdateMeses(MesesEntidad oMeses)
       {
           return oDMMeses.UpdateMeses(oMeses);
       }

    }
}
