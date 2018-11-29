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
            DALTecnico.Inserir(tecnico);
        }

        public static void Alterar(MODTecnico tecnico)
        {
            DALTecnico.Alterar(tecnico);
        }

        public static List<MODTecnico> Pesquisar(MODTecnico tecnico, string tipoPesquisa)
        {
            return DALTecnico.Pesquisar(tecnico, tipoPesquisa);
        }

        public static MODTecnico PesquisarTecnico(MODTecnico tecnico)
        {
            return DALTecnico.PesquisarTecnico(tecnico);
        }
    }
}

