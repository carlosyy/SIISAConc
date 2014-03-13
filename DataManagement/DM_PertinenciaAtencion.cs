using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_PertinenciaAtencion
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public PertinenciaAtencion GetPertinenciaAtencion(Int32 id = 0, String PertinenciaAtencion = "")
        {
            StringBuilder sbPertinenciaAtencion = new StringBuilder();
            IDataReader reader;
            PertinenciaAtencion lista = new PertinenciaAtencion();
            PertinenciaAtencionEntidad oPertinenciaAtencion = new PertinenciaAtencionEntidad();

            sbPertinenciaAtencion.Append("SELECT");
            sbPertinenciaAtencion.Append(" idPertinenciaAtencion");
            sbPertinenciaAtencion.Append(", PertinenciaAtencion");
            sbPertinenciaAtencion.Append(" FROM PertinenciaAtencion");

            if (id != 0)
            {
                sbPertinenciaAtencion.Append(" WHERE idPertinenciaAtencion='" + id + "'");
            }
            else
            {
                if (PertinenciaAtencion != "")
                {
                    sbPertinenciaAtencion.Append(" WHERE PertinenciaAtencion='" + PertinenciaAtencion + "'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbPertinenciaAtencion.ToString());

                while (reader.Read())
                {
                    oPertinenciaAtencion = new PertinenciaAtencionEntidad();
                    oPertinenciaAtencion.idPertinenciaAtencion = Int32.Parse(reader["idPertinenciaAtencion"].ToString());
                    oPertinenciaAtencion.pertinenciaAtencion = reader["pertinenciaAtencion"].ToString();
                    lista.Add(oPertinenciaAtencion);

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
        public Int32 AddPertinenciaAtencion(PertinenciaAtencionEntidad oPertinenciaAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbPertinenciaAtencion = new StringBuilder();
            {
                sbPertinenciaAtencion.Append("INSERT INTO PertinenciaAtencion(");
                sbPertinenciaAtencion.Append(" idPertinenciaAtencion");
                sbPertinenciaAtencion.Append(", PertinenciaAtencion");
                sbPertinenciaAtencion.Append(")");
                sbPertinenciaAtencion.Append(" VALUES(");
                sbPertinenciaAtencion.Append("'" + oPertinenciaAtencion.idPertinenciaAtencion + "'");
                sbPertinenciaAtencion.Append(", '" + oPertinenciaAtencion.pertinenciaAtencion + "'");
                sbPertinenciaAtencion.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbPertinenciaAtencion.ToString());

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

        public Int32 UpdatePertinenciaAtencion(PertinenciaAtencionEntidad oPertinenciaAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbPertinenciaAtencion = new StringBuilder();
            {
                sbPertinenciaAtencion.Append("UPDATE accion SET");
                sbPertinenciaAtencion.Append(" idPertinenciaAtencion='" + oPertinenciaAtencion.idPertinenciaAtencion + "'");
                sbPertinenciaAtencion.Append(" ,PertinenciaAtencion='" + oPertinenciaAtencion.pertinenciaAtencion + "'");
                sbPertinenciaAtencion.Append(" WHERE PertinenciaAtencion='" + oPertinenciaAtencion.idPertinenciaAtencion + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbPertinenciaAtencion.ToString());
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
