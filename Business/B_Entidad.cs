using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DataManagement;
using System.Collections.ObjectModel;
using System.Data;

namespace Business
{
    public class B_Entidad
    {
        DM_entidad oDMEntidad = new DM_entidad();

        public Entidad GetEntidad(String nombreEntidad = "", Int32 limitInf = 0, Int32 limitSup = 0)
        {
            return oDMEntidad.Getentidad(nombreEntidad: nombreEntidad, limitInf: limitInf, limitSup: limitSup);
        }

        public Entidad GetEntidadYUbicacion(String nit)
        {            
            return oDMEntidad.GetEntidadYUbicacion(nit: nit);
        }

        public Entidad getNits()
        {            
            return oDMEntidad.getNits();
        }

        public Int32 getCantEntidades(String nombreEntidad)
        {
            return oDMEntidad.getCantEntidades(nombreEntidad: nombreEntidad);
        }

        public String GetNombrexNit(String nitEntidad)
        {
            return oDMEntidad.GetNombrexNit(nitEntidad: nitEntidad);
        }
        
        public Entidad getEntidadesxNit(String nit, Int32 limitInf = 1, Int32 limitSup = 1)
        {            
            return oDMEntidad.Getentidad(nit: nit, limitInf: limitInf, limitSup: limitSup);
        }

        public Entidad getEntidadesNombre(String nombreEntidad)
        {            
            return oDMEntidad.Getentidad(nombreEntidad: nombreEntidad);
        }
        public Entidad GetNitNombre(String nitNombre)
        {            
            return oDMEntidad.GetNitNombre(nitNombre: nitNombre);
        }

        public Entidad GetNitNombreOpcRecobro(String nitNombre, Boolean entidadCapitada)
        {
            return oDMEntidad.GetNitNombre(nitNombre: nitNombre, entidadCapitada: entidadCapitada);
        }

        public Entidad getDeptos()
        {            
            return oDMEntidad.getDeptos();
        }

        public Entidad getMpios()
        {            
            return oDMEntidad.getMpios();
        }

        public Entidad getMpiosDeptos(String codDepto)
        {            
            return oDMEntidad.getMpios(codDepto: codDepto);
        }

        public Entidad getTipoDoc()
        {            
            return oDMEntidad.getTipoDoc();
        }

        public Entidad getZona()
        {            
            return oDMEntidad.getZona();
        }

        public Int32 AddEntidad(EntidadEntidad oEntidad)
        {
            return oDMEntidad.Addentidad(oEntidad);
        }

        public Int32 UpdateEntidad(EntidadEntidad oEntidad)
        {
            return oDMEntidad.Updateentidad(oEntidad);
        }


				public Entidad GetDatosEmpresa(int Lote) {

					return oDMEntidad.ObtenerDatosEntidad(Lote);
					 
				
				}

    }
}
