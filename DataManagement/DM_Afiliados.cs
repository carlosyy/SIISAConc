using System;
using System.Data;
using System.Data.Common;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_Afiliados
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public Afiliado getAfiliados(String doc = "", String sexo = "", String apellido1 = "", String apellido2 = "")
        {
            StringBuilder sbafiliados = new StringBuilder();
            IDataReader reader;
            Afiliado lista = new Afiliado();
            AfiliadoEntidad oAfiliados = new AfiliadoEntidad();

            sbafiliados.Append("SELECT");
            sbafiliados.Append(" Apellido_a");
            sbafiliados.Append(", Apellido_b");
            sbafiliados.Append(", Dociden");
            sbafiliados.Append(", Nombre_a");
            sbafiliados.Append(", Nombre_b");
            sbafiliados.Append(", sexo");
            sbafiliados.Append(", Tipodoc");
            sbafiliados.Append(" FROM afiliados");

            if (doc != "")
            {
                sbafiliados.Append(" WHERE Dociden='" + doc + "'");
            }

            if (sexo != "")
            {
                sbafiliados.Append(" WHERE sexo='" + sexo + "'");
            }

            if (apellido1 != "" && apellido2 != "")
            {
                sbafiliados.Append(" WHERE Apellido_a LIKE '%" + apellido1 + "%'");
                sbafiliados.Append(" AND Apellido_b LIKE '%" + apellido2 + "%'");
            }
            else
            {
                if (apellido1 != "")
                {
                    sbafiliados.Append(" WHERE Apellido_a LIKE '%" + apellido1 + "%'");
                }

                if (apellido2 != "")
                {
                    sbafiliados.Append(" WHERE Apellido_b LIKE '%" + apellido2 + "%'");
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbafiliados.ToString());

                while (reader.Read())
                {
                    oAfiliados = new AfiliadoEntidad();
                    oAfiliados.apellido1 = reader["Apellido_a"].ToString();
                    oAfiliados.apellido2 = reader["Apellido_b"].ToString();
                    oAfiliados.documento = reader["Dociden"].ToString();
                    oAfiliados.nombre1 = reader["Nombre_a"].ToString();
                    oAfiliados.nombre2 = reader["Nombre_b"].ToString();
                    oAfiliados.sexo = reader["sexo"].ToString();
                    oAfiliados.tipoDocId = (reader["tipodoc"].ToString() == "" ? 0 : Int32.Parse(reader["tipodoc"].ToString()));
                    lista.Add(oAfiliados);

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

        // adiciona una nueva acion
        public Int32 AddAfiliado(AfiliadoEntidad oAfiliados)
        {
            int retorno = 0;
            String sQuery = string.Format("EXEC SPI_Afiliado @docIden='{0}', @tipodoc='{1}', @apellido_a='{2}', @apellido_b='{3}', @nombre_a='{4}', @nombre_b='{5}', @sexo='{6}'",
            oAfiliados.documento, oAfiliados.tipoDocumento, oAfiliados.apellido1, oAfiliados.apellido2, oAfiliados.nombre1, oAfiliados.nombre2, oAfiliados.sexo);

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery.ToString());
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

        public Int32 UpdateAfiliado(AfiliadoEntidad oAfiliados)
        {
            Int32 retorno = 0;
            StringBuilder sbAfiliados = new StringBuilder();
            {
                sbAfiliados.Append("UPDATE afiliados SET");
                sbAfiliados.Append(" Apellido_a='" + oAfiliados.apellido1 + "'");
                sbAfiliados.Append(" ,Apellido_b='" + oAfiliados.apellido2 + "'");
                sbAfiliados.Append(" ,Nombre_a='" + oAfiliados.nombre1 + "'");
                sbAfiliados.Append(" ,Nombre_b='" + oAfiliados.nombre2 + "'");
                sbAfiliados.Append(" ,sexo='" + oAfiliados.sexo + "'");
                sbAfiliados.Append(" ,tipodoc='" + oAfiliados.tipoDocId + "'");
                sbAfiliados.Append(" WHERE Dociden='" + oAfiliados.documento + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbAfiliados.ToString());

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
