using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;
using System.Data;

namespace ProjetoFinal.BLL
{
    public static class BLLDocente_Linha_Pesquisa
    {
        public static void Inserir(MODDocente_Linha_Pesquisa DocenteLinha)
        {
            DALDocente_Linha_Pesquisa.Inserir(DocenteLinha);
        }

        public static DataTable Pesquisar(MODGrupoDocente grupoDocente, string tipoPesquisa)
        {
            return DALDocente_Linha_Pesquisa.Pesquisar(grupoDocente, tipoPesquisa);
        }
    }
}
