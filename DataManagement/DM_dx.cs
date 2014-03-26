using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_dx
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de Dx
        public Dx GetDx(String codDx = "", String descDx = "",Boolean unido = false)
        {
            StringBuilder sbDx = new StringBuilder();
            IDataReader reader;
            Dx lista = new Dx();
            DxEntidad oDx = new DxEntidad();

            sbDx.Append("SELECT");
            sbDx.Append(" codDx");
            sbDx.Append(", dx");
            sbDx.Append(" FROM dx");

            if (codDx != "")
            {
                sbDx.Append(" WHERE codDx='" + codDx + "'");
            }
            else
            {
                if (descDx != "")
                {
                    sbDx.Append(" WHERE dx LIKE '%" + descDx + "%'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbDx.ToString());

                while (reader.Read())
                {
                    oDx = new DxEntidad();
                    oDx.codDx = reader["codDx"].ToString();
                    oDx.dx = reader["dx"].ToString();

                    if(unido==true)
                    {
                        oDx.codYDx = reader["codDx"].ToString() + " / " + reader["dx"].ToString();
                    }

                    lista.Add(oDx);
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

        public Dx GetCodDesc(String codDesc = "", Int32 top = 0)
        {
            StringBuilder sbDx = new StringBuilder();
            IDataReader reader;
            Dx lista = new Dx();
            DxEntidad oDx = new DxEntidad();

            sbDx.Append("SELECT ");
            if (top > 0) { sbDx.Append(" TOP (" + top + ")"); }
            sbDx.Append(" codDx + N' / ' + dx AS codDesc");
            sbDx.Append(", codDx");
            sbDx.Append(" FROM dx");

            if (codDesc != "")
            {
                sbDx.Append(" WHERE codDx + N' / ' + dx LIKE '%" + codDesc + "%'");
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbDx.ToString());

                while (reader.Read())
                {
                    oDx = new DxEntidad();
                    oDx.codDx = reader["codDx"].ToString();
                    oDx.codYDx = reader["codDesc"].ToString();


                    lista.Add(oDx);
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
