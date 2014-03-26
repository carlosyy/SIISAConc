using System;
using System.Data;
using System.Data.Common;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_DxAtencion
    {        

        SQLConn oDataAccess = new SQLConn();        
        public DxAtencion getDxAtencion(String radicado = "", String codDx = "")
        {
            StringBuilder sbDxAtencion = new StringBuilder();
            IDataReader reader;
            DxAtencion eDxAtencion = new DxAtencion();
            DxAtencionEntidad ODxEntidad = null;

            sbDxAtencion.Append("SELECT");
            sbDxAtencion.Append(" da.idDx");
            sbDxAtencion.Append(", da.codDx");
            sbDxAtencion.Append(", dx.dx");
            sbDxAtencion.Append(", da.dxPpal");
            sbDxAtencion.Append(" FROM dxAtencion AS da");
            sbDxAtencion.Append(" INNER JOIN dx ON dx.codDx = da.codDx");            
            sbDxAtencion.Append(" WHERE da.radicado='" + radicado + "'");
            sbDxAtencion.Append(" AND da.eliminar=0");

            if (codDx != "")
            {
                sbDxAtencion.Append(" AND da.codDx ='" + codDx + "'");
            }


            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbDxAtencion.ToString());

                while (reader.Read())
                {
                    ODxEntidad = new DxAtencionEntidad();
                    ODxEntidad.idDx = Int32.Parse(reader["idDx"].ToString());
                    ODxEntidad.codDx = reader["codDx"].ToString();
                    ODxEntidad.descripDx = ((reader["dx"].ToString().Length > 60) ? reader["dx"].ToString().Substring(0, 60) : reader["dx"].ToString());
                    ODxEntidad.dxPpal = Boolean.Parse(reader["dxPpal"].ToString());
                    eDxAtencion.Add(ODxEntidad);
                }
                reader.Close();

                return eDxAtencion;
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

        // adiciona una nuevo dx de Atención
        public Int32 addDxAtencion(DxAtencionEntidad oDxAtencion)
        {
            Int32 retorno = 0;
            String sQuery = String.Format("EXEC SPI_DxAtencion @codDx='{0}', @radicado='{1}', @idUser={2}, @dxPpal={3}", oDxAtencion.codDx, oDxAtencion.radicado, oDxAtencion.idUser, oDxAtencion.dxPpal);

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);
                
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }

        public Int32 setDxPpal(DxAtencionEntidad oDxAtencion)
        {
            Int32 retorno = 0;
            String sQuery = String.Format("EXEC SPU_DxPpalAtencion @radicado='{0}', @idDx={1}", oDxAtencion.radicado, oDxAtencion.idDx);

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);

            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }
    }
}
