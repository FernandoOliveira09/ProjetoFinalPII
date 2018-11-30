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
    public static class BLLReuniaoConvidado
    {
        public static void Inserir(MODReuniaoConvidado reuniaoConvidado)
        {
            DALReuniaoConvidado.Inserir(reuniaoConvidado);
        }
    }
}
