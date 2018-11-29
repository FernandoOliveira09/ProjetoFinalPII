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
    public partial class AlteracaoAreaAvaliacao : System.Web.UI.Page
    {
        public string idArea, conhecimento;
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

            CarregaAreaConhecimento();
            MODArea_Conhecimento areaConhecimento = new MODArea_Conhecimento();
            MODArea_Avaliacao areaAvaliacao = new MODArea_Avaliacao();

            areaAvaliacao.Id = Page.Request.QueryString["id"];

            areaAvaliacao = BLLLinha_Pesquisa.PesquisarAvaliacao(areaAvaliacao);
            idArea = areaAvaliacao.Id;
            conhecimento = areaAvaliacao.FkCon;

            areaConhecimento.Id = conhecimento;
            areaConhecimento = BLLLinha_Pesquisa.PesquisarConhecimento(areaConhecimento);

            if (!Page.IsPostBack)
            {
                TxtIdAva.Text = areaAvaliacao.Id;
                TxtAreaAvaliacao.Text = areaAvaliacao.Nome;
                TxtConhecimento.Text = areaConhecimento.Nome;
            }
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODArea_Avaliacao area = new MODArea_Avaliacao();

            area.Id = TxtIdAva.Text.Trim();
            area.Nome = TxtAreaAvaliacao.Text.Trim().ToUpper();
            
            if(TxtSelecao.Checked == true)
            {
                TxtAreaConhecimento.Enabled = true;
                area.FkCon = TxtAreaConhecimento.SelectedValue.ToString();
            }
            else
            {
                area.FkCon = conhecimento;
            }

            if (TxtIdAva.Text.Trim() == "" || TxtIdAva.Text.Length > 10)
            {
                LblResposta.Text = Erros.CodigoVazio;
            }
            else if (TxtIdAva.Text.Length < 8)
            {
                LblResposta.Text = "O código deve ter ao menos 8 caracteres";
            }
            else if (TxtAreaAvaliacao.Text.Trim() == "" || TxtAreaAvaliacao.Text.Length > 80)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else
            {
                try
                {
                    BLLLinha_Pesquisa.AlterarAreaAvaliacao(area, idArea);

                    LblResposta.Text = "Area de avaliação alterada com sucesso!";
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
            }
        }

        protected void TxtSelecao_CheckedChanged(object sender, EventArgs e)
        {
            if (TxtSelecao.Checked == true)
            {
                TxtAreaConhecimento.Enabled = true;
                
            }
            else
            {
                TxtAreaConhecimento.Enabled = false;
            }
                
        }

        private void CarregaAreaConhecimento()
        {
            MODArea_Conhecimento areaConhecimento = new MODArea_Conhecimento();

            TxtAreaConhecimento.DataSource = BLLLinha_Pesquisa.PesquisarAreaConhecimento(areaConhecimento, "todas");
            TxtAreaConhecimento.DataValueField = "Id";
            TxtAreaConhecimento.DataTextField = "Nome";
            TxtAreaConhecimento.DataBind();
        }
    }
}