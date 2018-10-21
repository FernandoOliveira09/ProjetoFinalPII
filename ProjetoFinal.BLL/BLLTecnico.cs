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
    public static class BLLTecnico
    {
        public static void Inserir(MODTecnico tecnico)
        {
            if (tecnico.Nome.Trim() == "" || tecnico.Nome.Length > 50)
                throw new ExcecaoPersonalizada(Erros.NomeVazio);
            if (tecnico.Lattes.Trim() == "" || tecnico.Lattes.Length > 50)
                throw new ExcecaoPersonalizada(Erros.LattesVazio);
            if (tecnico.Atividade.Trim() == "" || tecnico.Atividade.Length > 15)
                throw new ExcecaoPersonalizada(Erros.AtividadeVazia);
            if (tecnico.Curso.Trim() == "")
                throw new ExcecaoPersonalizada(Erros.CursoVazio);
            if (tecnico.Formacao.Trim() == "")
                throw new ExcecaoPersonalizada(Erros.FormacaoVazia);
            if (tecnico.AnoConclusao.ToString().Trim() == "")
                throw new ExcecaoPersonalizada(Erros.AnoConclusaoVazio);
            if (tecnico.Foto.Trim() == "")
                throw new ExcecaoPersonalizada(Erros.FotoVazio);

            DALTecnico.Inserir(tecnico);
        }

        public static void Alterar(MODTecnico tecnico)
        {
            DALTecnico.Alterar(tecnico);
        }

        /*public static void AlterarStatus(MODUsuario usuario)
        {
            DALUsuario.AlterarStatus(usuario);
        }
        *
        public static void AlterarSenha(MODUsuario usuario)
        {
            DALUsuario.AlterarSenha(usuario);
        }
        */

        public static List<MODTecnico> Pesquisar(MODTecnico tecnico, string tipoPesquisa)
        {
            return DALTecnico.Pesquisar(tecnico, tipoPesquisa);
        }


        public static MODTecnico PesquisarTecnico(MODTecnico tecnico)
        {
            return DALTecnico.PesquisarTecnico(tecnico);
        }

        /* public static List<MODTecnico> PesquisarAdmin()
         {
             return DALUsuario.PesquisarAdmin();
         }*/
    }

}

