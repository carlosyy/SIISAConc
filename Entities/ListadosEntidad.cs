using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ListadosEntidad
    {
        public Int32 idTipoDoc { get; set; }
        public String docIden { get; set; }
        public String mesListado { get; set; }
        public Int32 tipoAfil { get; set; }
        public Int32 zona { get; set; }
        public Int32 estado { get; set; }
        public Int32 programa { get; set; }
        public String codDane { get; set; }
        public String cabecera { get; set; }
        public String codSitioAtenc { get; set; }
        public String sitioAtenc { get; set; }
        public Boolean activo { get; set; }
        public Int32 ente { get; set; }
    }

}
