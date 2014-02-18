using System;
using System.Data;
using System.Text;
using DataAccess;
using  Entities;

namespace DataManagement
{
   public class DM_Meses
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public Meses getMeses()
        {
            StringBuilder sbMeses = new StringBuilder();
            IDataReader reader;
            Meses lista = new Meses();
            //  AccionL lista = new AccionL();
            MesesEntidad oMeses = new MesesEntidad();
            sbMeses.Append("SELECT TOP(10)");
            sbMeses.Append(" envioMail");
            sbMeses.Append(", idMes");
            sbMeses.Append(", listado");
            sbMeses.Append(", nMes");
            sbMeses.Append(", mesNum");
            sbMeses.Append(", meses");
            sbMeses.Append(" FROM meses");
            sbMeses.Append(" WHERE activoTrabajo = 1");
            sbMeses.Append(" ORDER BY idMes DESC");
            
            

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbMeses.ToString());

                while (reader.Read())
                {
                    oMeses = new MesesEntidad();
                    oMeses.envioMail = Boolean.Parse(reader["envioMail"].ToString());
                    oMeses.idMes =Int32.Parse(reader["idMes"].ToString());
                    oMeses.listado = Boolean.Parse(reader["listado"].ToString());
                    DateTime dt = DateTime.Parse(reader["meses"].ToString());
                    oMeses.meses = dt.ToShortDateString();
                    oMeses.mesNum = Int32.Parse(reader["mesNum"].ToString());
                    oMeses.nMes = reader["nMes"].ToString();
                    lista.Add(oMeses);

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

        // adiciona una nueva acion
        public Int32 AddMeses(MesesEntidad oMeses)
        {
            Int32 retorno = 0;
            StringBuilder sbMeses = new StringBuilder();
            {
                sbMeses.Append("INSERT INTO meses(");
                sbMeses.Append(" envioMail");
                sbMeses.Append(", idMes");
                sbMeses.Append(", listado");
                sbMeses.Append(", meses");
                sbMeses.Append(", mesNum");
                sbMeses.Append(")");
                sbMeses.Append(" VALUES(");
                sbMeses.Append("'" + oMeses.envioMail + "'");
                sbMeses.Append(", '" + oMeses.idMes + "'");
                sbMeses.Append(", '" + oMeses.listado + "'");
                sbMeses.Append(", '" + oMeses.meses + "'");
                sbMeses.Append(", '" + oMeses.mesNum + "'");
                sbMeses.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbMeses.ToString());

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

        public Int32 UpdateMeses(MesesEntidad oMeses)
        {
            Int32 retorno = 0;
            StringBuilder sbMeses = new StringBuilder();
            {
                sbMeses.Append("UPDATE meses SET");
                sbMeses.Append(" envioMail='" + oMeses.envioMail + "'");
                sbMeses.Append(", listados='" + oMeses.listado + "'");
                sbMeses.Append(", meses='" + oMeses.meses + "'");
                sbMeses.Append(", mesNum='" + oMeses.mesNum + "'");
                sbMeses.Append(" WHERE Idmes='" + oMeses.idMes + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbMeses.ToString());

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
