using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_Usuarios
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de Usuarios
        public Usuario GetUsuarios(Int32 perfilId = 0, String docUsuario = "", Int32 idUser = 0, String busqUsuario = "", String nick = "")
        {
            StringBuilder sbLogin = new StringBuilder();
            IDataReader reader;
            Usuario lista = new Usuario();
            UsuarioEntidad oUsuario = new UsuarioEntidad();

            sbLogin.Append("SELECT");
            sbLogin.Append(" a.idUser");
            sbLogin.Append(", a.docUsuario");
            sbLogin.Append(", a.trataUsuario");
            sbLogin.Append(", a.nombreUsuario");
            sbLogin.Append(", a.idPerfil");
            sbLogin.Append(", a.sucursal");
            sbLogin.Append(", a.email");
            sbLogin.Append(", a.rutaGuarda");
            sbLogin.Append(", b.perfil");
            sbLogin.Append(", c.nick");
						sbLogin.Append(", a.activo");
            sbLogin.Append(" FROM usuarios AS a INNER JOIN");
            sbLogin.Append(" perfil AS b ON a.idPerfil = b.idPerfil INNER JOIN");
            sbLogin.Append(" login AS c ON a.idUser = c.idUser");

            if (perfilId != 0)
            {
                sbLogin.Append(" WHERE A.idPerfil = '" + perfilId + "'");
            }
            if (docUsuario != "")
            {
                sbLogin.Append(" WHERE docUsuario ='" + docUsuario + "'");
            }

            if (nick != "")
            {
                sbLogin.Append(" WHERE c.nick ='" + nick + "'");
            }

            if (idUser != 0)
            {
                sbLogin.Append(" WHERE A.idUser ='" + idUser + "'");
            }

            if (busqUsuario != "")
            {
                sbLogin.Append(" WHERE (a.docUsuario + a.nombreUsuario + a.sucursal + a.email + b.perfil + c.nick) LIKE '%" + busqUsuario + "%'");
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbLogin.ToString());

                while (reader.Read())
                {
                    oUsuario = new UsuarioEntidad();
                    oUsuario.UsuarioID = Int32.Parse(reader["idUser"].ToString());
                    oUsuario.Documento = reader["docUsuario"].ToString();
                    oUsuario.Tratamiento = Int32.Parse(reader["trataUsuario"].ToString());
                    oUsuario.Nombre = reader["nombreUsuario"].ToString();
                    oUsuario.PerfilID = Int32.Parse(reader["idPerfil"].ToString());
                    oUsuario.Sucursal = reader["sucursal"].ToString();
                    oUsuario.Email = reader["email"].ToString();
                    oUsuario.Ruta = reader["rutaGuarda"].ToString();
                    oUsuario.Perfil = reader["perfil"].ToString();
                    oUsuario.Nick = reader["nick"].ToString();
										oUsuario.Activo = Boolean.Parse(reader["activo"].ToString());
                    lista.Add(oUsuario);

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

        public Int32 GetIDUsuario(String doc)
        {
            StringBuilder sbNick = new StringBuilder();
            IDataReader reader;
            Int32 id = 0;

            sbNick.Append("SELECT");
            sbNick.Append(" idUser");
            sbNick.Append(" FROM Usuarios");
            sbNick.Append(" WHERE docUsuario = '" + doc + "'");

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbNick.ToString());

                while (reader.Read())
                {
                    id = Int32.Parse(reader["idUser"].ToString());
                }
                reader.Close();

                return id;
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

        // adiciona una nueva Usuarios
        public Int32 AddUsuario(UsuarioEntidad oUsuario)
        {
            Int32 retorno = 0;            
            {
                oDataAccess.addInParameters("@docUsuario", DbType.String, oUsuario.Documento);
                oDataAccess.addInParameters("@trataUsuario", DbType.Int32, oUsuario.Tratamiento);
                oDataAccess.addInParameters("@nombreUsuario", DbType.String, oUsuario.Nombre);
                oDataAccess.addInParameters("@idPerfil", DbType.Int32, oUsuario.PerfilID);                
                oDataAccess.addInParameters("@sucursal", DbType.String, oUsuario.Sucursal);
                oDataAccess.addInParameters("@email", DbType.String, oUsuario.Email);
                oDataAccess.addInParameters("@activo", DbType.Boolean, oUsuario.Activo);                
                oDataAccess.addInParameters("@nick", DbType.String, oUsuario.Nick);
                oDataAccess.addInParameters("@claveUsuario", DbType.String, oUsuario.claveUsuario);

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPI_UsuarioApp");                    

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

        // Actualiza un registro de la tabla Usuario
        public Int32 UpdateUsuario(UsuarioEntidad oUsuario)
        {
            Int32 retorno = 0;
            StringBuilder sbUsuarios = new StringBuilder();
            {
                sbUsuarios.Append("UPDATE usuarios SET");
                sbUsuarios.Append(" docUsuario='" + oUsuario.Documento + "'");
                sbUsuarios.Append(", trataUsuario='" + oUsuario.Tratamiento + "'");
                sbUsuarios.Append(", nombreUsuario='" + oUsuario.Nombre + "'");
                sbUsuarios.Append(", idPerfil='" + oUsuario.PerfilID + "'");
                sbUsuarios.Append(", sucursal='" + oUsuario.Sucursal + "'");
                sbUsuarios.Append(", email='" + oUsuario.Email + "'");
                sbUsuarios.Append(", activo='" + oUsuario.Activo + "'");
                sbUsuarios.Append(", rutaGuarda='" + oUsuario.Ruta + "'");
                sbUsuarios.Append(" WHERE idUser='" + oUsuario.UsuarioID + "'");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbUsuarios.ToString());
                    sbUsuarios.Clear();
                    sbUsuarios.Append("UPDATE login SET nick='" + oUsuario.Nick + "', claveUsuario='" + oUsuario.claveUsuario + "' WHERE idUser='" + oUsuario.UsuarioID + "'");
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbUsuarios.ToString());
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

        public Usuario GetPerfiles(Int32 perfilId = 0)
        {
            StringBuilder sbLogin = new StringBuilder();
            IDataReader reader;
            Usuario lista = new Usuario();
            UsuarioEntidad oUsuario = new UsuarioEntidad();

            sbLogin.Append("SELECT");
            sbLogin.Append(" idPerfil");
            sbLogin.Append(", perfil");
            sbLogin.Append(" FROM perfil");


            if (perfilId != 0)
            {
                sbLogin.Append(" WHERE idUser = '" + perfilId + "'");
            }

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbLogin.ToString());

                while (reader.Read())
                {
                    oUsuario = new UsuarioEntidad();
                    oUsuario.PerfilID = Int32.Parse(reader["idPerfil"].ToString());
                    oUsuario.Perfil = reader["perfil"].ToString();
                    lista.Add(oUsuario);

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
    }
}
