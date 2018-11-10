using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.BLL
{
    public static class BLLPublicacao
    {
        public static void Inserir(MODPublicacao publicacao)
        {
            DALPublicacao.Inserir(publicacao);
        }
    }
}
