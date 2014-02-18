using System;
using Entities;
using DataManagement;

namespace Business
{
    public class B_Login
    {
        DM_Login oDMLogin = new DM_Login();
        CryptingPassword oCrypter = new CryptingPassword();

        public login getLogin()
        {
            return oDMLogin.GetLogin();
        }

        public login getLoginIdUser(Int32 idUser)
        {
            return oDMLogin.GetLogin(idUser: idUser);
        }

        public Int32 AddLogin(loginEntidad oLogin)
        {
            oCrypter.Texto = oLogin.claveUsuario;
            oLogin.claveUsuario = oCrypter.TextoEncript;

            return oDMLogin.AddLogin(oLogin);
        }

        public Int32 UpdateLogin(loginEntidad oLogin)
        {
            oCrypter.Texto = oLogin.claveUsuario;
            oLogin.claveUsuario = oCrypter.TextoEncript;

            return oDMLogin.UpdateLogin(oLogin);
        }

        public Int32 LoguinUsuario(String nick, String pass)
        {
            oCrypter.Texto = pass;
            return oDMLogin.LoguinUsuario(nick, oCrypter.TextoEncript);
        }        
    }
}
