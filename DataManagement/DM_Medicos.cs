using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_Medicos
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public Medicos getMedicos(Int32 idMedico = 0, String nombreMedico = "")
        {
            StringBuilder sb = new StringBuilder();
            IDataReader reader;
            Medicos lista = new Medicos();
            MedicosEntidad oMedicos = new MedicosEntidad();
            String w = " WHERE";
            
            sb.Append("SELECT");
            sb.Append(" idMedico");
            sb.Append(", nombreMedico");
            sb.Append(", docMedico");
            sb.Append(" FROM medicos");

            if (idMedico != 0)
            {
                sb.Append(w + " idMedico='" + idMedico + "'");
                w = " AND";
            }

            if (nombreMedico != "")
            {
                sb.Append(w + " nombreMedico like '%" + nombreMedico + "%'");
            }

            sb.Append(" ORDER BY nombreMedico");

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sb.ToString());

                while (reader.Read())
                {
                    oMedicos = new MedicosEntidad();
                    oMedicos.idMedico = Int32.Parse(reader["idMedico"].ToString());
                    oMedicos.nombreMedico = reader["nombreMedico"].ToString();
                    oMedicos.docMedico = reader["docMedico"].ToString();
                    lista.Add(oMedicos);

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

        // adiciona una nueva accion
        public Int32 addMedico(MedicosEntidad oMedicos)
        {
            Int32 retorno = 0;
            StringBuilder sb = new StringBuilder();
            {
                sb.Append("INSERT INTO medicos(");
                sb.Append(" docMedico");
                sb.Append(", nombreMedico");
                sb.Append(")");
                sb.Append(" VALUES(");
                sb.Append(" '" + oMedicos.docMedico + "'");
                sb.Append(", '" + oMedicos.nombreMedico + "'");
                sb.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sb.ToString());

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

        public Int32 updateMedico(MedicosEntidad oMedicos)
        {
            Int32 retorno = 0;
            StringBuilder sbAreasAtencion = new StringBuilder();
            {
                sbAreasAtencion.Append("UPDATE accion SET");
                sbAreasAtencion.Append(" docMedico='" + oMedicos.docMedico + "'");
                sbAreasAtencion.Append(", nombreMedico='" + oMedicos.nombreMedico + "'");
                sbAreasAtencion.Append(" WHERE idMedico='" + oMedicos.idMedico + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbAreasAtencion.ToString());
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
