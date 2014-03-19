using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_EstadoAtenc
    {
        DM_EstadoAtenc oDMEstadoAtenc = new DM_EstadoAtenc();

        public EstadoAtenc getEstadoAtenc()
        {
            return oDMEstadoAtenc.GetEstadoAtenc();
        }

        public EstadoAtenc getEstadoAtencID(Int32 idEstadoAtenc)
        {
            return oDMEstadoAtenc.GetEstadoAtenc(idEstadoAtenc: idEstadoAtenc);
        }

        public EstadoAtenc getEstadoAtencEstadoAtenc(String EstadoAtenc)
        {
            return oDMEstadoAtenc.GetEstadoAtenc(EstadoAtenc: EstadoAtenc);
        }

        public Int32 AddEstadoAtenc(EstadoAtencEntidad oEstadoAtenc)
        {
            return oDMEstadoAtenc.AddEstadoAtenc(oEstadoAtenc);
        }

        public Int32 UpdateEstadoAtenc(EstadoAtencEntidad oEstadoAtenc)
        {
            return oDMEstadoAtenc.UpdateEstadoAtenc(oEstadoAtenc);
        }

    }
}
