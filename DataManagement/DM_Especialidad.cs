using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_Especialidad
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de Especialidad
        public Especialidad GetEspecialidad(Int32 idEspecialidad = 0, String especialidad = "")
        {
            StringBuilder sbEspecialidad = new StringBuilder();
            IDataReader reader;
            Especialidad lista = new Especialidad();
            EspecialidadEntidad oEspecialidad = new EspecialidadEntidad();

            sbEspecialidad.Append("SELECT");
            sbEspecialidad.Append(" idEspecialidad");
            sbEspecialidad.Append(", especialidad");
            sbEspecialidad.Append(", subMayor");
            sbEspecialidad.Append(", clase");
            sbEspecialidad.Append(", activo");
            sbEspecialidad.Append(" FROM especialidad");            

            if (idEspecialidad != 0)
            {
                sbEspecialidad.Append(" WHERE idEspecialidad='" + idEspecialidad + "'");
            }
            else
            {
                if (especialidad != "")
                {
                    sbEspecialidad.Append(" WHERE especialidad LIKE '%" + especialidad + "%'");
                }
            }

            sbEspecialidad.Append(" ORDER BY especialidad");

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbEspecialidad.ToString());

                while (reader.Read())
                {
                    oEspecialidad = new EspecialidadEntidad();
                    oEspecialidad.idEspecialidad = Int32.Parse(reader["idEspecialidad"].ToString());
                    oEspecialidad.especialidad = reader["especialidad"].ToString();
                    oEspecialidad.subMayor = reader["subMayor"].ToString();
                    oEspecialidad.clase = reader["clase"].ToString();
                    oEspecialidad.activo = Boolean.Parse(reader["activo"].ToString());
                    
                    lista.Add(oEspecialidad);

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

        public Especialidad getEspecialidad3ro(String nit = "")
        {
            StringBuilder sbEspecialidad = new StringBuilder();
            IDataReader reader;
            Especialidad lista = new Especialidad();
            EspecialidadEntidad oEspecialidad = new EspecialidadEntidad();

            sbEspecialidad.Append("SELECT");
            sbEspecialidad.Append(" idEspecialidad");
            sbEspecialidad.Append(", especialidad");
            sbEspecialidad.Append(", subMayor");
            sbEspecialidad.Append(", clase");
            sbEspecialidad.Append(", activo");
            sbEspecialidad.Append(" FROM especialidad AS esp");
            sbEspecialidad.Append(" INNER JOIN especialidad3ro as esp3");
            sbEspecialidad.Append(" ON esp.idEspecialidad = esp3.codigoEspecialidad");
           
            if (nit != "")
            {
                sbEspecialidad.Append(" WHERE nitEntidad ='" + nit + "'");
            }

            sbEspecialidad.Append(" ORDER BY esp.especialidad");

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbEspecialidad.ToString());

                while (reader.Read())
                {
                    oEspecialidad = new EspecialidadEntidad();
                    oEspecialidad.idEspecialidad = Int32.Parse(reader["idEspecialidad"].ToString());
                    oEspecialidad.especialidad = reader["especialidad"].ToString();
                    oEspecialidad.subMayor = reader["subMayor"].ToString();
                    oEspecialidad.clase = reader["clase"].ToString();
                    oEspecialidad.activo = Boolean.Parse(reader["activo"].ToString());
                    
                    lista.Add(oEspecialidad);

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

        // adiciona una nueva Especialidad
        public Int32 AddEspecialidad(EspecialidadEntidad oEspecialidad)
        {
            Int32 retorno = 0;
            StringBuilder sbEspecialidad = new StringBuilder();
            {
                sbEspecialidad.Append("INSERT INTO Especialidad(");
                sbEspecialidad.Append(" idEspecialidad");
                sbEspecialidad.Append(", especialidad");
                sbEspecialidad.Append(", subMayor");
                sbEspecialidad.Append(", clase");
                sbEspecialidad.Append(", activo");
                sbEspecialidad.Append(")");
                sbEspecialidad.Append(" VALUES(");
                sbEspecialidad.Append("'" + oEspecialidad.idEspecialidad + "'");
                sbEspecialidad.Append(", '" + oEspecialidad.especialidad + "'");
                sbEspecialidad.Append(", '" + oEspecialidad.subMayor + "'");
                sbEspecialidad.Append(", '" + oEspecialidad.clase + "'");
                sbEspecialidad.Append(", '" + oEspecialidad.activo + "'");
                sbEspecialidad.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbEspecialidad.ToString());

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

        // Actualiza un registro de la tabla Especialidad

        public Int32 UpdateEspecialidad(EspecialidadEntidad oEspecialidad)
        {
            Int32 retorno = 0;
            StringBuilder sbEspecialidad = new StringBuilder();
            {
                sbEspecialidad.Append("UPDATE especialidad SET");
                sbEspecialidad.Append(" idEspecialidad='" + oEspecialidad.idEspecialidad + "'");
                sbEspecialidad.Append(" ,especialidad='" + oEspecialidad.especialidad + "'");
                sbEspecialidad.Append(" ,subMayor='" + oEspecialidad.subMayor + "'");
                sbEspecialidad.Append(" ,clase='" + oEspecialidad.clase + "'");
                sbEspecialidad.Append(" ,activo='" + oEspecialidad.activo + "'");
                sbEspecialidad.Append(" WHERE idEspecialidad='" + oEspecialidad.idEspecialidad + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbEspecialidad.ToString());
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
