using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;
using System.Data.Common;

namespace DataManagement
{
    public class DM_Servicios
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de Servicios
        public servicios GetServicios(String codServ = "", String descripcion = "", String tipoBusq = "c")
        {
            servicios lServicios = new servicios();
            IDataReader reader;
            //  AccionL lista = new AccionL();            
            String sQuery = string.Format("EXEC SPS_Servicios @codServ='{0}', @descServ='{1}', @tipoBusq='{2}'", codServ, descripcion, tipoBusq);

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery.ToString());
                while (reader.Read())
                {
                    lServicios.Add(new serviciosEntidad()
                    {
                        codConcepto = int.Parse(reader["codConcepto"].ToString()),
                        codServ = reader["codServ"].ToString(),
                        descripcion = reader["descripcion"].ToString(),
                        idArea = int.Parse(reader["idArea"].ToString()),
                        inactivo = bool.Parse(reader["inactivo"].ToString())
                    });
                }
            }
            catch (DbException ex)
            {

                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (lServicios);
        }

        public servicios getServicioxCod(String codServ)
        {
            StringBuilder sbServicios = new StringBuilder();
            IDataReader reader;
            servicios lServicios = new servicios();


            sbServicios.Append("SELECT");
            sbServicios.Append(" codServ");
            sbServicios.Append(", descripcion");
            sbServicios.Append(", codConcepto");
            sbServicios.Append(" FROM servicios");


            if (codServ != "")
            {
                sbServicios.Append(" WHERE codServ ='" + codServ + "'");
            }         


            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbServicios.ToString());

                while (reader.Read())
                {
                    lServicios.Add(new serviciosEntidad()
                    {
                        codConcepto = int.Parse(reader["codConcepto"].ToString()),
                        codServ = reader["codServ"].ToString(),
                        descripcion = reader["descripcion"].ToString()
                    });

                }
                reader.Close();

                return lServicios;
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



        public String getExisteServicio(String codServ = "", String descripServ = "")
        {
            StringBuilder sbServicios = new StringBuilder();
            IDataReader reader;
            String codServicio = String.Empty;
            

            sbServicios.Append("SELECT");
            sbServicios.Append(" codServ");
            sbServicios.Append(" FROM servicios");


            if (codServ != "")
            {
                sbServicios.Append(" WHERE codServ ='" + codServ + "'");
            }
            else if (descripServ != "")
            {
                sbServicios.Append(" WHERE descripcion ='" + codServ + "'");
            }
            

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbServicios.ToString());

                while (reader.Read())
                {
                    codServicio = reader["codServ"].ToString();                    

                }
                reader.Close();

                return codServicio;
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


        public servicios getCodDescr(String codDescr = "", String tipoBusq = "c")
        {
            servicios lServicios = new servicios();
            IDataReader reader;
            String sQuery = string.Format("EXEC SPS_DescServicios @busqueda='{0}', @tipoBusq='{1}'", codDescr, tipoBusq);
            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery.ToString());
                while (reader.Read())
                {
                    lServicios.Add(new serviciosEntidad()
                    {
                        codServ = reader["codServ"].ToString(),
                        descripcion = (reader["codDesc"].ToString().Length > 60 ? reader["codDesc"].ToString().Substring(0, 60) : reader["codDesc"].ToString())
                    });
                }
                reader.Close();
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (lServicios);
        }


        // adiciona una nueva Servicios
        public Int32 AddServicios(serviciosEntidad oServicios)
        {
            Int32 retorno = 0;
            StringBuilder sbServicios = new StringBuilder();
            {
                sbServicios.Append("INSERT INTO servicios(");
                sbServicios.Append(" codServ");
                sbServicios.Append(", descripcion");
                sbServicios.Append(", codConcepto");
                sbServicios.Append(", idArea");
                sbServicios.Append(", codificacion");
                sbServicios.Append(", inactivo");
                sbServicios.Append(")");
                sbServicios.Append(" VALUES(");
                sbServicios.Append("'" + oServicios.codServ + "'");
                sbServicios.Append(", '" + oServicios.descripcion + "'");
                sbServicios.Append(", '" + oServicios.codConcepto + "'");
                sbServicios.Append(", '" + oServicios.idArea + "'");
                sbServicios.Append(", '" + oServicios.codificacion + "'");
                sbServicios.Append(", '" + oServicios.inactivo + "'");
                sbServicios.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbServicios.ToString());

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

        // Actualiza un registro de la tabla Servicios

        public Int32 UpdateServicios(serviciosEntidad oServicios)
        {
            Int32 retorno = 0;
            StringBuilder sbServicios = new StringBuilder();
            {
                sbServicios.Append("UPDATE servicios SET");                
                sbServicios.Append(" ,descripcion='" + oServicios.descripcion + "'");
                sbServicios.Append(" ,codConcepto='" + oServicios.codConcepto + "'");
                sbServicios.Append(" ,idArea='" + oServicios.idArea + "'");
                sbServicios.Append(" ,codificacion='" + oServicios.codificacion + "'");
                sbServicios.Append(" ,inactivo='" + oServicios.inactivo + "'");
                sbServicios.Append(" WHERE codServ='" + oServicios.codServ + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbServicios.ToString());
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
