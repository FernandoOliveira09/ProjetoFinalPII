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
    public partial class CadastroConvidado : System.Web.UI.Page
    {
        static int idReuniao;
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

            if (!Page.IsPostBack)
            {

                MODReuniao reuniao = new MODReuniao();
                reuniao.IdReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                reuniao = BLLReuniao.PesquisarReuniao(reuniao, "id_reuniao");
                idReuniao = reuniao.IdReuniao;
                TxtPauta.Text = reuniao.Pauta;

                MODReuniaoConvidado reuniaoConvidado = new MODReuniaoConvidado();
                reuniaoConvidado.FkReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);

                List<MODReuniaoConvidado> convidado = new List<MODReuniaoConvidado>();

                convidado = BLLReuniaoConvidado.Pesquisar(reuniaoConvidado, "reuniao");

                if (convidado.Count != 0)
                {
                    if (reuniao.HoraFim.ToString() == "01/01/0001 00:00:00")
                    {
                        RptExcluir.DataSource = convidado;
                        RptExcluir.DataBind();
                    }       
                }

                if (reuniao.HoraFim.ToString() != "01/01/0001 00:00:00")
                {
                    LblResposta.Text = "Não é possivel editar os convidados, pois a reunião já foi encerrada!";
                    BtnCadastrar.Visible = false;
                }
            }
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODReuniaoConvidado reuniaoConvidado = new MODReuniaoConvidado();

            if (TxtConvidado.Text == "")
            {
                LblResposta.Text = "O campo Nome é obrigatório";
            }
            else
            {
                reuniaoConvidado.FkReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                reuniaoConvidado.Nome = TxtConvidado.Text.Trim();

                BLLReuniaoConvidado.Inserir(reuniaoConvidado);
                LblResposta.Text = "Convidado cadastrado com sucesso!";
            }

            reuniaoConvidado.FkReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);

            List<MODReuniaoConvidado> convidado = new List<MODReuniaoConvidado>();

            convidado = BLLReuniaoConvidado.Pesquisar(reuniaoConvidado, "reuniao");

            if (convidado.Count != 0)
            {
                RptExcluir.DataSource = convidado;
                RptExcluir.DataBind();
            }
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            MODReuniaoConvidado reuniaoConvidado = new MODReuniaoConvidado();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeConvidado");
            string titulo = lbl.Text;
            reuniaoConvidado.Nome = titulo;

            reuniaoConvidado = BLLReuniaoConvidado.PesquisarConvidado(reuniaoConvidado, "nome");
            reuniaoConvidado.IdConvidado = reuniaoConvidado.IdConvidado;
            reuniaoConvidado.FkReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);

            string opcao = Request.Form["opcao"];

            if (opcao == "Sim")
            {
                BLLReuniaoConvidado.Excluir(reuniaoConvidado);
                Response.Write("<script>alert('Convidado excluido com sucesso!')</script>");
            }

            reuniaoConvidado.FkReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);

            List<MODReuniaoConvidado> convidado = new List<MODReuniaoConvidado>();

            convidado = BLLReuniaoConvidado.Pesquisar(reuniaoConvidado, "reuniao");

            if (convidado.Count != 0)
            {
                RptExcluir.DataSource = convidado;
                RptExcluir.DataBind();
            }
        }
    }
}