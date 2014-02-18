using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_DatosUSXProceso
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de DatosUSXProceso
        public DatosUSxProceso GetDatosUSXProceso(String radicado = "", Int32 idDatosUS = 0)
        {
            StringBuilder sbDatosUSXProceso = new StringBuilder();
            IDataReader reader;
            DatosUSxProceso lista = new DatosUSxProceso();
            DatosUSxProcesoEntidad oDatosUSXProceso = new DatosUSxProcesoEntidad();

            sbDatosUSXProceso.Append("SELECT");
            sbDatosUSXProceso.Append(" codGlosaEfec");
            sbDatosUSXProceso.Append(", codGlosaResp");
            sbDatosUSXProceso.Append(", idDatosUS");
            sbDatosUSXProceso.Append(", idTipoDigit");
            sbDatosUSXProceso.Append(", idUser");
            sbDatosUSXProceso.Append(", nitRecobro");
            sbDatosUSXProceso.Append(", observAnalista");
            sbDatosUSXProceso.Append(", radicado");
            sbDatosUSXProceso.Append(", tipoRecobro");
            sbDatosUSXProceso.Append(", vrAceptaIPS");
            sbDatosUSXProceso.Append(", vrRecobro");
            sbDatosUSXProceso.Append(" FROM DatosUSXProceso");

            if (radicado != "")
            {
                sbDatosUSXProceso.Append(" WHERE radicado='" + radicado + "'");
            }
            else
            {
                if (idDatosUS != 0)
                {
                    sbDatosUSXProceso.Append(" WHERE idDatosUS='" + idDatosUS + "'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbDatosUSXProceso.ToString());

                while (reader.Read())
                {
                    oDatosUSXProceso = new DatosUSxProcesoEntidad();
                    oDatosUSXProceso.codGlosaEfec = reader["codGlosaEfec"].ToString();
                    oDatosUSXProceso.codGlosaResp = reader["codGlosaResp"].ToString();
                    oDatosUSXProceso.idDatosUS = Int32.Parse(reader["idDatosUS"].ToString());
                    oDatosUSXProceso.idTipoDigit = Int32.Parse(reader["idTipoDigit"].ToString());
                    oDatosUSXProceso.idUser = Int32.Parse(reader["idUser"].ToString());
                    oDatosUSXProceso.nitRecobro = reader["nitRecobro"].ToString();
                    oDatosUSXProceso.observAnalista = reader["observAnalista"].ToString();
                    oDatosUSXProceso.radicado = reader["radicado"].ToString();
                    oDatosUSXProceso.tipoRecobro = Int32.Parse(reader["tipoRecobro"].ToString());
                    oDatosUSXProceso.vrAceptaIPS = Int32.Parse(reader["vrAceptaIPS"].ToString());
                    oDatosUSXProceso.vrRecobro = Int32.Parse(reader["vrRecobro"].ToString());
                    lista.Add(oDatosUSXProceso);

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

        // adiciona una nueva DatosUSXProceso
        public Int32 AddDatosUSXProceso(DatosUSxProcesoEntidad oDatosUSXProceso)
        {
            Int32 retorno = 0;
            StringBuilder sbDatosUSXProceso = new StringBuilder();
            {

                sbDatosUSXProceso.Append("INSERT INTO DatosUSXProceso(");
                sbDatosUSXProceso.Append(" codGlosaEfec");
                sbDatosUSXProceso.Append(", codGlosaResp");
                sbDatosUSXProceso.Append(", idDatosUS");
                sbDatosUSXProceso.Append(", idTipoDigit");
                sbDatosUSXProceso.Append(", idUser");
                sbDatosUSXProceso.Append(", nitRecobro");
                sbDatosUSXProceso.Append(", observAnalista");
                sbDatosUSXProceso.Append(", radicado");
                sbDatosUSXProceso.Append(", tipoRecobro");
                sbDatosUSXProceso.Append(", vrAceptaIPS");
                sbDatosUSXProceso.Append(", vrRecobro");								
                sbDatosUSXProceso.Append(")");
                sbDatosUSXProceso.Append(" VALUES(");
                sbDatosUSXProceso.Append("'" + oDatosUSXProceso.codGlosaEfec + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.codGlosaResp + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.idDatosUS + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.idTipoDigit + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.idUser + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.nitRecobro + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.observAnalista + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.radicado + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.tipoRecobro + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.vrAceptaIPS + "'");
                sbDatosUSXProceso.Append(", '" + oDatosUSXProceso.vrRecobro + "'");								
                sbDatosUSXProceso.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbDatosUSXProceso.ToString());

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

        // Actualiza un registro de la tabla DatosUSXProceso

        public Int32 UpdateDatosUSXProceso(DatosUSxProcesoEntidad oDatosUSXProceso)
        {
            Int32 retorno = 0;
            StringBuilder sbDatosUSXProceso = new StringBuilder();
            {
                sbDatosUSXProceso.Append("UPDATE DatosUSXProceso SET");
                sbDatosUSXProceso.Append(" codGlosaEfec='" + oDatosUSXProceso.codGlosaEfec + "'");
                sbDatosUSXProceso.Append(", codGlosaResp='" + oDatosUSXProceso.codGlosaResp + "'");
                sbDatosUSXProceso.Append(", nitRecobro='" + oDatosUSXProceso.nitRecobro + "'");
                sbDatosUSXProceso.Append(", observAnalista='" + oDatosUSXProceso.observAnalista + "'");
                sbDatosUSXProceso.Append(", tipoRecobro='" + oDatosUSXProceso.tipoRecobro + "'");
                sbDatosUSXProceso.Append(", vrAceptaIPS='" + oDatosUSXProceso.vrAceptaIPS + "'");
                sbDatosUSXProceso.Append(", vrRecobro='" + oDatosUSXProceso.vrRecobro + "'");
                sbDatosUSXProceso.Append(" WHERE idDatosUS='" + oDatosUSXProceso.idDatosUS + "'");
                sbDatosUSXProceso.Append(" AND radicado='" + oDatosUSXProceso.radicado + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbDatosUSXProceso.ToString());
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

        public Int32 DeleteDatosUSXProceso(String radicado, Int32 idDatosUS, Int32 proceso)
        {
            Int32 retorno = 0;
            StringBuilder sbDatosUSXProceso = new StringBuilder();
            {
                sbDatosUSXProceso.Append("UPDATE");
                switch(proceso)
                {
                    case 1:
                        sbDatosUSXProceso.Append(" DatosUSXProceso");
                        break;
                    case 2:
                        sbDatosUSXProceso.Append(" glosasxProceso");
                        break;
                    case 3:
                        sbDatosUSXProceso.Append(" recobrosXProceso");
                        break;
                }

                sbDatosUSXProceso.Append(" SET");
                sbDatosUSXProceso.Append(" eliminar=1");
                sbDatosUSXProceso.Append(" WHERE radicado='" + radicado + "'");
                switch (proceso)
                {
                    case 1:
                        sbDatosUSXProceso.Append(" AND idDatosUS='" + idDatosUS + "'");
                        break;
                    case 2:
                        sbDatosUSXProceso.Append(" AND idGlosa='" + idDatosUS + "'");
                        break;
                    case 3:
                        sbDatosUSXProceso.Append(" AND idRecobro='" + idDatosUS + "'");
                        break;
                }
                

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbDatosUSXProceso.ToString());
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
