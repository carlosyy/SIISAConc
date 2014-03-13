using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;
using System.Collections.Generic;

namespace DataManagement
{
    public class DM_AutoCompletar
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de AutoCompletar
        public AutoCompletar getAutoCompletar(String prefixText, Int32 proceso)
        {
            StringBuilder sbAutoCompletar = new StringBuilder();
            AutoCompletar lista = new AutoCompletar();
            String w = " WHERE";

            sbAutoCompletar.Append("SELECT TOP(10)");
            sbAutoCompletar.Append(" textoAutoCompletar");
            sbAutoCompletar.Append(", indexSeleccion");
            sbAutoCompletar.Append(" FROM textoAutoCompletar");

            if (prefixText != "")
            {
                sbAutoCompletar.Append(w + " textoAutoCompletar LIKE '%" + prefixText + "%'");
                w = " AND";
            }

            if (proceso != 0)
            {
                sbAutoCompletar.Append(w + " proceso ='" + proceso + "'");
            }

            sbAutoCompletar.Append(" ORDER BY utilizado DESC");
            try
            {
                oDataAccess.open();
                IDataReader reader = oDataAccess.executeReader(CommandType.Text, sbAutoCompletar.ToString());

                while (reader.Read())
                {
                    AutoCompletarEntidad oAutoCompletar = new AutoCompletarEntidad
                    {
                        textoAutoCompletar = reader["textoAutoCompletar"].ToString(),
                        indexSeleccion = Int32.Parse(reader["indexSeleccion"].ToString())
                    };
                    lista.Add(oAutoCompletar);
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

        // adiciona una nueva AutoCompletar
        public Int32 addAutoCompletar(AutoCompletarEntidad oAutoCompletar)
        {
            Int32 retorno = 0;
            String sQuery =
                String.Format("EXEC SPIU_AutoCompletar @proc={0}, @textoAutoCompletar='{1}', @indexSeleccion={2}",
                    oAutoCompletar.proceso, oAutoCompletar.textoAutoCompletar, oAutoCompletar.indexSeleccion);

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
            finally
            {
                oDataAccess.close();
            }


        }
    }
}
