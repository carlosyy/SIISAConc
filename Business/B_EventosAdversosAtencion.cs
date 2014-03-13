using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_EventosAdversosAtencion
    {
        DM_EventosAdversosAtencion oDMEventosAdversosAtencion = new DM_EventosAdversosAtencion();

        public EventosAdversosAtencion getEventosAdversosAtencion()
        {
            return oDMEventosAdversosAtencion.GetEventosAdversosAtencion();
        }

        public Int32 AddEventosAdversosAtencion(EventosAdversosAtencionEntidad oEventosAdversosAtencion)
        {
            return oDMEventosAdversosAtencion.AddEventosAdversosAtencion(oEventosAdversosAtencion);
        }

        public Int32 UpdateEventosAdversosAtencion(EventosAdversosAtencionEntidad oEventosAdversosAtencion)
        {
            return oDMEventosAdversosAtencion.UpdateEventosAdversosAtencion(oEventosAdversosAtencion);
        }
    }
}
