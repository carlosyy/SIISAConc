using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataAccess;
using Entities;
using System.Data;

namespace DataManagement
{
    public class DM_AtencClinicasXAfiliados
    {
        readonly SQLConn oDataAccess = new SQLConn();

        public atencClinicasXAfiliado Buscar(String docIden = "", Int32 programa = 0, String nit = "", String codDx = "", String fecDesde = "", String fecHasta = "", String filtroNombre = "", Int32 limitInf = 0, Int32 limitSup = 0, Int32 orden = 0)
        {
            IDataReader reader;
            atencClinicasXAfiliado lista = new atencClinicasXAfiliado();
            String sQuery = String.Format("EXEC SP_BuscarAtencClinicas @docIden='{0}', @programa={1}, @nit='{2}', @codDx='{3}', @fecDesde='{4}', @fecHasta='{5}', @filtroNombre='{6}', @limitInf={7}, @limitSup={8}, @orden={9}", docIden, programa, nit, codDx, fecDesde, fecHasta, filtroNombre, limitInf, limitSup, orden);

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery.ToString());

                while (reader.Read())
                {
                    atencClinicasXAfiliadoEntidad ac = new atencClinicasXAfiliadoEntidad();
                    ac.mesIngreso = reader["mesIngreso"].ToString();
                    ac.docIden = reader["docIden"] != DBNull.Value ? (String)reader["docIden"] : String.Empty;
                    ac.programa = reader["programa"].ToString() == "" ? 0 : Int32.Parse(reader["programa"].ToString());
                    ac.nitIps = reader["nitIps"] != DBNull.Value ? reader["nitIps"].ToString() : String.Empty;
                    ac.entidad = reader["entidad"].ToString();
                    ac.fecIngreso = reader["fecIngreso"].ToString();
                    ac.fecEgreso = reader["fecEgreso"].ToString();
                    ac.diasEstancia = reader["diasEstancia"] != DBNull.Value ? Convert.ToInt32(reader["diasEstancia"].ToString()) : 0;
                    ac.especialidad = reader["especialidad"] != DBNull.Value ? (String)reader["especialidad"] : String.Empty;
                    ac.codDx = reader["codDx"] != DBNull.Value ? (String)reader["codDx"] : String.Empty;
                    ac.dx = reader["dx"] != DBNull.Value ? (String)reader["dx"] : String.Empty;
                    //ac.codDxRel = reader["codDxRel"] != DBNull.Value ? (String)reader["codDxRel"] : String.Empty;
                    ac.nombre_a = reader["nombre_a"] + " " + reader["nombre_b"].ToString() + " " + reader["apellido_a"].ToString() + " " + reader["apellido_b"].ToString();
                    ac.medico = reader["medico"] != DBNull.Value ? (String)reader["medico"] : String.Empty;
                    ac.cama = reader["cama"] != DBNull.Value ? (String)reader["cama"] : String.Empty;
                    ac.tipoAtencion = reader["tipoAtencion"] != DBNull.Value ? (String)reader["tipoAtencion"] : String.Empty;
                    ac.motivoSalida = reader["motivoSalida"] != DBNull.Value ? (String)reader["motivoSalida"] : String.Empty;
                    ac.tipoEstancia = reader["abrevTipoEstancia"] != DBNull.Value ? (String)reader["abrevTipoEstancia"] : String.Empty;
                    ac.puntaje = reader["puntaje"].ToString() != "" ? Int32.Parse(reader["puntaje"].ToString()) : 0;
                    ac.diasEstancia = reader["diasEstancia"].ToString() != "" ? Int32.Parse(reader["diasEstancia"].ToString()) : 0;
                    ac.estadoRad = reader["estadoRad"].ToString();
                    ac.idRadicado = Int32.Parse(reader["idRadicado"].ToString());
                    lista.Add(ac);
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

        public Int32 contarAtenciones(String docIden = "", Int32 programa = 0, String nit = "", String codDx = "", String fecDesc = "", String fecHasta = "", String filtroNombre = "")
        {
            Int32 retorno = 0;
            StringBuilder sb = new StringBuilder();
            IDataReader reader;
            String where=" WHERE";

            sb.Append("SELECT COUNT(atc.docIden) as cuentaDocs");
            sb.Append(" FROM atencClinicas as atc");

            if (filtroNombre != "")
            {
                sb.Append(" INNER JOIN afiliados as af ON af.docIden=atc.docIden");
                sb.Append(where + " af.apellido_a+af.apellido_b+af.nombre_a+af.nombre_b+af.docIden like'%" + filtroNombre + "%'");
                where=" AND";
            }

            if (docIden != "")
            {
                sb.Append(where + " atc.docIden='" + docIden + "'");
                where = " AND";
            }

            if (programa != 0)
            {
                sb.Append(where + " atc.programa=" + programa + "");
                where = " AND";
            }

            if (nit != "")
            {
                sb.Append(where + " atc.nitIps='" + nit + "'");
                where = " AND";
            }

            if (codDx != "")
            {
                sb.Append(where + " atc.codDx='" + codDx + "'");
                where = " AND";
            }

            if (fecDesc != "")
            {
                sb.Append(where + " atc.fecIngreso>'" + fecDesc + "'");
                where = " AND";
            }

            if (fecHasta != "")
            {
                sb.Append(where + " atc.fecIngreso<'" + fecHasta + "'");
                where = " AND";
            }
            
            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sb.ToString());

                while (reader.Read())
                {
                    retorno = Int32.Parse(reader["cuentaDocs"].ToString());
                }
                reader.Close();
                oDataAccess.close();

            }
            catch (Exception)
            {

                throw;
            }

            return retorno;
        }

        public Int32 establecerAuditar(Int32 idRadicado)
        {
            String sQuery = "UPDATE atencClinicas set idEstadoRev=2 WHERE idRadicado='" + idRadicado + "'";
            oDataAccess.open();
            try
            {
                Int32 retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);
                return retorno;
            }
            catch (Exception)
            {
                    
                throw;
            }
        }
        public Int32 addAtencClinicasXAfiliados(atencClinicasEntidad eAten)
        {
            String sQuery = String.Format("EXEC SPI_Atencion @docIden='{0}', ");
            try
            {
                oDataAccess.open();
                Int32 retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);
                oDataAccess.close();
                return retorno;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
