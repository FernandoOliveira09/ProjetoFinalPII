using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Utilitarios
{
    public static class GeradorSenhaAleatoria
    {
        public static string GeraSenha()
        {
            // Gera uma senha com 6 caracteres entre numeros e letras
            string minusculos = "abcdefghjkmnpqrstuvwxyz";
            string maiusculos = "ABCDEFGHJKMNPQRSTUVWXYZ";
            string especiais = "@#$%&*!";
            string numeros = "0123456789";
            string senha = "";
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                if (i == 0 || i == 4)
                    senha = senha + minusculos.Substring(random.Next(0, minusculos.Length - 1), 1);
                if (i == 1 || i == 5)
                    senha = senha + maiusculos.Substring(random.Next(0, maiusculos.Length - 1), 1);
                if (i == 2)
                    senha = senha + numeros.Substring(random.Next(0, numeros.Length - 1), 1);
                if(i == 3)
                    senha = senha + especiais.Substring(random.Next(0, especiais.Length - 1), 1);
            }

            return senha;
        }
    }
}
