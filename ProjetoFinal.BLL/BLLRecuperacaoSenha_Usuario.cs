using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;


namespace ProjetoFinal.BLL
{
    public class BLLRecuperacaoSenha_Usuario
    {
        public static void Inserir(MODRecuperacaoSenha_Usuario recuperacaoSenha_Usuario)
        {
            DALRecuperacaoSenha_Usuario.Inserir(recuperacaoSenha_Usuario);
        }
    }
}
