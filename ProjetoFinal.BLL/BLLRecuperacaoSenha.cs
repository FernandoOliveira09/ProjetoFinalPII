using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;

namespace ProjetoFinal.BLL
{
    public class BLLRecuperacaoSenha
    {
        public static void Inserir(MODRecuperaSenha recuperaSenha)
        {
            DALRecuperacaoSenha.Inserir(recuperaSenha);
        }

        public static int recuperaId()
        {
            return DALRecuperacaoSenha.recuperaId();
        }

        public static string PesquisaRecuperacao(MODRecuperaSenha recuperaSenha, MODUsuario usuario)
        {
            return DALRecuperacaoSenha.PesquisaRecuperacao(recuperaSenha, usuario);
        }

        public static void AlterarStatus(MODRecuperaSenha recuperaSenha)
        {
            DALRecuperacaoSenha.AlterarStatus(recuperaSenha);
        }

        public static char RecuperaStatus(MODRecuperaSenha recuperaSenha)
        {
            return DALRecuperacaoSenha.RecuperaStatus(recuperaSenha);
        }
    }
}
