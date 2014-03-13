using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_Objetos
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de Objetos
        public Objetos GetObjetos(Int32 idPerfil, Int32 nivel)
        {            
            IDataReader reader;
            Objetos lista = new Objetos();
            string sQuery = string.Format("EXEC SPS_Objetos @idPerfil={0}, @nivel={1}", idPerfil, nivel);

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery);

                while (reader.Read())
                {
                    lista.Add(new ObjetosEntidad()
                    {
                        idObjeto = Int32.Parse(reader["idObjeto"].ToString()),
                        menuObjeto = reader["menuObjeto"].ToString(),
                        descripObjeto = reader["descripObjeto"].ToString(),
                        url = reader["url"].ToString(),
                        nivel = Int32.Parse(reader["nivel"].ToString())
                    });
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

        // adiciona una nueva Objetos
        public Int32 AddObjetos(ObjetosEntidad oObjetos)
        {
            Int32 retorno = 0;
            StringBuilder sbObjetos = new StringBuilder();
            {
                sbObjetos.Append("INSERT INTO Objetos(");
                sbObjetos.Append(" idObjeto");
                sbObjetos.Append(", menuObjeto");
                sbObjetos.Append(", descripObjeto");
                sbObjetos.Append(")");
                sbObjetos.Append(" VALUES(");
                sbObjetos.Append("'" + oObjetos.idObjeto + "'");
                sbObjetos.Append(", '" + oObjetos.menuObjeto + "'");
                sbObjetos.Append(", '" + oObjetos.descripObjeto + "'");
                sbObjetos.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbObjetos.ToString());

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

        // Actualiza un registro de la tabla Objetos

        public Int32 UpdateObjetos(ObjetosEntidad oObjetos)
        {
            Int32 retorno = 0;
            StringBuilder sbObjetos = new StringBuilder();
            {
                sbObjetos.Append("UPDATE Objetos SET");
                sbObjetos.Append(" idObjeto='" + oObjetos.idObjeto + "'");
                sbObjetos.Append(" ,menuObjeto='" + oObjetos.menuObjeto + "'");
                sbObjetos.Append(" ,descripObjeto='" + oObjetos.descripObjeto + "'");
                sbObjetos.Append(" WHERE idObjeto='" + oObjetos.idObjeto + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbObjetos.ToString());
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
