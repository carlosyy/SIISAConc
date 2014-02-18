using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_Programas
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de Programas
        public programas GetProgramas(Int32 idPrograma = 0, String programa = "", Boolean activo =false)
        {
            StringBuilder sbProgramas = new StringBuilder();
            IDataReader reader;
            programas lista = new programas();
            programasEntidad oProgramas = new programasEntidad();

            sbProgramas.Append("SELECT");
            sbProgramas.Append(" idPrograma");
            sbProgramas.Append(", programa");
            sbProgramas.Append(", idProgEquiv");
            sbProgramas.Append(", activo");            
            sbProgramas.Append(" FROM programas");


            if (idPrograma != 0)
            {
                sbProgramas.Append(" WHERE idPrograma ='" + idPrograma + "'");
            }
            else
            {
                if (programa != "")
                {
                    sbProgramas.Append(" WHERE Programa LIKE '%" + programa + "%'");
                }
                else
                {
                    if (activo == true)
                    {
                        sbProgramas.Append(" WHERE activo '" + activo + "'");
                    }
                }
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbProgramas.ToString());

                while (reader.Read())
                {
                    oProgramas = new programasEntidad();
                    oProgramas.idPrograma = Int32.Parse(reader["idPrograma"].ToString());
                    oProgramas.programa = reader["programa"].ToString();
                    oProgramas.idProgEquiv = Int32.Parse(reader["idProgEquiv"].ToString());
                    oProgramas.activo = Boolean.Parse(reader["activo"].ToString());                    
                    lista.Add(oProgramas);

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

        public programas getProgramas3ro(String nit = "")
        {
            StringBuilder sbProgramas = new StringBuilder();
            IDataReader reader;
            programas lista = new programas();
            programasEntidad oProgramas = new programasEntidad();

            sbProgramas.Append("SELECT");
            sbProgramas.Append(" idPrograma");
            sbProgramas.Append(", programa");
            sbProgramas.Append(", idProgEquiv");
            sbProgramas.Append(", activo");            
            sbProgramas.Append(" FROM programas as pr");
            sbProgramas.Append(" INNER JOIN programa3ro as p3");
            sbProgramas.Append(" ON pr.idPrograma = p3.codPrograma");

            if (nit != "")
            {
                sbProgramas.Append(" WHERE nitEntidad ='" + nit + "'");
            }            

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbProgramas.ToString());

                while (reader.Read())
                {
                    oProgramas = new programasEntidad();
                    oProgramas.idPrograma = Int32.Parse(reader["idPrograma"].ToString());
                    oProgramas.programa = reader["programa"].ToString();
                    oProgramas.idProgEquiv = Int32.Parse(reader["idProgEquiv"].ToString());
                    oProgramas.activo = Boolean.Parse(reader["activo"].ToString());                    
                    lista.Add(oProgramas);

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


        public programas getProgramaValidaVsRad(String radicado)
        {
            String sbProgramas = String.Format("EXEC SPS_ValidaProg @radicado='{0}'", radicado);
            IDataReader reader;
            programas lista = new programas();
            programasEntidad oProgramas = new programasEntidad();            

            
            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbProgramas.ToString());

                while (reader.Read())
                {
                    oProgramas = new programasEntidad();
                    oProgramas.idPrograma = Int32.Parse(reader["programa"].ToString());
                    oProgramas.programa = reader["nPrograma"].ToString();
                    oProgramas.idProgEquiv = Int32.Parse(reader["programaEquiv"].ToString());
                    oProgramas.idProgramaRad = Int32.Parse(reader["programaRad"].ToString());
                    oProgramas.programaRad = reader["nProgramaRad"].ToString();
                    oProgramas.cantIdDatosUS = Int32.Parse(reader["cantIdDatosUS"].ToString());
                    lista.Add(oProgramas);

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

        // adiciona una nueva Programas
        public Int32 AddProgramas(programasEntidad oProgramas)
        {
            Int32 retorno = 0;
            StringBuilder sbProgramas = new StringBuilder();
            {
                sbProgramas.Append("INSERT INTO programas(");                
                sbProgramas.Append(", programa");
                sbProgramas.Append(" idProgEquiv");
                sbProgramas.Append(", activo");
                sbProgramas.Append(")");
                sbProgramas.Append(" VALUES(");
                sbProgramas.Append(", '" + oProgramas.programa + "'");
                sbProgramas.Append(", '" + oProgramas.idProgEquiv + "'");
                sbProgramas.Append(", '" + oProgramas.activo + "'");
                sbProgramas.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbProgramas.ToString());

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

        public Int32 updateProgramaValidRadVsAud(String radicado, Int32 programa, Int32 programaRad, String actualizaEn)
        {
            Int32 retorno = 0;
            String sbProgramas = String.Format("EXEC SPU_ActValidaProg @radicado='{0}', @programa={1}, @programaRad={2}, @actualizaEn='{3}'", radicado, programa, programaRad, actualizaEn);
            
            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, sbProgramas.ToString());
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

        // Actualiza un registro de la tabla Programas

        public Int32 UpdateProgramas(programasEntidad oProgramas)
        {
            Int32 retorno = 0;
            StringBuilder sbProgramas = new StringBuilder();
            {
                sbProgramas.Append("UPDATE programas SET");
                sbProgramas.Append(" programa='" + oProgramas.programa + "'");
                sbProgramas.Append(" ,idProgEquiv='" + oProgramas.idProgEquiv + "'");
                sbProgramas.Append(" ,activo='" + oProgramas.activo + "'");
                sbProgramas.Append(" WHERE idPrograma='" + oProgramas.idPrograma + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbProgramas.ToString());
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
