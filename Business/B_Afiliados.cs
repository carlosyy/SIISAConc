using System;
using Entities;
using DataManagement;

namespace Business
{
   public class B_Afiliados
    {
       DM_Afiliados oDMAfiliados = new DM_Afiliados();

       public Afiliado getAfiliados()
       {
           return oDMAfiliados.getAfiliados();
       }

       public Afiliado getAfiliadoDoc(String documento)
       {
           return oDMAfiliados.getAfiliados(doc: documento);
       }

       public Afiliado getAfiliadoSexo(String sexo)
       {
           return oDMAfiliados.getAfiliados(sexo: sexo);
       }

       public Afiliado getAfiliadoPorApellido1(String apellido)
       {
           return oDMAfiliados.getAfiliados(apellido1: apellido);
       }

       public Afiliado getAfiliadoPorApellido2(String apellido)
       {
           return oDMAfiliados.getAfiliados(apellido2: apellido);
       }

       public Afiliado getAfiliadoPorApellidos(String apellido1, String apellido2)
       {
           return oDMAfiliados.getAfiliados(apellido1: apellido1, apellido2: apellido2);
       }

       public Int32 addAfiliados(AfiliadoEntidad oAfiliados)
       {
           return oDMAfiliados.AddAfiliado(oAfiliados);
       }

       public Int32 updateAfiliados(AfiliadoEntidad oAfiliados)
       {
           return oDMAfiliados.UpdateAfiliado(oAfiliados);
       }

    }
}
