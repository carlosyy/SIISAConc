using System;

namespace Entities
{
    public class DxAtencionEntidad
    {
        public Int32 idDx { get; set; }
        public String radicado { get; set; }
        public String codDx { get; set; }
        public String descripDx { get; set; }
        public Int32 idUser { get; set; }
        public Boolean dxPpal { get; set; }
    }
}
