using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;

namespace ProjetoFinal.BLL
{
    public static class BLLLogin
    {
        public static void Inserir(MODLogin login)
        {
            DALLogin.Inserir(login);
        }

        public static MODLogin Pesquisar(MODLogin login)
        {
            return DALLogin.Pesquisar(login);
        }
    }
}
