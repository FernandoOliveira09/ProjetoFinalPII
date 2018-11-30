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
            if (!Page.IsPostBack)
            {

                MODReuniao reuniao = new MODReuniao();
                reuniao.IdReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                reuniao = BLLReuniao.PesquisarReuniao(reuniao, "id_reuniao");
                idReuniao = reuniao.IdReuniao;
                TxtPauta.Text = reuniao.Pauta;

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
        }
    }
}