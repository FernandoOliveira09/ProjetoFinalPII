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
    public partial class CadastroAta : System.Web.UI.Page
    {
        int idAta, idReuniao;
        int modo = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                MODReuniao reuniao = new MODReuniao();
                reuniao.IdReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                reuniao = BLLReuniao.PesquisarReuniao(reuniao, "id_reuniao");
                idReuniao = reuniao.IdReuniao;
                TxtPauta.Text = reuniao.Pauta;

                MODAta ata = new MODAta();
                ata.FkReuniao = idReuniao;

                ata = BLLAta.PesquisarAta(ata, "reuniao");

                if (ata.IdAta != 0)
                    modo = 2;

                if (modo == 2)
                {
                    TxtAta.Text = ata.Ata;
                    idAta = ata.IdAta;
                    BtnCadastrar.Text = "Alterar Ata";
                    BtnExcluir.Visible = true;
                }
            }
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODAta ata = new MODAta();

            if (TxtAta.Text == "")
            {
                LblResposta.Text = "O campo ATA é obrigatório";
            }
            else
            {
                ata.FkReuniao = idReuniao;
                ata.Ata = TxtAta.Text.Trim();

                if(modo == 1)
                {
                    BLLAta.Inserir(ata);
                    LblResposta.Text = "Ata cadastrada com sucesso!";
                }
                else
                {
                    ata.IdAta = idAta;
                    BLLAta.Alterar(ata);
                    LblResposta.Text = "Ata alterada com sucesso!";
                }

            }
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            MODAta ata = new MODAta();
            string opcao = Request.Form["opcao"];

            if (opcao == "Sim")
            {
                ata.IdAta = idAta;
                BLLAta.Excluir(ata);
                Response.Write("<script>alert('Ata excluida com sucesso!')</script>");
                Response.Write("<script>top.document.location='../Pages/ConsultaReuniao.aspx'</script>");
            }
        }
    }
}