using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Utilitarios
{
    public static class PegaLogin
    {
        public static string loginPrincipal;
        public static int tentativasLogin = 0;
        public static int logado = 0;

        public static void AtribuiLogin(string login)
        {
            loginPrincipal = login;
        }

        public static void AtribuiStatusLogin(int status)
        {
            logado = status;
        }

        public static void AtribuiTentativas()
        {
            tentativasLogin++;
        }

        public static string RetornaLogin()
        {
            return loginPrincipal;
        }

        public static int RetornaTentativas()
        {
            return tentativasLogin;
        }

        public static int RetornaStatusLogin()
        {
            return logado;
        }
    }
}
