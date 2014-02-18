using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;
using System.Data.Common;

namespace DataManagement
{
    public class DM_Listados
    {

        SQLConn oDataAccess = new SQLConn();

        // selecciona todos los atributos de Listados
        public Listados GetListados(String docIden = "", Int32 top = 0)
        {
            StringBuilder sbListados = new StringBuilder();
            IDataReader reader;
            Listados lista = new Listados();
            ListadosEntidad oListados = new ListadosEntidad();

            sbListados.Append("SELECT");
            if (top != 0)
            {
                sbListados.Append(" TOP (" + top + ")");
            }
            sbListados.Append(" CAST(MONTH(l.mesListado) AS NVARCHAR(2)) +'-' + CAST(YEAR(l.mesListado) AS NVARCHAR(4)) AS mesListado");
            sbListados.Append(", l.programa");
            sbListados.Append(" FROM Listados as l");            

            if (docIden != "")
            {
                sbListados.Append(" WHERE docIden ='" + docIden + "'");
            }
            if (top != 0)
            {
                sbListados.Append(" ORDER BY l.mesListado DESC");
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbListados.ToString());

                while (reader.Read())
                {
                    oListados = new ListadosEntidad();
                    oListados.mesListado = reader["mesListado"].ToString();
                    oListados.programa = Int32.Parse(reader["programa"].ToString() == "" ? "0" : reader["programa"].ToString());
                    lista.Add(oListados);

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

        public Listados GetDatosListados(String docIden, String mesListado)
        {
            StringBuilder sbListados = new StringBuilder();
            IDataReader reader;
            Listados lista = new Listados();
            ListadosEntidad oListados = new ListadosEntidad();

            sbListados.Append("SELECT");
            sbListados.Append(" list.mesListado");
            sbListados.Append(", list.programa");
            sbListados.Append(", af.tipodoc");
            sbListados.Append(", list.zona");
            sbListados.Append(", list.programa");
            sbListados.Append(", list.codDane");
            sbListados.Append(", list.cabecera");
            sbListados.Append(", list.codSitioAtenc");
            sbListados.Append(", list.sitioAtenc");
            sbListados.Append(", af.apellido_a");
            sbListados.Append(", af.apellido_b");
            sbListados.Append(", af.nombre_a");
            sbListados.Append(", af.nombre_b");
            sbListados.Append(", af.sexo");
            sbListados.Append(", af.fecNac");
            sbListados.Append(", af.fecAfil");            
            sbListados.Append(" FROM Listados as list INNER JOIN afiliados as af ON af.docIden=list.docIden");            
            sbListados.Append(" WHERE list.docIden ='" + docIden + "'");
            sbListados.Append(" AND list.mesListado ='" + mesListado + "'");

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbListados.ToString());

                while (reader.Read())
                {
                    oListados = new ListadosEntidad();
                    oListados.mesListado = reader["mesListado"].ToString();
                    oListados.programa = Int32.Parse(reader["programa"].ToString());
                    oListados.cabecera = reader["cabecera"].ToString();
                    oListados.codDane = reader["codDane"].ToString();
                    oListados.codSitioAtenc = reader["codSitioAtenc"].ToString();
                    oListados.sitioAtenc = reader["sitioAtenc"].ToString();
                    oListados.zona = Int32.Parse(reader["zona"].ToString());
                    lista.Add(oListados);

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


        // adiciona una nueva Listados
        public Int32 AddListados(ListadosEntidad oListados)
        {
            Int32 retorno = 0;
            StringBuilder sbListados = new StringBuilder();
            {
                sbListados.Append("INSERT INTO Listados(");
                sbListados.Append(" idTipoDoc");
                sbListados.Append(", docIden");
                sbListados.Append(", mesListado");
                sbListados.Append(", tipoAfil");
                sbListados.Append(", zona");
                sbListados.Append(", estado");
                sbListados.Append(", programa");
                sbListados.Append(", codDane");
                sbListados.Append(", cabecera");
                sbListados.Append(", codSitioAtenc");
                sbListados.Append(", sitioAtenc");
                sbListados.Append(", activo");
                sbListados.Append(", ente");
                sbListados.Append(")");
                sbListados.Append(" VALUES(");
                sbListados.Append("'" + oListados.idTipoDoc + "'");
                sbListados.Append(", '" + oListados.docIden + "'");
                sbListados.Append(", '" + oListados.mesListado + "'");
                sbListados.Append(", '" + oListados.tipoAfil + "'");
                sbListados.Append(", '" + oListados.zona + "'");
                sbListados.Append(", '" + oListados.estado + "'");
                sbListados.Append(", '" + oListados.programa + "'");
                sbListados.Append(", '" + oListados.codDane + "'");
                sbListados.Append(", '" + oListados.cabecera + "'");
                sbListados.Append(", '" + oListados.codSitioAtenc + "'");
                sbListados.Append(", '" + oListados.sitioAtenc + "'");
                sbListados.Append(", '" + oListados.activo + "'");
                sbListados.Append(", '" + oListados.ente + "'");
                sbListados.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbListados.ToString());

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

        public Int32 AddListadoAtencionClinicaArchivo(String ruta, String nit)
        {
            Int32 retorno = 0;

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, "EXEC SPI_DatosCSVAtencClini '" + ruta + "', '" + nit + "'");
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

        public Listados addListadosArchivo(String ruta, String mesListado, Boolean activos, Int32 ente)
        {
            Listados lista = new Listados();
            ListadosEntidad oListadosEntidad = new ListadosEntidad();
            IDataReader reader;

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, "EXEC SPI_Listados '" + ruta + "', '" + mesListado + "', '" + activos + "', '" + ente + "'");

                while (reader.Read())
                {
                    oListadosEntidad = new ListadosEntidad();
                    oListadosEntidad.activo = Boolean.Parse(reader["tipo"].ToString());
                    oListadosEntidad.idTipoDoc = Int32.Parse(reader["cantAfil"].ToString());
                    oListadosEntidad.programa = Int32.Parse(reader["cantProg"].ToString());
                    oListadosEntidad.tipoAfil = Int32.Parse(reader["cantSitioAtenc"].ToString());
                    oListadosEntidad.zona = Int32.Parse(reader["cantCabecera"].ToString());
                    oListadosEntidad.sitioAtenc = reader["resultado"].ToString();
                    lista.Add(oListadosEntidad);
                }
                return lista;

            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
        }
    }
}
