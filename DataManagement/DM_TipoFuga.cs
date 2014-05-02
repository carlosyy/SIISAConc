using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_TipoFuga
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de TipoFuga
        public TipoFuga getTipoFuga(Int32 idTipoFuga = 0)
        {
            StringBuilder sbTipoFuga = new StringBuilder();
            IDataReader reader;
            TipoFuga lista = new TipoFuga();
            TipoFugaEntidad oTipoFuga = new TipoFugaEntidad();

            sbTipoFuga.Append("SELECT");
            sbTipoFuga.Append(" idTipoFuga");
            sbTipoFuga.Append(", TipoFuga");
            sbTipoFuga.Append(" FROM tipoFuga");


            if (idTipoFuga != 0)
            {
                sbTipoFuga.Append(" WHERE idTipoFuga '" + idTipoFuga + "'");
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbTipoFuga.ToString());

                while (reader.Read())
                {
                    oTipoFuga = new TipoFugaEntidad();
                    oTipoFuga.idTipoFuga = Int32.Parse(reader["idTipoFuga"].ToString());
                    oTipoFuga.tipoFuga = reader["tipoFuga"].ToString();
                    lista.Add(oTipoFuga);

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
    }
}
