using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_EventosAdversosAtencion
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public EventosAdversosAtencion GetEventosAdversosAtencion(Int32 id = 0, String EventosAdversosAtencion = "")
        {
            StringBuilder sbEventosAdversosAtencion = new StringBuilder();
            IDataReader reader;
            EventosAdversosAtencion lista = new EventosAdversosAtencion();
            EventosAdversosAtencionEntidad oEventosAdversosAtencion = new EventosAdversosAtencionEntidad();

            sbEventosAdversosAtencion.Append("SELECT");
            sbEventosAdversosAtencion.Append(" idEventosAdversosAtencion");
            sbEventosAdversosAtencion.Append(", EventosAdversosAtencion");
            sbEventosAdversosAtencion.Append(" FROM EventosAdversosAtencion");

            if (id != 0)
            {
                sbEventosAdversosAtencion.Append(" WHERE idEventosAdversosAtencion='" + id + "'");
            }
            else
            {
                if (EventosAdversosAtencion != "")
                {
                    sbEventosAdversosAtencion.Append(" WHERE EventosAdversosAtencion='" + EventosAdversosAtencion + "'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbEventosAdversosAtencion.ToString());

                while (reader.Read())
                {
                    oEventosAdversosAtencion = new EventosAdversosAtencionEntidad();
                    oEventosAdversosAtencion.idEventosAdversosAtencion = Int32.Parse(reader["idEventosAdversosAtencion"].ToString());
                    oEventosAdversosAtencion.eventosAdversosAtencion = reader["EventosAdversosAtencion"].ToString();
                    lista.Add(oEventosAdversosAtencion);

                }
                reader.Close();

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oDataAccess.close();
            }
        }

        // adiciona una nueva accion
        public Int32 AddEventosAdversosAtencion(EventosAdversosAtencionEntidad oEventosAdversosAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbEventosAdversosAtencion = new StringBuilder();
            {
                sbEventosAdversosAtencion.Append("INSERT INTO EventosAdversosAtencion(");
                sbEventosAdversosAtencion.Append(" idEventosAdversosAtencion");
                sbEventosAdversosAtencion.Append(", EventosAdversosAtencion");
                sbEventosAdversosAtencion.Append(")");
                sbEventosAdversosAtencion.Append(" VALUES(");
                sbEventosAdversosAtencion.Append("'" + oEventosAdversosAtencion.idEventosAdversosAtencion + "'");
                sbEventosAdversosAtencion.Append(", '" + oEventosAdversosAtencion.eventosAdversosAtencion + "'");
                sbEventosAdversosAtencion.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbEventosAdversosAtencion.ToString());

                    return retorno;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    oDataAccess.close();
                }
            }

        }

        // Actualiza un registro de la tabla accion

        public Int32 UpdateEventosAdversosAtencion(EventosAdversosAtencionEntidad oEventosAdversosAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbEventosAdversosAtencion = new StringBuilder();
            {
                sbEventosAdversosAtencion.Append("UPDATE accion SET");
                sbEventosAdversosAtencion.Append(" idEventosAdversosAtencion='" + oEventosAdversosAtencion.idEventosAdversosAtencion + "'");
                sbEventosAdversosAtencion.Append(" ,EventosAdversosAtencion='" + oEventosAdversosAtencion.eventosAdversosAtencion + "'");
                sbEventosAdversosAtencion.Append(" WHERE EventosAdversosAtencion='" + oEventosAdversosAtencion.idEventosAdversosAtencion + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbEventosAdversosAtencion.ToString());
                    return retorno;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    oDataAccess.close();
                }
            }
        }
    }
}
