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

        public AtencClinicasXAfiliado buscar(String docIden = "", Int32 programa = 0, String nit = "", String codDx = "", String fecDesde = "", String fecHasta = "", String filtroNombre = "", Int32 limitInf = 0, Int32 limitSup = 0, Int32 orden = 0, Int32 idEstadoAtenc = 0)
        {
            IDataReader reader;
            AtencClinicasXAfiliado lista = new AtencClinicasXAfiliado();
            String sQuery = String.Format("EXEC SP_BuscarAtencClinicas @docIden='{0}', @programa={1}, @nit='{2}', @codDx='{3}', @fecDesde='{4}', @fecHasta='{5}', @filtroNombre='{6}', @limitInf={7}, @limitSup={8}, @orden={9}, @idEstadoAtenc={10}", docIden, programa, nit, codDx, fecDesde, fecHasta, filtroNombre, limitInf, limitSup, orden, idEstadoAtenc);

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery.ToString());

                while (reader.Read())
                {
                    AtencClinicasXAfiliadoEntidad ac = new AtencClinicasXAfiliadoEntidad();
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
                    ac.nombreCompleto = reader["apellido_a"] + " " + reader["apellido_b"] + " " + reader["nombre_a"] + " " + reader["nombre_b"];
                    ac.medico = reader["medico"] != DBNull.Value ? (String)reader["medico"] : String.Empty;
                    ac.cama = reader["cama"] != DBNull.Value ? (String)reader["cama"] : String.Empty;
                    ac.tipoAtencion = reader["tipoAtencion"] != DBNull.Value ? (String)reader["tipoAtencion"] : String.Empty;
                    ac.motivoSalida = reader["motivoSalida"] != DBNull.Value ? (String)reader["motivoSalida"] : String.Empty;
                    ac.tipoEstancia = reader["abrevTipoEstancia"] != DBNull.Value ? (String)reader["abrevTipoEstancia"] : String.Empty;
                    ac.puntaje = reader["puntaje"].ToString() != "" ? Int32.Parse(reader["puntaje"].ToString()) : 0;
                    ac.diasEstancia = reader["diasEstancia"].ToString() != "" ? Int32.Parse(reader["diasEstancia"].ToString()) : 0;
                    ac.estadoAtenc = reader["estadoAtenc"].ToString();
                    ac.idAtencion = Int32.Parse(reader["idAtencion"].ToString());
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

        public AtencClinicasXAfiliado getAuditorias(Int32 idUserEstablece, String fecAuditoria)
        {
            IDataReader reader;
            AtencClinicasXAfiliado lista = new AtencClinicasXAfiliado();
            String sQuery = String.Format("EXEC SPS_Auditorias @idUserEstablece={0}, @fecAuditoria='{1}'", idUserEstablece, fecAuditoria);

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery.ToString());

                while (reader.Read())
                {
                    AtencClinicasXAfiliadoEntidad ac = new AtencClinicasXAfiliadoEntidad();
                    ac.cama = reader["cama"] != DBNull.Value ? (String)reader["cama"] : String.Empty;
                    ac.codDx = reader["codDx"] != DBNull.Value ? (String)reader["codDx"] : String.Empty;
                    ac.diasEstancia = reader["diasEstancia"] != DBNull.Value ? Convert.ToInt32(reader["diasEstancia"].ToString()) : 0;
                    ac.docIden = reader["docIden"] != DBNull.Value ? (String)reader["docIden"] : String.Empty;
                    ac.especialidad = reader["especialidad"] != DBNull.Value ? (String)reader["especialidad"] : String.Empty;
                    ac.fecIngreso = reader["fecIngreso"].ToString();
                    ac.idAtencion = Int32.Parse(reader["idAtencion"].ToString());
                    ac.radicado = reader["radicado"].ToString();
                    ac.estadoAtenc = reader["estadoAtenc"].ToString();
                    ac.nombreCompleto = reader["apellido_a"] + " " + reader["apellido_b"] + " " + reader["nombre_a"] + " " + reader["nombre_b"];
                    ac.tipoEstancia = reader["abrevTipoEstancia"].ToString();
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

        public AtencClinicasXAfiliado getDatosAuditoria(String radicado)
        {
            IDataReader reader;
            AtencClinicasXAfiliado lista = new AtencClinicasXAfiliado();
            String sQuery = String.Format("EXEC SP_Auditoria @radicado='{0}'", radicado);

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery.ToString());

                while (reader.Read())
                {
                    AtencClinicasXAfiliadoEntidad ac = new AtencClinicasXAfiliadoEntidad();
                    ac.mesIngreso = reader["mesIngreso"].ToString();
                    ac.docIden = reader["docIden"] != DBNull.Value ? (String)reader["docIden"] : String.Empty;
                    ac.tipoDoc = reader["tipoDoc"].ToString();
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
                    ac.apellidoA = reader["apellido_a"].ToString();
                    ac.apellidoB = reader["apellido_b"].ToString();
                    ac.nombreA = reader["nombre_a"].ToString();
                    ac.nombreB = reader["nombre_b"].ToString();
                    ac.medico = reader["medico"] != DBNull.Value ? (String)reader["medico"] : String.Empty;
                    ac.cama = reader["cama"] != DBNull.Value ? (String)reader["cama"] : String.Empty;
                    ac.tipoAtencion = reader["tipoAtencion"] != DBNull.Value ? (String)reader["tipoAtencion"] : String.Empty;
                    ac.motivoSalida = reader["motivoSalida"] != DBNull.Value ? (String)reader["motivoSalida"] : String.Empty;
                    ac.tipoEstancia = reader["abrevTipoEstancia"] != DBNull.Value ? (String)reader["abrevTipoEstancia"] : String.Empty;
                    //ac.puntaje = reader["puntaje"].ToString() != "" ? Int32.Parse(reader["puntaje"].ToString()) : 0;
                    ac.diasEstancia = reader["diasEstancia"].ToString() != "" ? Int32.Parse(reader["diasEstancia"].ToString()) : 0;
                    ac.estadoAtenc = reader["estadoAtenc"].ToString();
                    ac.idAtencion = Int32.Parse(reader["idAtencion"].ToString());
                    ac.sexo = reader["sexo"].ToString();
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

        public String establecerAuditar(Int32 idAtencion, Int32 idUser)
        {
            
            oDataAccess.addInParameters("@idAtencion", DbType.Int32, paramValue: idAtencion);
            oDataAccess.addInParameters("@idUser", DbType.Int32, paramValue: idUser);

            try
            {
                oDataAccess.open();
                oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPUI_Auditoria", true);
                String radicado = oDataAccess.commando.Parameters["@RETURN_VALUE"].Value.ToString();
                while (radicado.Length < 8)
                {
                    radicado = "0" + radicado;
                }
                oDataAccess.commando.Parameters.Clear();
                return radicado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public String addAtencClinicasXAfiliados(AtencClinicasEntidad eAten)
        {
            oDataAccess.addInParameters("@docIden", DbType.String, paramValue: eAten.docIden);
            oDataAccess.addInParameters("@idTipoDoc", DbType.Int32, paramValue: eAten.idTipoDoc);
            oDataAccess.addInParameters("@apellido_a", DbType.String, paramValue: eAten.apellidoA);
            oDataAccess.addInParameters("@apellido_b", DbType.String, paramValue: eAten.apellidoB);
            oDataAccess.addInParameters("@nombre_a", DbType.String, paramValue: eAten.nombreA);
            oDataAccess.addInParameters("@nombre_b", DbType.String, paramValue: eAten.nombreB);
            oDataAccess.addInParameters("@fecIngreso", DbType.String, paramValue: eAten.fecIngreso);
            oDataAccess.addInParameters("@horaIngreso", DbType.String, paramValue: eAten.horaIngreso);
            oDataAccess.addInParameters("@diasEstancia", DbType.Int32, paramValue: eAten.diasEstancia);
            oDataAccess.addInParameters("@idEspecialidad", DbType.Int32, paramValue: eAten.especialidad);
            oDataAccess.addInParameters("@codDxCie", DbType.String, paramValue: eAten.codDx);
            oDataAccess.addInParameters("@codDxRel", DbType.String, paramValue: eAten.codDxRel);
            oDataAccess.addInParameters("@fecNacimiento", DbType.String, paramValue: eAten.fecNacimiento);
            oDataAccess.addInParameters("@edad", DbType.Int32, paramValue: eAten.edad);
            oDataAccess.addInParameters("@tipoEdad", DbType.Int32, paramValue: eAten.tipoEdad);
            oDataAccess.addInParameters("@medico", DbType.String, paramValue: eAten.medico);
            oDataAccess.addInParameters("@contrato", DbType.Int32, paramValue: eAten.contrato);
            oDataAccess.addInParameters("@tipoContrato", DbType.Int32, paramValue: eAten.tipoContrato);
            oDataAccess.addInParameters("@tipoAtencionIngreso", DbType.Int32, paramValue: eAten.idTipoAtencion);
            oDataAccess.addInParameters("@cama", DbType.String, paramValue: eAten.cama);
            oDataAccess.addInParameters("@pabellon", DbType.String, paramValue: eAten.pabellon);
            oDataAccess.addInParameters("@idUser", DbType.Int32, paramValue: eAten.idUser);
            oDataAccess.addInParameters("@sexo", DbType.String, paramValue: eAten.sexo); ;
            try
            {
                oDataAccess.open();
                oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPI_Atencion", true);
                String radicado = oDataAccess.commando.Parameters["@RETURN_VALUE"].Value.ToString();
                while (radicado.Length < 8)
                {
                    radicado = "0" + radicado;
                }
                oDataAccess.commando.Parameters.Clear();
                return radicado;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
