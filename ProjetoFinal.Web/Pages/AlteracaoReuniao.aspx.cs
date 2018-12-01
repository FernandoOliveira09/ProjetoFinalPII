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
    public partial class AlteracaoReuniao : System.Web.UI.Page
    {
        private static int idReuniao;

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

            MODReuniao reuniao = new MODReuniao();

            reuniao.IdReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
            reuniao = BLLReuniao.PesquisarReuniao(reuniao, "id_reuniao");

            if (!Page.IsPostBack)
            {
                TxtPauta.Text = reuniao.Pauta;
                TxtData.Text = reuniao.DataReuniao.ToShortDateString().ToString();
                TxtHoraInicio.Text = reuniao.HoraInicio.ToString("hh:mm");
                if(reuniao.HoraFim.ToString() == "01/01/0001 00:00:00")
                    TxtHoraTermino.Text = "";
                else
                    TxtHoraTermino.Text = reuniao.HoraFim.ToString("hh:mm");
            }
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODReuniao reuniao = new MODReuniao();

            if (TxtPauta.Text.Trim() == "" || TxtPauta.Text.Length > 100)
            {
                LblResposta.Text = Erros.PautaVazia;
            }
            else if (TxtData.Text.Trim() == "" || TxtData.Text.Length > 50)
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else if (TxtHoraInicio.Text.Trim() == "" || TxtHoraInicio.Text.Length > 50)
            {
                LblResposta.Text = Erros.HoraVazia;
            }
            else
            {
                try
                {
                    reuniao.IdReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                    reuniao.Pauta = TxtPauta.Text.Trim();
                    reuniao.DataReuniao = Convert.ToDateTime(TxtData.Text.Trim());
                    reuniao.HoraInicio = Convert.ToDateTime(TxtHoraInicio.Text.Trim());
                    reuniao.HoraFim = Convert.ToDateTime(TxtHoraTermino.Text.Trim());

                    BLLReuniao.Alterar(reuniao);

                    LblResposta.Text = "Reunião alterada com sucesso!";

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