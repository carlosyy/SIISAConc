using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_Patologias
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de Patologias
        public patologias GetPatologias(Int32 idPatologia = 0)
        {
            StringBuilder sbPatologias = new StringBuilder();
            IDataReader reader;
            patologias lista = new patologias();
            patologiasEntidad oPatologias = new patologiasEntidad();

            sbPatologias.Append("SELECT");
            sbPatologias.Append(" idPatologia");
            sbPatologias.Append(", patologia");
            sbPatologias.Append(" FROM patologias");


            if (idPatologia != 0)
            {
                sbPatologias.Append(" WHERE idPatologia '" + idPatologia + "'");
            }           

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbPatologias.ToString());

                while (reader.Read())
                {
                    oPatologias = new patologiasEntidad();
                    oPatologias.idPatologia = Int32.Parse(reader["idPatologia"].ToString());
                    oPatologias.patologia = reader["patologia"].ToString();
                    lista.Add(oPatologias);

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

        // adiciona una nueva Patologias
        public Int32 AddPatologias(patologiasEntidad oPatologias)
        {
            Int32 retorno = 0;
            StringBuilder sbPatologias = new StringBuilder();
            {
                sbPatologias.Append("INSERT INTO patologias(");
                sbPatologias.Append(" idPatologia");                
                sbPatologias.Append(", patologia");                
                sbPatologias.Append(")");
                sbPatologias.Append(" VALUES(");
                sbPatologias.Append("'" + oPatologias.idPatologia + "'");                
                sbPatologias.Append(", '" + oPatologias.patologia + "'");                
                sbPatologias.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbPatologias.ToString());

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

        // Actualiza un registro de la tabla Patologias

        public Int32 UpdatePatologias(patologiasEntidad oPatologias)
        {
            Int32 retorno = 0;
            StringBuilder sbPatologias = new StringBuilder();
            {
                sbPatologias.Append("UPDATE patologias SET");
                sbPatologias.Append(" idPatologia='" + oPatologias.idPatologia + "'");                
                sbPatologias.Append(" ,patologia='" + oPatologias.patologia + "'");
                sbPatologias.Append(" WHERE idPatologia='" + oPatologias.idPatologia + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbPatologias.ToString());
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
