using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_EventosAdversosAtencion
    {
        DM_EventosAdversosAtencion oDMEventosAdversosAtencion = new DM_EventosAdversosAtencion();

        public eventosAdversosAtencion getEventosAdversosAtencion()
        {
            return oDMEventosAdversosAtencion.GetEventosAdversosAtencion();
        }

        public Int32 AddEventosAdversosAtencion(eventosAdversosAtencionEntidad oEventosAdversosAtencion)
        {
            return oDMEventosAdversosAtencion.AddEventosAdversosAtencion(oEventosAdversosAtencion);
        }

        public Int32 UpdateEventosAdversosAtencion(eventosAdversosAtencionEntidad oEventosAdversosAtencion)
        {
            return oDMEventosAdversosAtencion.UpdateEventosAdversosAtencion(oEventosAdversosAtencion);
        }
    }
}
