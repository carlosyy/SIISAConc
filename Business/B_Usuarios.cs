using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Usuarios
    {
        DM_Usuarios oDMUsuarios = new DM_Usuarios();
        CryptingPassword oCrypter = new CryptingPassword();

        public Usuario GetUsuarios(Int32 idUser = 0)
        {
            return oDMUsuarios.GetUsuarios(idUser: idUser);
        }

        public Usuario GetUsuarioDoc(String doc)
        {
            return oDMUsuarios.GetUsuarios(docUsuario: doc);
        }
        public Usuario GetUsuarioNick(String nick)
        {
            return oDMUsuarios.GetUsuarios(nick: nick);
        }        
        public Usuario GetUsuariosPorPerfi(Int32 id)
        {
            return oDMUsuarios.GetUsuarios(perfilId: id);
        }

        public Usuario GetUsuariosXBusq(String busqUsuario)
        {
            return oDMUsuarios.GetUsuarios(busqUsuario: busqUsuario);
        }

        public Usuario GetPerfiles()
        {
            return oDMUsuarios.GetPerfiles();
        }

        public Usuario GetPerfilID(Int32 perfilId)
        {
            return oDMUsuarios.GetPerfiles(perfilId: perfilId);
        }

        public Usuario getNicks(Int32 perfilId)
        {
            return oDMUsuarios.GetUsuarios(perfilId: perfilId);
        }

        public Int32 GetIDUsuario(String doc)
        {
            return oDMUsuarios.GetIDUsuario(doc);
        }

        public Int32 UpdateUsuarios(UsuarioEntidad oUsuario)
        {
            oCrypter.Texto = oUsuario.claveUsuario;
            oUsuario.claveUsuario = oCrypter.TextoEncript;
            return oDMUsuarios.UpdateUsuario(oUsuario);
        }

        public Int32 AddUsuario(UsuarioEntidad oUsuario)
        {
            return oDMUsuarios.AddUsuario(oUsuario);
        }
    }
}

