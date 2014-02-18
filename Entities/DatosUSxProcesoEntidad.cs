using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Entities
{

    public class DatosUSxProcesoEntidad
    {
        public String radicado { get; set; }
				public String noFactura { get; set; }
        public Int32 idDatosUS { get; set; } 
        public String codGlosaEfec  { get; set; }  
        public String codGlosaResp  { get; set; }
        public Decimal vrRecobro { get; set; } 
        public String nitRecobro  { get; set; }
        public Int32 tipoRecobro { get; set; }
        public String observAnalista  { get; set; }
        public Decimal vrAceptaIPS { get; set; }   
        public Boolean eliminar  { get; set; }
        public Int32 idTipoDigit { get; set; }
        public Int32 idUser { get; set; }
    }
}

