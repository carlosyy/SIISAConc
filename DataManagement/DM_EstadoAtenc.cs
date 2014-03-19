using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_EstadoAtenc
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de EstadoAtenc
        public EstadoAtenc GetEstadoAtenc(Int32 idEstadoAtenc = 0, String EstadoAtenc = "")
        {
            StringBuilder sbEstadoAtenc = new StringBuilder();
            IDataReader reader;
            EstadoAtenc lista = new EstadoAtenc();
            EstadoAtencEntidad oEstadoAtenc = new EstadoAtencEntidad();

            sbEstadoAtenc.Append("SELECT");
            sbEstadoAtenc.Append(" idEstadoAtenc");
            sbEstadoAtenc.Append(", EstadoAtenc");
            sbEstadoAtenc.Append(" FROM EstadoAtenc");

            if (idEstadoAtenc != 0)
            {
                sbEstadoAtenc.Append(" WHERE idEstadoAtenc='" + idEstadoAtenc + "'");
            }
            else
            {
                if (EstadoAtenc != "")
                {
                    sbEstadoAtenc.Append(" WHERE EstadoAtenc LIKE '%" + EstadoAtenc + "%'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbEstadoAtenc.ToString());

                while (reader.Read())
                {
                    oEstadoAtenc = new EstadoAtencEntidad();
                    oEstadoAtenc.idEstadoAtenc = Int32.Parse(reader["idEstadoAtenc"].ToString());
                    oEstadoAtenc.estadoAtenc = reader["EstadoAtenc"].ToString();
                    lista.Add(oEstadoAtenc);

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

        // adiciona una nueva EstadoAtenc
        public Int32 AddEstadoAtenc(EstadoAtencEntidad oEstadoAtenc)
        {
            Int32 retorno = 0;
            StringBuilder sbEstadoAtenc = new StringBuilder();
            {
                sbEstadoAtenc.Append("INSERT INTO estadoAtenc(");
                sbEstadoAtenc.Append(" idEstadoAtenc");
                sbEstadoAtenc.Append(", EstadoAtenc");
                sbEstadoAtenc.Append(")");
                sbEstadoAtenc.Append(" VALUES(");
                sbEstadoAtenc.Append("'" + oEstadoAtenc.idEstadoAtenc + "'");
                sbEstadoAtenc.Append(", '" + oEstadoAtenc.estadoAtenc + "'");
                sbEstadoAtenc.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbEstadoAtenc.ToString());

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

        // Actualiza un registro de la tabla EstadoAtenc

        public Int32 UpdateEstadoAtenc(EstadoAtencEntidad oEstadoAtenc)
        {
            Int32 retorno = 0;
            StringBuilder sbEstadoAtenc = new StringBuilder();
            {
                sbEstadoAtenc.Append("UPDATE estadoAtenc SET");                
                sbEstadoAtenc.Append(" estadoAtenc='" + oEstadoAtenc.estadoAtenc + "'");
                sbEstadoAtenc.Append(" WHERE idEstadoAtenc='" + oEstadoAtenc.idEstadoAtenc + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbEstadoAtenc.ToString());
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
