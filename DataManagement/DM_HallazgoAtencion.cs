using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_HallazgoAtencion
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public HallazgoAtencion GetHallazgoAtencion(Int32 id = 0, String hallazgoAtencion = "")
        {
            StringBuilder sbHallazgoAtencion = new StringBuilder();
            IDataReader reader;
            HallazgoAtencion lista = new HallazgoAtencion();
            HallazgoAtencionEntidad oHallazgoAtencion = new HallazgoAtencionEntidad();

            sbHallazgoAtencion.Append("SELECT");
            sbHallazgoAtencion.Append(" idHallazgoAtencion");
            sbHallazgoAtencion.Append(", hallazgoAtencion");
            sbHallazgoAtencion.Append(", idDatosUS");
            sbHallazgoAtencion.Append(", idAuditor");
            sbHallazgoAtencion.Append(", idArea");
            sbHallazgoAtencion.Append(", idPertinenciaAtencion");
            sbHallazgoAtencion.Append(", idInoportunidadAtencion");
            sbHallazgoAtencion.Append(", idNoCalidadAtencion");
            sbHallazgoAtencion.Append(", idEventosAdversosAtencion");
            sbHallazgoAtencion.Append(" FROM hallazgoAtencion");

            if (id != 0)
            {
                sbHallazgoAtencion.Append(" WHERE idHallazgoAtencion='" + id + "'");
            }
            else
            {
                if (hallazgoAtencion != "")
                {
                    sbHallazgoAtencion.Append(" WHERE hallazgoAtencion='" + hallazgoAtencion + "'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbHallazgoAtencion.ToString());

                while (reader.Read())
                {
                    oHallazgoAtencion = new HallazgoAtencionEntidad();
                    oHallazgoAtencion.idhallazgoAtencion = Int32.Parse(reader["idhallazgoAtencion"].ToString());
                    oHallazgoAtencion.hallazgoAtencion = reader["hallazgoAtencion"].ToString();
                    oHallazgoAtencion.idDatosUS = Int32.Parse(reader["idDatosUS"].ToString());
                    oHallazgoAtencion.idAuditor = Int32.Parse(reader["idAuditor"].ToString());
                    oHallazgoAtencion.idArea = Int32.Parse(reader["idArea"].ToString());
                    oHallazgoAtencion.idPertinenciaAtencion = Int32.Parse(reader["idPertinenciaAtencion"].ToString());
                    oHallazgoAtencion.idInoportunidadAtencion = Int32.Parse(reader["idInoportunidadAtencion"].ToString());
                    oHallazgoAtencion.idNoCalidadAtencion = Int32.Parse(reader["idNoCalidadAtencion"].ToString());
                    oHallazgoAtencion.idEventosAdversosAtencion = Int32.Parse(reader["idEventosAdversosAtencion"].ToString());
                    lista.Add(oHallazgoAtencion);

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


        public HallazgoAtencion GetHallazgoAtencionXRadicado(String radicado)
        {
            StringBuilder sbHallazgoAtencion = new StringBuilder();
            IDataReader reader;
            HallazgoAtencion lista = new HallazgoAtencion();
            HallazgoAtencionEntidad oHallazgoAtencion = new HallazgoAtencionEntidad();

            sbHallazgoAtencion.Append("SELECT ha.idHallazgoAtencion");            
            sbHallazgoAtencion.Append(", ha.radicado");
            sbHallazgoAtencion.Append(", ha.fechaRegistro");
            sbHallazgoAtencion.Append(", ha.idTipoHallazgo");
            sbHallazgoAtencion.Append(", ha.hallazgoAtencion");
            sbHallazgoAtencion.Append(", ha.idAuditor");
            sbHallazgoAtencion.Append(", ha.idArea");
            sbHallazgoAtencion.Append(", ha.idPertinenciaAtencion");
            sbHallazgoAtencion.Append(", ha.idInoportunidadAtencion");
            sbHallazgoAtencion.Append(", ha.idNoCalidadAtencion");
            sbHallazgoAtencion.Append(", ha.idEventosAdversosAtencion");
            sbHallazgoAtencion.Append(", ea.eventosAdversosAtencion");
            sbHallazgoAtencion.Append(", pa.pertinenciaAtencion");
            sbHallazgoAtencion.Append(", aa.areasAtencion");
            sbHallazgoAtencion.Append(", us.nombreUsuario");
            sbHallazgoAtencion.Append(", noca.noCalidadAtencion");
            sbHallazgoAtencion.Append(", ia.inoportunidadAtencion");
            sbHallazgoAtencion.Append(", th.tipoHallazgo");
            sbHallazgoAtencion.Append(" FROM hallazgoAtencion AS ha LEFT OUTER JOIN");
            sbHallazgoAtencion.Append(" pertinenciaAtencion AS pa ON ha.idPertinenciaAtencion = pa.idPertinenciaAtencion LEFT OUTER JOIN");
            sbHallazgoAtencion.Append(" eventosAdversosAtencion AS ea ON ha.idEventosAdversosAtencion = ea.idEventosAdversosAtencion LEFT OUTER JOIN");
            sbHallazgoAtencion.Append(" inoportunidadAtencion AS ia ON ha.idInoportunidadAtencion = ia.idInoportunidadAtencion LEFT OUTER JOIN");
            sbHallazgoAtencion.Append(" noCalidadAtencion AS noca ON ha.idNoCalidadAtencion = noca.idNoCalidadAtencion LEFT OUTER JOIN");
            sbHallazgoAtencion.Append(" areasAtencion AS aa ON ha.idArea = aa.idAreasAtencion LEFT OUTER JOIN");
            sbHallazgoAtencion.Append(" usuarios AS us ON ha.idAuditor = us.idUser LEFT OUTER JOIN");
            sbHallazgoAtencion.Append(" tipoHallazgo AS th ON th.idTipoHallazgo = ha.idTipoHallazgo");
            sbHallazgoAtencion.Append(" WHERE ha.radicado='" + radicado + "'");



            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbHallazgoAtencion.ToString());

                while (reader.Read())
                {
                    oHallazgoAtencion = new HallazgoAtencionEntidad();
                    oHallazgoAtencion.idhallazgoAtencion = Int32.Parse(reader["idhallazgoAtencion"].ToString());
                    oHallazgoAtencion.hallazgoAtencion = reader["hallazgoAtencion"].ToString();
                    oHallazgoAtencion.nTipoHallazgo = reader["tipoHallazgo"].ToString();
                    oHallazgoAtencion.radicado = reader["radicado"].ToString();
                    oHallazgoAtencion.idAuditor = Int32.Parse(reader["idAuditor"].ToString());
                    oHallazgoAtencion.nAuditor = reader["nombreUsuario"].ToString();
                    oHallazgoAtencion.idArea = Int32.Parse(reader["idArea"].ToString());
                    oHallazgoAtencion.nArea = reader["areasAtencion"].ToString();
                    oHallazgoAtencion.idPertinenciaAtencion = Int32.Parse(reader["idPertinenciaAtencion"].ToString());
                    oHallazgoAtencion.nPertinenciaAtencion = reader["pertinenciaAtencion"].ToString();
                    oHallazgoAtencion.idInoportunidadAtencion = Int32.Parse(reader["idInoportunidadAtencion"].ToString());
                    oHallazgoAtencion.nInoportunidadAtencion = reader["inoportunidadAtencion"].ToString();
                    oHallazgoAtencion.idNoCalidadAtencion = Int32.Parse(reader["idNoCalidadAtencion"].ToString());
                    oHallazgoAtencion.nNoCalidadAtencion = reader["noCalidadAtencion"].ToString();
                    oHallazgoAtencion.idEventosAdversosAtencion = Int32.Parse(reader["idEventosAdversosAtencion"].ToString());
                    oHallazgoAtencion.nEventosAdversosAtencion = reader["eventosAdversosAtencion"].ToString();
                    lista.Add(oHallazgoAtencion);

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

        // adiciona una nuevo hallazgo
        public Int32 AddHallazgoAtencion(HallazgoAtencionEntidad oHallazgoAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbHallazgoAtencion = new StringBuilder();
            {
                sbHallazgoAtencion.Append("INSERT INTO hallazgoAtencion(");
                sbHallazgoAtencion.Append(" hallazgoAtencion");
                sbHallazgoAtencion.Append(", fecHallazgo");
                sbHallazgoAtencion.Append(", radicado");                
                sbHallazgoAtencion.Append(", idAuditor");
                sbHallazgoAtencion.Append(", idArea");
                sbHallazgoAtencion.Append(", idPertinenciaAtencion");
                sbHallazgoAtencion.Append(", idInoportunidadAtencion");
                sbHallazgoAtencion.Append(", idNoCalidadAtencion");
                sbHallazgoAtencion.Append(", idEventosAdversosAtencion");
                sbHallazgoAtencion.Append(", idTipoHallazgo");
                sbHallazgoAtencion.Append(")");
                sbHallazgoAtencion.Append(" VALUES(");
                sbHallazgoAtencion.Append(" '" + oHallazgoAtencion.hallazgoAtencion + "'");
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.fecHallazgo + "'");
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.radicado + "'");                
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.idAuditor + "'");
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.idArea + "'");
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.idPertinenciaAtencion + "'");
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.idInoportunidadAtencion + "'");
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.idNoCalidadAtencion + "'");
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.idEventosAdversosAtencion + "'");
                sbHallazgoAtencion.Append(", '" + oHallazgoAtencion.idTipoHallazgo + "'");
                sbHallazgoAtencion.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbHallazgoAtencion.ToString());

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

        public Int32 UpdateHallazgoAtencion(HallazgoAtencionEntidad oHallazgoAtencion)
        {
            Int32 retorno = 0;
            StringBuilder sbHallazgoAtencion = new StringBuilder();
            {
                sbHallazgoAtencion.Append("UPDATE hallazgoAtencion SET");
                sbHallazgoAtencion.Append(" hallazgoAtencion='" + oHallazgoAtencion.hallazgoAtencion + "'");
                sbHallazgoAtencion.Append(" ,idDatosUS='" + oHallazgoAtencion.idDatosUS + "'");
                sbHallazgoAtencion.Append(" ,idAuditor='" + oHallazgoAtencion.idAuditor + "'");
                sbHallazgoAtencion.Append(" ,idArea='" + oHallazgoAtencion.idArea + "'");
                sbHallazgoAtencion.Append(" ,idPertinenciaAtencion='" + oHallazgoAtencion.idPertinenciaAtencion + "'");
                sbHallazgoAtencion.Append(" ,idInoportunidadAtencion='" + oHallazgoAtencion.idInoportunidadAtencion + "'");
                sbHallazgoAtencion.Append(" ,idNoCalidadAtencion='" + oHallazgoAtencion.idNoCalidadAtencion + "'");
                sbHallazgoAtencion.Append(" ,idEventosAdversosAtencion='" + oHallazgoAtencion.idEventosAdversosAtencion + "'");
                sbHallazgoAtencion.Append(" WHERE idhallazgoAtencion='" + oHallazgoAtencion.idhallazgoAtencion + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbHallazgoAtencion.ToString());
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

        public String getCorreoNotifHallazgo(String area, String radicado)
        {
            String sQuery = String.Format("EXEC SPS_CorreoNotifHallazgo @area='{0}', @radicado='{1}'", area, radicado);
            IDataReader reader;
            String correoNotifHallazgo = "";
            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery);

                while (reader.Read())
                {
                    correoNotifHallazgo = reader["correo"].ToString();
                }
                reader.Close();

                return correoNotifHallazgo;
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
