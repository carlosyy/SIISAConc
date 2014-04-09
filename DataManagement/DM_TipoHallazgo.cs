using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_TipoHallazgo
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de TipoHallazgo
        public TipoHallazgo getTipoHallazgo(Int32 idTipoHallazgo = 0)
        {
            StringBuilder sbTipoHallazgo = new StringBuilder();
            IDataReader reader;
            TipoHallazgo lista = new TipoHallazgo();
            TipoHallazgoEntidad oTipoHallazgo = new TipoHallazgoEntidad();

            sbTipoHallazgo.Append("SELECT");
            sbTipoHallazgo.Append(" idTipoHallazgo");
            sbTipoHallazgo.Append(", tipoHallazgo");
            sbTipoHallazgo.Append(" FROM tipoHallazgo");


            if (idTipoHallazgo != 0)
            {
                sbTipoHallazgo.Append(" WHERE idTipoHallazgo '" + idTipoHallazgo + "'");
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbTipoHallazgo.ToString());

                while (reader.Read())
                {
                    oTipoHallazgo = new TipoHallazgoEntidad();
                    oTipoHallazgo.idTipoHallazgo = Int32.Parse(reader["idTipoHallazgo"].ToString());
                    oTipoHallazgo.tipoHallazgo = reader["tipoHallazgo"].ToString();
                    lista.Add(oTipoHallazgo);

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
