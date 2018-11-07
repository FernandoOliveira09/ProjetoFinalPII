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
    public partial class AlteracaoEquipamento : System.Web.UI.Page
    {
        private static int idEquipamento;
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

            MODEquipamento equipamento = new MODEquipamento();

            equipamento.IdEquipamento = Convert.ToInt32(Page.Request.QueryString["id"]);
            idEquipamento = Convert.ToInt32(Page.Request.QueryString["id"]);
            equipamento = BLLEquipamento.PesquisarEquipamento(equipamento, "id");

            if (!Page.IsPostBack)
            {
                TxtNome.Text = equipamento.Nome;
                TxtDescricao.Text = equipamento.Descricao;

            }
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODEquipamento equipamento = new MODEquipamento();
            try
            {
                if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 100)
                {
                    LblResposta.Text = Erros.NomeVazio;
                }
                else if (TxtDescricao.Text.Trim() == "")
                {
                    LblResposta.Text = Erros.DescricaoVazio;
                }


                equipamento.IdEquipamento = idEquipamento;
                equipamento.Nome = TxtNome.Text.Trim();
                equipamento.Descricao = TxtDescricao.Text.Trim();


                BLLEquipamento.Alterar(equipamento);

                LblResposta.Text = "Equipamento alterado com sucesso!";

            }

            catch (Exception)
            {
                Response.Write("<script>alert('Erro ao inserir!');</script>");
                throw;
            }
        }
    }
}
