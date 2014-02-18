using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Objetos
    {
        DM_Objetos oDMObjetos = new DM_Objetos();        

        public objetos getObjetosXPerfil(Int32 idPerfil, Int32 nivel)
        {
            return oDMObjetos.GetObjetos(idPerfil: idPerfil, nivel: nivel);
        }       

        public Int32 AddObjetos(objetosEntidad oObjetos)
        {
            return oDMObjetos.AddObjetos(oObjetos);
        }

        public Int32 UpdateObjetos(objetosEntidad oObjetos)
        {
            return oDMObjetos.UpdateObjetos(oObjetos);
        }

    }
}
