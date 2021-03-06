﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web.Pages
{
    public partial class AlteracaoGrupo : System.Web.UI.Page
    {
        private int idGrupo;
        private string logo;
        private string status;
        private static string nome;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../Pages/Login.aspx");
            }

            MODUsuario usuario = new MODUsuario();
            usuario.Login = PegaLogin.RetornaLogin();
            usuario = BLLUsuario.PesquisarLogin(usuario);

            ImagemUser.ImageUrl = "../Pages/" + usuario.Imagem;
            ImagemUser2.ImageUrl = "../Pages/" + usuario.Imagem;
            LblNome.Text = usuario.Nome;

            if (usuario.FkTipo == 1)
                LblFuncao.Text = "Administrador";
            else
                LblFuncao.Text = "Lider de Pesquisa";

            MODGrupo grupo = new MODGrupo();

            grupo.Nome = Page.Request.QueryString["grupo"];
            nome = grupo.Nome;

            grupo = BLLGrupo.PesquisarGrupo(grupo, "nome");
            idGrupo = grupo.IdGrupo;

            if (!Page.IsPostBack)
            {    
                TxtNome.Text = grupo.Nome;
                TxtSigla.Text = grupo.Sigla;
                TxtEmail2.Text = grupo.Email;
                TxtDescricao.Text = grupo.Descricao;
                TxtLattes.Text = grupo.Lattes;
                TxtData.Text = grupo.DataInicio.ToString();
                TxtLogo.Text = grupo.Logotipo;

                if (grupo.FkSituacao == 1)
                {
                    TxtStatus.Text = "Ativo";
                    status = "Ativo";
                } 
                else if (grupo.FkSituacao == 2)
                {
                    TxtStatus.Text = "Inativo";
                    status = "Inativo";
                }
                else
                {
                    TxtStatus.Text = "Aguardando Lider";
                    status = "Aguardando Lider";
                }
                    
            }

            TxtLogo.Visible = false;
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODGrupo grupo = new MODGrupo();
            string extensao = Path.GetExtension(FUFoto.FileName);

            grupo.Nome = TxtNome.Text.Trim();

            if (TxtLattes.Text.Trim() == "")
            {
                LblResposta.Text = Erros.LattesVazio;
            }
            else if (TxtDescricao.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DescricaoVazio;
            }
            else if (extensao != ".jpg" && extensao != ".jpeg" && extensao != ".png" && extensao != ".bmp")
            {
                LblResposta.Text = "Arquivo de foto inválido, utilize fotos nas seguintes extensões: .jpg/.jpeg/.png/.bmp";
            }
            else
            {
                try
                {
                    if(FUFoto.FileName == "")
                    {
                        if (TxtLogo.Text == "")
                        {
                            LblResposta.Text = Erros.FotoVazio;
                        }
                        else
                        {
                            grupo.Logotipo = TxtLogo.Text.Trim();
                        }
                    }
                    else
                    {
                        string foto = "Imagens/" + grupo.Nome + extensao;
                        if (File.Exists(Server.MapPath(foto)))
                            File.Delete(Server.MapPath(foto));

                        this.FUFoto.SaveAs(Server.MapPath("Imagens/" + FUFoto.FileName));
                        System.IO.File.Move(Server.MapPath("Imagens/" + FUFoto.FileName), Server.MapPath("Imagens/" + grupo.Nome + extensao));

                        grupo.Logotipo = foto;
                    }   
                    grupo.IdGrupo = idGrupo;
                    grupo.Lattes = TxtLattes.Text.Trim();
                    grupo.Sigla = TxtSigla.Text.Trim();
                    grupo.Email = TxtEmail2.Text.Trim();
                    grupo.Descricao = TxtDescricao.Text.Trim();
                    grupo.DataInicio = Convert.ToDateTime(TxtData.Text.Trim());

                    BLLGrupo.AlterarGrupo(grupo, "todos");

                    if (status != TxtStatus.SelectedValue)
                    {
                        if (TxtStatus.SelectedValue == "Ativo")
                            grupo.FkSituacao = 1;
                        else if (TxtStatus.SelectedValue == "Inativo")
                            grupo.FkSituacao = 2;
                        else
                            grupo.FkSituacao = 3;

                        BLLGrupo.AlterarGrupo(grupo, "status");
                    }

                    LblResposta.Text = "Grupo alterado com sucesso!";
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
            }
        }
    }
}