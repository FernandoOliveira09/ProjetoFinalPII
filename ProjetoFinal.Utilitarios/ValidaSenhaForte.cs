using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProjetoFinal.Utilitarios
{
    public static class ValidaSenhaForte
    {
        public static bool ValidaSenha(string senha)
        {
            if (senha.Length < 6 || senha.Length > 12)
                return false;
            if (!senha.Any(c => char.IsDigit(c)))
                return false;
            if (!senha.Any(c => char.IsUpper(c)))
                return false;
            if (!senha.Any(c => char.IsLower(c)))
                return false;
            //if (!senha.Any(c => char.IsSymbol(c))) 
            //    return false;
            if (!senha.Any(c => char.IsPunctuation(c)))
            {
                if (!senha.Any(c => char.IsSymbol(c)))
                    return false;
            }
                

            return true;
        }
    }
}
