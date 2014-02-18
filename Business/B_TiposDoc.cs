using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_TiposDoc
    {
        DM_TiposDoc oDMTiposDoc = new DM_TiposDoc();

        public tiposDoc getTiposDoc()
        {
            return oDMTiposDoc.getTiposDoc();
        }

        public tiposDoc getTiposDocTipo(Int32 tipo)
        {
            return oDMTiposDoc.getTiposDoc(tipo: tipo);
        }

        public tiposDoc getTiposDocID(Int32 idtiposDoc, Int32 tipo)
        {
            return oDMTiposDoc.getTiposDoc(idtiposDoc: idtiposDoc, tipo: tipo);
        }

        public tiposDoc getTiposDocDescrip(String tipoDoc, Int32 tipo)
        {
            return oDMTiposDoc.getTiposDoc(tipoDoc: tipoDoc, tipo: tipo);
        }

        public Int32 AddTiposDoc(tiposDocEntidad oTiposDoc)
        {
            return oDMTiposDoc.AddTiposDoc(oTiposDoc);
        }

        public Int32 UpdateTiposDoc(tiposDocEntidad oTiposDoc)
        {
            return oDMTiposDoc.UpdatetiposDoc(oTiposDoc);
        }

    }
}
