using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_TipoAtenc
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de TipoAtenc
        public tipoAtenc getTipoAtenc(Int32 idTipoAtenc = 0, String abrevTipoAtenc = "")
        {
            StringBuilder sbTipoAtenc = new StringBuilder();
            IDataReader reader;
            tipoAtenc lista = new tipoAtenc();
            tipoAtencEntidad oTipoAtenc = new tipoAtencEntidad();

            sbTipoAtenc.Append("SELECT");
            sbTipoAtenc.Append(" idTipoAtenc");
            sbTipoAtenc.Append(", abrevTipoAtenc");
            sbTipoAtenc.Append(", tipoAtenc");
            sbTipoAtenc.Append(" FROM TipoAtenc");


            if (idTipoAtenc != 0)
            {
                sbTipoAtenc.Append(" WHERE idTipoAtenc '" + idTipoAtenc + "'");
            }
            else
            {
                if (abrevTipoAtenc != "")
                {
                    sbTipoAtenc.Append(" WHERE abrevTipoAtenc '" + abrevTipoAtenc + "'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbTipoAtenc.ToString());

                while (reader.Read())
                {
                    oTipoAtenc = new tipoAtencEntidad();
                    oTipoAtenc.idTipoAtenc = Int32.Parse(reader["idTipoAtenc"].ToString());
                    oTipoAtenc.abrevTipoAtenc = reader["abrevTipoAtenc"].ToString();
                    oTipoAtenc.tipoAtenc = reader["tipoAtenc"].ToString();
                    lista.Add(oTipoAtenc);

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

        // adiciona una nueva TipoAtenc
        public Int32 AddTipoAtenc(tipoAtencEntidad oTipoAtenc)
        {
            Int32 retorno = 0;
            StringBuilder sbTipoAtenc = new StringBuilder();
            {
                sbTipoAtenc.Append("INSERT INTO tipoAtenc(");                
                sbTipoAtenc.Append(" abrevTipoAtenc");
                sbTipoAtenc.Append(", tipoAtenc");
                sbTipoAtenc.Append(")");
                sbTipoAtenc.Append(" VALUES(");                
                sbTipoAtenc.Append(" '" + oTipoAtenc.abrevTipoAtenc + "'");
                sbTipoAtenc.Append(", '" + oTipoAtenc.tipoAtenc + "'");
                sbTipoAtenc.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbTipoAtenc.ToString());

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

        // Actualiza un registro de la tabla TipoAtenc

        public Int32 UpdateTipoAtenc(tipoAtencEntidad oTipoAtenc)
        {
            Int32 retorno = 0;
            StringBuilder sbTipoAtenc = new StringBuilder();
            {
                sbTipoAtenc.Append("UPDATE TipoAtenc SET");                
                sbTipoAtenc.Append(" ,abrevTipoAtenc='" + oTipoAtenc.abrevTipoAtenc + "'");
                sbTipoAtenc.Append(" ,tipoAtenc='" + oTipoAtenc.tipoAtenc + "'");
                sbTipoAtenc.Append(" WHERE idTipoAtenc='" + oTipoAtenc.idTipoAtenc + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbTipoAtenc.ToString());
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
