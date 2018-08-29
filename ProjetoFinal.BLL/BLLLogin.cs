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
        public static void Inserir(MODUsuario login)
        {
            DALUsuario.Inserir(login);
        }

        public static MODUsuario Pesquisar(MODUsuario login)
        {
            return DALUsuario.Pesquisar(login);
        }
    }
}
