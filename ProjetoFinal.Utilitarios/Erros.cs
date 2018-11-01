using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Utilitarios
{
    public static class Erros
    {
        public static string SenhaFraca = "Sua senha deve ter pelo menos: 1 letra maiúscula, 1 letra minúscula, 1 numero e 1 caractere especial";
        public static string EmailVazio = "O campo EMAIL é inválido!";
        public static string NomeVazio = "O campo NOME é inválido!";
        public static string LoginVazio = "O campo LOGIN é inválido!";
        public static string SenhaVazio = "O campo SENHA é inválido!";
        public static string Senha2Vazio = "O campo REDIGITE SUA SENHA é inválido!";
        public static string SenhaInvalida = "Os campos de senha não coincidem!";
        public static string LattesVazio = "O campo LATTES é inválido!";
        public static string FotoVazio = "O campo FOTO é inválido!";
        public static string SiglaVazio = "O campo SIGLA é inválido!";
        public static string DataVazio = "O campo DATA é inválido!";
        public static string DescricaoVazio = "O campo DESCRIÇÃO é inválido!";
        public static string GrupoExistente = "Já existe um grupo com esse nome!";
        public static string SiglaExistente = "Já existe um grupo com essa sigla!";
        public static string LinhaExistente = "Já existe uma linha de pesquisa com esse nome ou código!";
        public static string CodigoVazio = "O campo CÓDIGO é inválido!";
        public static string AreaConExiste = "Já existe uma area do conhecimento com esse nome ou código!";
        public static string AreaAvaExiste = "Já existe uma area de avaliação com esse nome ou código!";
        public static string AtividadeVazia = "O campo ATIVIDADE é inválido!";
        public static string CursoVazio = "O campo CURSO é inválido!";
        public static string FormacaoVazia = "O campo FORMAÇÃO é inválido!";
        public static string TituloVazio = "O campo TÍTULO é inválido!";
        public static string AnoConclusaoVazio = "O campo ANO DE CONCLUSÃO é inválido!";
    }
}
