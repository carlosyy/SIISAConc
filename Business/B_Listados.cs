using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Listados
    {
        DM_Listados oDMLIstados = new DM_Listados();

        public Listados getListados()
        {
            return oDMLIstados.GetListados();
        }

        public Listados getListadosXDocIden(String docIden, Int32 top)
        {
            return oDMLIstados.GetListados(docIden: docIden, top: top);
        }

        public Listados GetDatosListados(String docIden,String mesListado)
        {
            return oDMLIstados.GetDatosListados(docIden: docIden, mesListado: mesListado);
        }

        public Int32 AddListados(ListadosEntidad oListados)
        {
            return oDMLIstados.AddListados(oListados: oListados);
        }

        public Int32 AddListadoAtencionClinicaArchivo(String ruta, String nit)
        {
            return oDMLIstados.AddListadoAtencionClinicaArchivo(ruta: ruta, nit: nit);
        }
				public Listados addListadosArchivo(String ruta, String mesListado, Boolean activos, Int32 ente)
				{
					return oDMLIstados.addListadosArchivo(ruta: ruta, mesListado: mesListado, activos: activos, ente: ente);
				}
    }
}
