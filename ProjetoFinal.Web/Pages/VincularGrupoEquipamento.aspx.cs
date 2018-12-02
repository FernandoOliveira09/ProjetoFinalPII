using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web
{
    public partial class VincularProjetoEquipamento : System.Web.UI.Page
    {
        private static int idGrupo, idEquipamento;

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

            if (!IsPostBack)
            {
                CarregaGrupo();
                CarregaEquipamento();
            }
        }

        protected void BtnVincularEquipamento_Click(object sender, EventArgs e)
        {
            MODGrupo_Equipamento grupoEquipamento = new MODGrupo_Equipamento();

            if (TxtData.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                grupoEquipamento.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                grupoEquipamento.FkEquipamento = Convert.ToInt32(TxtEquipamento.SelectedValue);
                grupoEquipamento.DataInicio = Convert.ToDateTime(TxtData.Text.Trim());

                BLLEquipamento.InserirEquipamentoGrupo(grupoEquipamento);

                LblResposta.Text = "Equipamento vinculado com sucesso!";
            }
        }

        private void CarregaGrupo()
        {
            MODGrupo grupo = new MODGrupo();

            TxtGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
            TxtGrupo.DataValueField = "IdGrupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }

        private void CarregaEquipamento()
        {
            MODEquipamento equipamento = new MODEquipamento();

            TxtEquipamento.DataSource = BLLEquipamento.Pesquisar(equipamento, "todos");
            TxtEquipamento.DataValueField = "IdEquipamento";
            TxtEquipamento.DataTextField = "Nome";
            TxtEquipamento.DataBind();
        }
    }
}