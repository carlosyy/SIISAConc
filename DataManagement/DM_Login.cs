using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_Login
    {
        SQLConn oDataAccess = new SQLConn();

        // selecciona todos los atributos de Login
        public Login GetLogin(Int32 idUser = 0)
        {
            StringBuilder sbLogin = new StringBuilder();
            IDataReader reader;
            Login lista = new Login();
            LoginEntidad oLogin = new LoginEntidad();

            sbLogin.Append("SELECT");
            sbLogin.Append(" idUser");
            sbLogin.Append(", claveUsuario");
            sbLogin.Append(", nick");
            sbLogin.Append(", activo");            
            sbLogin.Append(" FROM Login");

            if (idUser != 0)
            {
                sbLogin.Append(" WHERE idUser '" + idUser + "'");
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbLogin.ToString());

                while (reader.Read())
                {
                    oLogin = new LoginEntidad();
                    oLogin.idUser = Int32.Parse(reader["idUser"].ToString());
                    oLogin.claveUsuario = reader["claveUsuario"].ToString();
                    oLogin.nick = reader["nick"].ToString();
                    oLogin.activo = Boolean.Parse(reader["activo"].ToString());                  
                    lista.Add(oLogin);

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

        // adiciona una nueva Login
        public Int32 AddLogin(LoginEntidad oLogin)
        {
            Int32 retorno = 0;
            StringBuilder sbLogin = new StringBuilder();
            {
                sbLogin.Append("INSERT INTO login(");
                sbLogin.Append(" idUser");
                sbLogin.Append(", claveUsuario");
                sbLogin.Append(", nick");
                sbLogin.Append(", activo");
                sbLogin.Append(")");
                sbLogin.Append(" VALUES(");
                sbLogin.Append("'" + oLogin.idUser + "'");
                sbLogin.Append(", '" + oLogin.claveUsuario + "'");
                sbLogin.Append(", '" + oLogin.nick + "'");
                sbLogin.Append(", '" + oLogin.activo + "'");
                sbLogin.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbLogin.ToString());

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

        // Actualiza un registro de la tabla Login
        public Int32 UpdateLogin(LoginEntidad oLogin)
        {
            Int32 retorno = 0;
            StringBuilder sbLogin = new StringBuilder();
            {
                sbLogin.Append("UPDATE login SET");
                sbLogin.Append(" idUser='" + oLogin.idUser + "'");
                sbLogin.Append(" ,claveUsuario='" + oLogin.claveUsuario + "'");
                sbLogin.Append(" ,nick='" + oLogin.nick + "'");
                sbLogin.Append(" ,activo='" + oLogin.activo + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbLogin.ToString());
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

        public Int32 LoguinUsuario(String nick, String pass)
        {
            StringBuilder sbLogin = new StringBuilder();
            IDataReader reader;
            Int32 id = 0;

            sbLogin.Append("SELECT");
            sbLogin.Append(" idUser");
            sbLogin.Append(" FROM Login");
            sbLogin.Append(" WHERE claveUsuario = '" + pass + "'");
            sbLogin.Append(" AND nick = '" + nick + "'");




            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbLogin.ToString());

                while (reader.Read())
                {
                    id = Int32.Parse(reader["idUser"].ToString());
                }
                reader.Close();

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDataAccess.close();
            }
        }
    }
}
