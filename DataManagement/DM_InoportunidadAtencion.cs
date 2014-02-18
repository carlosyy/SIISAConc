using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_InoportunidadAtencion
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public inoportunidadAtencion GetInoportunidadAtencion(Int32 id = 0, String InoportunidadAtencion = "")
        {
            StringBuilder sbInoportunidadAtencion = new StringBuilder();
            IDataReader reader;
            inoportunidadAtencion lista = new inoportunidadAtencion();
            inoportunidadAtencionEntidad oInoportunidadAtencion = new inoportunidadAtencionEntidad();

            sbInoportunidadAtencion.Append("SELECT");
            sbInoportunidadAtencion.Append(" idInoportunidadAtencion");
            sbInoportunidadAtencion.Append(", InoportunidadAtencion");
            sbInoportunidadAtencion.Append(" FROM InoportunidadAtencion");

            if (id != 0)
            {
                sbInoportunidadAtencion.Append(" WHERE idInoportunidadAtencion='" + id + "'");
            }
            else
            {
                if (InoportunidadAtencion != "")
                {
                    sbInoportunidadAtencion.Append(" WHERE InoportunidadAtencion='" + InoportunidadAtencion + "'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbInoportunidadAtencion.ToString());

                while (reader.Read())
                {
                    oInoportunidadAtencion = new inoportunidadAtencionEntidad();
                    oInoportunidadAtencion.idInoportunidadAtencion = Int32.Parse(reader["idInoportunidadAtencion"].ToString());
                    oInoportunidadAtencion.inoportunidadAtencion = reader["inoportunidadAtencion"].ToString();
                    lista.Add(oInoportunidadAtencion);

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
        public Int32 AddInoportunidadAtencion(inoportunidadAtencionEntidad oInoportunidadAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbInoportunidadAtencion = new StringBuilder();
            {
                sbInoportunidadAtencion.Append("INSERT INTO InoportunidadAtencion(");
                sbInoportunidadAtencion.Append(" idInoportunidadAtencion");
                sbInoportunidadAtencion.Append(", InoportunidadAtencion");
                sbInoportunidadAtencion.Append(")");
                sbInoportunidadAtencion.Append(" VALUES(");
                sbInoportunidadAtencion.Append("'" + oInoportunidadAtencion.idInoportunidadAtencion + "'");
                sbInoportunidadAtencion.Append(", '" + oInoportunidadAtencion.inoportunidadAtencion + "'");
                sbInoportunidadAtencion.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbInoportunidadAtencion.ToString());

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

        public Int32 UpdateInoportunidadAtencion(inoportunidadAtencionEntidad oInoportunidadAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbInoportunidadAtencion = new StringBuilder();
            {
                sbInoportunidadAtencion.Append("UPDATE accion SET");
                sbInoportunidadAtencion.Append(" idInoportunidadAtencion='" + oInoportunidadAtencion.idInoportunidadAtencion + "'");
                sbInoportunidadAtencion.Append(" ,InoportunidadAtencion='" + oInoportunidadAtencion.inoportunidadAtencion + "'");
                sbInoportunidadAtencion.Append(" WHERE InoportunidadAtencion='" + oInoportunidadAtencion.idInoportunidadAtencion + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbInoportunidadAtencion.ToString());
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
