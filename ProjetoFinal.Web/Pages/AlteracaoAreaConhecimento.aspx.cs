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
    public partial class AlteracaoAreaConhecimento : System.Web.UI.Page
    {
        private string idArea;

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

            MODArea_Conhecimento areaConhecimento = new MODArea_Conhecimento();

            areaConhecimento.Id = Page.Request.QueryString["id"];

            areaConhecimento = BLLLinha_Pesquisa.PesquisarConhecimento(areaConhecimento);
            idArea = areaConhecimento.Id;

            if (!Page.IsPostBack)
            {
                TxtIdArea.Text = areaConhecimento.Id;
                TxtIdArea.ReadOnly = true;
                TxtAreaConhecimento.Text = areaConhecimento.Nome;
            }
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODArea_Conhecimento area = new MODArea_Conhecimento();

            area.Id = TxtIdArea.Text.Trim();
            area.Nome = TxtAreaConhecimento.Text.Trim().ToUpper();

            if (TxtIdArea.Text.Trim() == "" || TxtIdArea.Text.Length > 10)
            {
                LblResposta.Text = Erros.CodigoVazio;
            }
            else if (TxtAreaConhecimento.Text.Trim() == "" || TxtAreaConhecimento.Text.Length > 80)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else
            {
                try
                {
                    BLLLinha_Pesquisa.AlterarAreaConhecimento(area, idArea);

                    LblResposta.Text = "Area do conhecimento alterada com sucesso!";
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