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
    public partial class CadastroEquipamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODEquipamento equipamento = new MODEquipamento();

            if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 100)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (TxtDescricao.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DescricaoVazio;
            }
            else
            {
                try
                {
                    equipamento.Nome = TxtNome.Text.Trim();
                    equipamento.Descricao = TxtDescricao.Text.Trim();


                    BLLEquipamento.Inserir(equipamento);

                    LblResposta.Text = "Equipamento cadastrado com sucesso!";
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
