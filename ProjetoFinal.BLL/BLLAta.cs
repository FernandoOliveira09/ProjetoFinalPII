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
    public static class BLLAta
    {
        public static void Inserir(MODAta ata)
        {
            DALAta.Inserir(ata);
        }

        public static MODAta PesquisarAta(MODAta ata, string tipoPesquisa)
        {
            return DALAta.PesquisarAta(ata, tipoPesquisa);
        }

        public static void Alterar(MODAta ata)
        {
            DALAta.Alterar(ata);
        }

        public static void Excluir(MODAta ata)
        {
            DALAta.Excluir(ata);
        }
    }
}
