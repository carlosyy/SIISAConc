using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_TiposDoc
    {
        DM_TiposDoc oDMTiposDoc = new DM_TiposDoc();

        public TiposDoc getTiposDoc()
        {
            return oDMTiposDoc.getTiposDoc();
        }

        public TiposDoc getTiposDocTipo(Int32 tipo)
        {
            return oDMTiposDoc.getTiposDoc(tipo: tipo);
        }

        public TiposDoc getTiposDocID(Int32 idtiposDoc, Int32 tipo)
        {
            return oDMTiposDoc.getTiposDoc(idtiposDoc: idtiposDoc, tipo: tipo);
        }

        public TiposDoc getTiposDocDescrip(String tipoDoc, Int32 tipo)
        {
            return oDMTiposDoc.getTiposDoc(tipoDoc: tipoDoc, tipo: tipo);
        }

        public Int32 AddTiposDoc(TiposDocEntidad oTiposDoc)
        {
            return oDMTiposDoc.AddTiposDoc(oTiposDoc);
        }

        public Int32 UpdateTiposDoc(TiposDocEntidad oTiposDoc)
        {
            return oDMTiposDoc.UpdatetiposDoc(oTiposDoc);
        }

    }
}
