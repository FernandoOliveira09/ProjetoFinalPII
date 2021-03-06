﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODUsuario
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Lattes { get; set; }
        public string Imagem { get; set; }
        public char PrimeiroAcesso { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? FkTipo { get; set; }
        public int? FkStatus { get; set; }

        //apenas para consulta
        public string Tipo { get; set; }
        public string Status { get; set; }
    }
}
