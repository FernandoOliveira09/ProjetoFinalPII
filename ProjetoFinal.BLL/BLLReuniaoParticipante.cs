using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;
using ProjetoFinal.Utilitarios;
using System.Data;


namespace ProjetoFinal.BLL
{
    public static class BLLReuniaoParticipante
    {
        public static void Inserir(MODReuniaoParticipante reuniaoParticipante)
        {
            DALReuniaoParticipante.Inserir(reuniaoParticipante);
        }

        public static void Excluir(MODReuniaoParticipante reuniaoParticipante)
        {
            DALReuniaoParticipante.Excluir(reuniaoParticipante);
        }

        public static List<MODDocente> PesquisarDocente(MODReuniaoParticipante item, string tipoPesquisa)
        {
            return DALReuniaoParticipante.PesquisarDocente(item, tipoPesquisa);
        }
    }
}
