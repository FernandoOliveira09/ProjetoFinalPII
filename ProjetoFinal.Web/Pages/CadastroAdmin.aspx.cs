﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web.Pages
{
    public partial class CadastroAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            Criptografia cripto = new Criptografia();

            bool teste = ValidaSenhaForte.ValidaSenha(TxtSenha.Text.Trim());

            if(teste == false)
                Response.Write("<script>alert('Senha INVÁLIDA!');</script>");

            try
            {
                usuario.Login = TxtLogin.Text.Trim();
                usuario.Nome = TxtNome.Text.Trim();
                usuario.Email = TxtEmail.Text.Trim();
                usuario.Senha = cripto.criptografia(TxtSenha.Text.Trim());
                usuario.DataCadastro = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                usuario.FkTipo = 1;
                usuario.FkStatus = 1;

                BLLUsuario.Inserir(usuario);

                Response.Write("<script>alert('Administrador cadastrado com sucesso!');</script>");

                Response.Redirect("../Pages/Principal.aspx");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Erro ao inserir!');</script>");
                throw;
            }
        }
    }
}