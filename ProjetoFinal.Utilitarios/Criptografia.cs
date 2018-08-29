using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProjetoFinal.Utilitarios
{
    public class Criptografia
    {
        public string criptografia(string senha)
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = ue.GetBytes(senha);
            SHA256Managed shHash = new SHA256Managed();
            string strHex = "";
            HashValue = shHash.ComputeHash(MessageBytes);

            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }

            return strHex;
        }
    }
}
