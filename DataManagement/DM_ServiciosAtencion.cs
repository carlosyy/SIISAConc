using System;
using System.Data;
using System.Data.Common;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_ServiciosAtencion
    {        

        SQLConn oDataAccess = new SQLConn();        
        public ServiciosAtencion getServiciosAtencion(String radicado = "", String codServ = "")
        {
            StringBuilder sbServiciosAtencion = new StringBuilder();
            IDataReader reader;
            ServiciosAtencion ServiFactUsu = new ServiciosAtencion();
            ServiciosAtencionEntidad OserviEntidad = new ServiciosAtencionEntidad();

            sbServiciosAtencion.Append("SELECT");
            sbServiciosAtencion.Append(" sa.idServ");
            sbServiciosAtencion.Append(", sa.codserv");
            sbServiciosAtencion.Append(", sa.codserv");
            sbServiciosAtencion.Append(", sa.noAutorizacion");
            sbServiciosAtencion.Append(", ser.descripcion as servicio");
            sbServiciosAtencion.Append(", co.nombreconcepto");
            sbServiciosAtencion.Append(" FROM serviciosAtencion AS sa");
            sbServiciosAtencion.Append(" INNER JOIN servicios AS ser ON ser.codServ = sa.codServ");
            sbServiciosAtencion.Append(" INNER JOIN conceptos as co ON co.codConcepto = ser.codConcepto");
            sbServiciosAtencion.Append(" WHERE sa.radicado='" + radicado + "'");
            sbServiciosAtencion.Append(" AND sa.eliminar=0");

            if (codServ != "")
            {
                sbServiciosAtencion.Append(" AND sa.codServ ='" + codServ + "'");
            }


            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbServiciosAtencion.ToString());

                while (reader.Read())
                {
                    OserviEntidad = new ServiciosAtencionEntidad();
                    OserviEntidad.idServ = Int32.Parse(reader["idServ"].ToString());                    
                    OserviEntidad.codServ = reader["codServ"].ToString();
                    OserviEntidad.noAutorizacion = reader["noAutorizacion"].ToString();
                    OserviEntidad.descripServ = ((reader["servicio"].ToString().Length > 60) ? reader["servicio"].ToString().Substring(0, 60) : reader["servicio"].ToString());
                    OserviEntidad.concepto = reader["nombreconcepto"].ToString();                    
                    ServiFactUsu.Add(OserviEntidad);
                }
                reader.Close();

                return ServiFactUsu;
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

        // adiciona una nueva servicio de Atención
        public Int32 AddServiciosAtencion(ServiciosAtencionEntidad oServiciosAtencion)
        {
            Int32 retorno = 0;
            String sQuery = String.Format("EXEC SPI_ServiciosAtencion @tipoAutorizacion={0}, @noAutorizacion='{1}', @codServ='{2}', @radicado='{3}', @idUser={4}, @indSeleccion={5}, @txtAutoCompletar='{6}'", oServiciosAtencion.tipoAutorizacion, oServiciosAtencion.noAutorizacion, oServiciosAtencion.codServ, oServiciosAtencion.radicado, oServiciosAtencion.idUser, oServiciosAtencion.indexSeleccion, oServiciosAtencion.txtBuscado);

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

        // Actualiza un registro de la tabla accion

        public Int32 UpdateServiciosAtencion(ServiciosAtencionEntidad oServiciosAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbServiciosAtencion = new StringBuilder();
            {
                sbServiciosAtencion.Append("UPDATE ServiciosAtencion SET");
                sbServiciosAtencion.Append(" autorizacion='" + oServiciosAtencion.noAutorizacion + "'");
                //sbServiciosAtencion.Append(", cantServ ='" + oServiciosAtencion.cantServ + "'");
                sbServiciosAtencion.Append(", codServ='" + oServiciosAtencion.codServ + "'");
                //sbServiciosAtencion.Append(", nvoServ='" + oServiciosAtencion.nvoServ + "'");
                //sbServiciosAtencion.Append(", observServ='" + oServiciosAtencion.observServ + "'");
                sbServiciosAtencion.Append(", tipoAutoriz='" + oServiciosAtencion.tipoAutorizacion + "'");
                //sbServiciosAtencion.Append(", vrProd='" + oServiciosAtencion.vrProd + "'");
                //sbServiciosAtencion.Append(", vrTotal='" + oServiciosAtencion.vrTotal + "'");
                sbServiciosAtencion.Append(" WHERE idServ='" + oServiciosAtencion.idServ + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbServiciosAtencion.ToString());

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
