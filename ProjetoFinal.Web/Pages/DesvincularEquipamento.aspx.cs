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
    public partial class DesvincularEquipamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../Pages/Login.aspx");
            }

            MODUsuario usuario2 = new MODUsuario();
            usuario2.Login = PegaLogin.RetornaLogin();
            usuario2 = BLLUsuario.PesquisarLogin(usuario2);

            ImagemUser.ImageUrl = "../Pages/" + usuario2.Imagem;
            ImagemUser2.ImageUrl = "../Pages/" + usuario2.Imagem;
            LblNome.Text = usuario2.Nome;

            if (usuario2.FkTipo == 1)
                LblFuncao.Text = "Administrador";
            else
                LblFuncao.Text = "Lider de Pesquisa";

            if (!Page.IsPostBack)
            {
                MODGrupo_Equipamento grupoEquipamento = new MODGrupo_Equipamento();
                MODEquipamento equipamento = new MODEquipamento();
                grupoEquipamento.FkEquipamento = Convert.ToInt32(Page.Request.QueryString["equipamento"]);
                TxtGrupo.DataSource = BLLEquipamento.PesquisarGrupo(grupoEquipamento, "equipamento");
                TxtGrupo.DataValueField = "Id_grupo";
                TxtGrupo.DataTextField = "Nome";
                TxtGrupo.DataBind();

                equipamento.IdEquipamento = grupoEquipamento.FkEquipamento;
                equipamento = BLLEquipamento.PesquisarEquipamento(equipamento, "id");

                TxtNome.Text = equipamento.Nome;
            }
        }

        protected void Desvincular_Click(object sender, EventArgs e)
        {
            MODGrupo_Equipamento grupoEquipamento = new MODGrupo_Equipamento();

            if (TxtDataTermino.Text.Trim() == "")
            {
                LblResposta.Text = "A data de término nao pode ser nula!";
            }
            else
            {
                grupoEquipamento.FkEquipamento = Convert.ToInt32(Page.Request.QueryString["equipamento"]);
                grupoEquipamento.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                grupoEquipamento.DataFim = Convert.ToDateTime(TxtDataTermino.Text.Trim());

                BLLEquipamento.AlterarDataSaidaEquipamento(grupoEquipamento);

                LblResposta.Text = "Equipamento desvinculado com sucesso!";
            }
        }
    }
}