using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_NoCalidadAtencion
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public noCalidadAtencion GetNoCalidadAtencion(Int32 id = 0, String NoCalidadAtencion = "")
        {
            StringBuilder sbNoCalidadAtencion = new StringBuilder();
            IDataReader reader;
            noCalidadAtencion lista = new noCalidadAtencion();
            noCalidadAtencionEntidad oNoCalidadAtencion = new noCalidadAtencionEntidad();

            sbNoCalidadAtencion.Append("SELECT");
            sbNoCalidadAtencion.Append(" idNoCalidadAtencion");
            sbNoCalidadAtencion.Append(", NoCalidadAtencion");
            sbNoCalidadAtencion.Append(" FROM NoCalidadAtencion");

            if (id != 0)
            {
                sbNoCalidadAtencion.Append(" WHERE idNoCalidadAtencion='" + id + "'");
            }
            else
            {
                if (NoCalidadAtencion != "")
                {
                    sbNoCalidadAtencion.Append(" WHERE NoCalidadAtencion='" + NoCalidadAtencion + "'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbNoCalidadAtencion.ToString());

                while (reader.Read())
                {
                    oNoCalidadAtencion = new noCalidadAtencionEntidad();
                    oNoCalidadAtencion.idNoCalidadAtencion = Int32.Parse(reader["idNoCalidadAtencion"].ToString());
                    oNoCalidadAtencion.noCalidadAtencion = reader["noCalidadAtencion"].ToString();
                    lista.Add(oNoCalidadAtencion);

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
        public Int32 AddNoCalidadAtencion(noCalidadAtencionEntidad oNoCalidadAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbNoCalidadAtencion = new StringBuilder();
            {
                sbNoCalidadAtencion.Append("INSERT INTO NoCalidadAtencion(");
                sbNoCalidadAtencion.Append(" idNoCalidadAtencion");
                sbNoCalidadAtencion.Append(", NoCalidadAtencion");
                sbNoCalidadAtencion.Append(")");
                sbNoCalidadAtencion.Append(" VALUES(");
                sbNoCalidadAtencion.Append("'" + oNoCalidadAtencion.idNoCalidadAtencion + "'");
                sbNoCalidadAtencion.Append(", '" + oNoCalidadAtencion.noCalidadAtencion + "'");
                sbNoCalidadAtencion.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbNoCalidadAtencion.ToString());

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

        public Int32 UpdateNoCalidadAtencion(noCalidadAtencionEntidad oNoCalidadAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbNoCalidadAtencion = new StringBuilder();
            {
                sbNoCalidadAtencion.Append("UPDATE accion SET");
                sbNoCalidadAtencion.Append(" idNoCalidadAtencion='" + oNoCalidadAtencion.idNoCalidadAtencion + "'");
                sbNoCalidadAtencion.Append(" ,NoCalidadAtencion='" + oNoCalidadAtencion.noCalidadAtencion + "'");
                sbNoCalidadAtencion.Append(" WHERE NoCalidadAtencion='" + oNoCalidadAtencion.idNoCalidadAtencion + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbNoCalidadAtencion.ToString());
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
