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
    public static class BLLDocente
    {
        public static void InserirDocente(MODDocente docente)
        { 
            DALDocente.InserirDocente(docente);
        }

        public static void Alterar(MODDocente docente)
        {
            DALDocente.Alterar(docente);
        }

        public static MODDocente PesquisarDocente(MODDocente docente, string tipoPesquisa)
        {
            return DALDocente.PesquisarDocente(docente, tipoPesquisa);
        }

        public static List<MODDocente> Pesquisar(MODDocente docente, string tipoPesquisa)
        {
            return DALDocente.Pesquisar(docente, tipoPesquisa);
        }
    }
}
