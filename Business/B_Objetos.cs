using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Objetos
    {
        DM_Objetos oDMObjetos = new DM_Objetos();        

        public Objetos getObjetosXPerfil(Int32 idPerfil, Int32 nivel)
        {
            return oDMObjetos.GetObjetos(idPerfil: idPerfil, nivel: nivel);
        }       

        public Int32 AddObjetos(ObjetosEntidad oObjetos)
        {
            return oDMObjetos.AddObjetos(oObjetos);
        }

        public Int32 UpdateObjetos(ObjetosEntidad oObjetos)
        {
            return oDMObjetos.UpdateObjetos(oObjetos);
        }

    }
}
