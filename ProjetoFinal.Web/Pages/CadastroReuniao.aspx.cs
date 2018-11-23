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
    public partial class CadastroReuniao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODReuniao reuniao = new MODReuniao();

            if (TxtPauta.Text.Trim() == "" || TxtPauta.Text.Length > 100)
            {
                LblResposta.Text = Erros.PautaVazia;
            }
            else if (TxtData.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else if (TxtHoraInicio.Text.Trim() == "")
            {
                LblResposta.Text = Erros.HoraVazia;
            }
            else
            {
                try
                {
                    reuniao.Pauta = TxtPauta.Text.Trim();
                    reuniao.DataReuniao = Convert.ToDateTime(TxtData.Text.Trim());
                    reuniao.HoraInicio = Convert.ToDateTime(TxtHoraInicio.Text.Trim());
                    BLLReuniao.Inserir(reuniao);

                    LblResposta.Text = "Reunião cadastrado com sucesso!";
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