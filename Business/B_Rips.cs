using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Rips : IDisposable
    {
        DM_Rips oDMRips = new DM_Rips();
        private bool _disposing = false;

        public Rips GetRips(String NIT = "", Int64 Factura = 0)
        {
            return oDMRips.GetRips(NIT: NIT, Factura: Factura);
        }

        public Rips GetTempAF()
        {
            return oDMRips.GetTempAF();
        }

        public Afiliado getAfiliadosSinCrear()
        {
            return oDMRips.getAfiliadosSinCrear();
        }

        public String ExisteNIT(String NIT = "")
        {            
            return oDMRips.ExisteNIT(NIT: NIT);
        }

        public int AddRips(RipsEntidad oRips)
        {
            return (oDMRips.AddRips(oRips: oRips));
        }

        public Int32 crearCarpetaRips(Int32 idUser)
        {
            return (oDMRips.crearCarpetaRips(idUser: idUser));
        }

        public Int32 subirRips(String tipoArchivo, String ruta)
        {
            return oDMRips.subirRips(tipoArchivo: tipoArchivo, ruta: ruta);
        }

        public Int32 AddRipsxArchivo(String ruta)
        {
            return oDMRips.AddRipsxArchivo(ruta: ruta);
        }
        

        public Int32 deleteTemporalesRips(Int32 tipo)
        {
            return oDMRips.deleteTemporalesRips(tipo: tipo);
        }

        public Int32 updateIdRips(String nit, String factura, Int32 idRips)
        {
            return oDMRips.updateIdRips(nit: nit, factura: factura, idRips: idRips);
        }

        public Int32 UpdateIdRipsEnTempAF()
        {
            return oDMRips.UpdateIdRipsEnTempAF();
        }

        public Int32 UpdateAddAfiliadosRips()
        {
            return oDMRips.UpdateAddAfiliadosRips();
        }

        public Int32 agregarColumna(Int32 tipo)
        {
            return oDMRips.agregarColumna(tipo: tipo);
        }

        public Int32 AddRipsxServidor()
        {
            return oDMRips.AddRipsxServidor();
        }


        public Int32 DeleteTemporalesRips(Int32 tipo)
        {
            return oDMRips.DeleteTemporalesRips(tipo: tipo);
        }
        
        
        public void Dispose()
        {
            _disposing = true;
            Dispose(_disposing);
        }

        public void Dispose(bool d)
        {
            if (d)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
