using System;
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
    public partial class AlteracaoGrupo : System.Web.UI.Page
    {
        private int idGrupo;

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

            grupo = BLLGrupo.PesquisarGrupo(grupo);
            idGrupo = grupo.IdGrupo;
            TxtNome.Text = grupo.Nome;
            TxtSigla.Text = grupo.Sigla;
            TxtEmail.Text = grupo.Email;
            TxtDescricao.Text = grupo.Descricao;
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODGrupo grupo = new MODGrupo();

            if (!FUFoto.HasFile)
            {
                LblResposta.Text = Erros.FotoVazio;
            }
            else if (TxtLattes.Text.Trim() == "")
            {
                LblResposta.Text = Erros.LattesVazio;
            }
            //else if (TxtDescricao.Text.Trim() == "")
            //{
            //    LblResposta.Text = Erros.DescricaoVazio;
            //}
            else
            {
                try
                {
                    this.FUFoto.SaveAs(Server.MapPath("Imagens/" + FUFoto.FileName));
                    grupo.Logotipo = "Imagens/" + FUFoto.FileName;
                    grupo.IdGrupo = idGrupo;
                    grupo.Nome = TxtNome.Text.Trim();
                    grupo.Lattes = TxtLattes.Text.Trim();
                    grupo.Sigla = TxtSigla.Text.Trim();
                    grupo.Email = TxtEmail.Text.Trim();
                    grupo.Descricao = TxtDescricao.Text.Trim();
                    grupo.DataInicio = Convert.ToDateTime(TxtData.Text.Trim());

                    BLLGrupo.AlterarGrupo(grupo, "todos");

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