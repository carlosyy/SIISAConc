using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_AreasAtencion
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public areasAtencion GetAreasAtencion(Int32 id = 0, String AreasAtencion = "")
        {
            StringBuilder sbAreasAtencion = new StringBuilder();
            IDataReader reader;
            areasAtencion lista = new areasAtencion();
            areasAtencionEntidad oAreasAtencion = new areasAtencionEntidad();

            sbAreasAtencion.Append("SELECT");
            sbAreasAtencion.Append(" idAreasAtencion");
            sbAreasAtencion.Append(", AreasAtencion");
            sbAreasAtencion.Append(" FROM AreasAtencion");

            if (id != 0)
            {
                sbAreasAtencion.Append(" WHERE idAreasAtencion='" + id + "'");
            }
            else
            {
                if (AreasAtencion != "")
                {
                    sbAreasAtencion.Append(" WHERE AreasAtencion='" + AreasAtencion + "'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbAreasAtencion.ToString());

                while (reader.Read())
                {
                    oAreasAtencion = new areasAtencionEntidad();
                    oAreasAtencion.idAreasAtencion = Int32.Parse(reader["idAreasAtencion"].ToString());
                    oAreasAtencion.areasAtencion = reader["areasAtencion"].ToString();
                    lista.Add(oAreasAtencion);

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
        public Int32 AddAreasAtencion(areasAtencionEntidad oAreasAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbAreasAtencion = new StringBuilder();
            {
                sbAreasAtencion.Append("INSERT INTO AreasAtencion(");
                sbAreasAtencion.Append(" idAreasAtencion");
                sbAreasAtencion.Append(", AreasAtencion");
                sbAreasAtencion.Append(")");
                sbAreasAtencion.Append(" VALUES(");
                sbAreasAtencion.Append("'" + oAreasAtencion.idAreasAtencion + "'");
                sbAreasAtencion.Append(", '" + oAreasAtencion.areasAtencion + "'");
                sbAreasAtencion.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbAreasAtencion.ToString());

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

        public Int32 UpdateAreasAtencion(areasAtencionEntidad oAreasAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbAreasAtencion = new StringBuilder();
            {
                sbAreasAtencion.Append("UPDATE accion SET");
                sbAreasAtencion.Append(" idAreasAtencion='" + oAreasAtencion.idAreasAtencion + "'");
                sbAreasAtencion.Append(" ,AreasAtencion='" + oAreasAtencion.areasAtencion + "'");
                sbAreasAtencion.Append(" WHERE AreasAtencion='" + oAreasAtencion.idAreasAtencion + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbAreasAtencion.ToString());
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
