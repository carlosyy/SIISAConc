using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_TiposDoc
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de tiposDoc
        public TiposDoc getTiposDoc(Int32 idtiposDoc = 0, String tipoDoc = "",Int32 tipo=0)
        {
            StringBuilder sbtiposDoc = new StringBuilder();
            TiposDoc lista = new TiposDoc();
            TiposDocEntidad otiposDoc = new TiposDocEntidad();

            sbtiposDoc.Append("SELECT");
            sbtiposDoc.Append(" idTipoDoc");
            sbtiposDoc.Append(", tipoDoc");
            sbtiposDoc.Append(", tipo");
            sbtiposDoc.Append(" FROM tiposDoc");
            sbtiposDoc.Append(" WHERE tipo= '" + tipo + "'");
            
            if (idtiposDoc != 0)
            {
                sbtiposDoc.Append(" AND idtiposDoc '" + idtiposDoc + "'");
            }
            
            if (tipoDoc != "")
            {
                sbtiposDoc.Append(" AND tipoDoc '" + tipoDoc + "'");
            }            

            try
            {
                oDataAccess.open();
                IDataReader reader = oDataAccess.executeReader(CommandType.Text, sbtiposDoc.ToString());

                while (reader.Read())
                {
                    otiposDoc = new TiposDocEntidad();
                    otiposDoc.idTipoDoc = Int32.Parse(reader["idTipoDoc"].ToString());                    
                    otiposDoc.tipoDoc = reader["tipoDoc"].ToString();
                    otiposDoc.tipo = Int32.Parse(reader["tipo"].ToString());
                    lista.Add(otiposDoc);

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

        // adiciona una nueva tiposDoc
        public Int32 AddTiposDoc(TiposDocEntidad otiposDoc)
        {
            Int32 retorno = 0;
            StringBuilder sbtiposDoc = new StringBuilder();
            {
                sbtiposDoc.Append("INSERT INTO tiposDoc(");
                sbtiposDoc.Append(" idTipoDoc");
                sbtiposDoc.Append(", tipoDoc");
                sbtiposDoc.Append(", tipo");
                sbtiposDoc.Append(")");
                sbtiposDoc.Append(" VALUES(");
                sbtiposDoc.Append("'" + otiposDoc.idTipoDoc + "'");
                sbtiposDoc.Append(", '" + otiposDoc.tipoDoc + "'");
                sbtiposDoc.Append(", '" + otiposDoc.tipo + "'");
                sbtiposDoc.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbtiposDoc.ToString());

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

        // Actualiza un registro de la tabla tiposDoc

        public Int32 UpdatetiposDoc(TiposDocEntidad otiposDoc)
        {
            Int32 retorno = 0;
            StringBuilder sbtiposDoc = new StringBuilder();
            {
                sbtiposDoc.Append("UPDATE tiposDoc SET");
                sbtiposDoc.Append(" idTipoDoc='" + otiposDoc.idTipoDoc + "'");
                sbtiposDoc.Append(" ,tipoDoc='" + otiposDoc.tipoDoc + "'");
                sbtiposDoc.Append(" ,tipo='" + otiposDoc.tipo + "'");
                sbtiposDoc.Append(" WHERE idTipoDoc='" + otiposDoc.idTipoDoc + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbtiposDoc.ToString());
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
