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
    public partial class CadastroGrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaDropDownList();
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            MODGrupo grupo = new MODGrupo();
            MODGrupoLider grupoLider = new MODGrupoLider();

            if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 60)
            {
                LblResposta.Text = Erros.EmailVazio;
            }
            else if (TxtSigla.Text.Trim() == "" || TxtNome.Text.Length > 10)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (TxtData.Text.Trim() == "")
            {
                LblResposta.Text = Erros.LoginVazio;
            }
            else
            {
                try
                {
                    grupo.Nome = TxtNome.Text.Trim();
                    grupo.Sigla = TxtSigla.Text.Trim();
                    grupo.FkSituacao = 1;

                    grupoLider.FkGrupo = BLLGrupo.InserirGrupo(grupo);


                    LblResposta.Text = "Grupo cadastrado com sucesso!";
                    grupoLider.FkUsuario = TxtLider.SelectedValue.ToString();
                    grupoLider.DataEntrada = Convert.ToDateTime(TxtData.Text.Trim());

                    BLLGrupo.InserirLider(grupoLider);

                    LblResposta.Text = "Lider adicionado com sucesso!";

                    //Response.Redirect("../Pages/Principal.aspx");

                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
            }
        }

        private void CarregaDropDownList()
        {
            MODUsuario usuario = new MODUsuario();

            TxtLider.DataSource = BLLUsuario.Pesquisar(usuario, "todos");
            //Indico que o DataValueField é a  
            //propriedade Id da classe Estado 
            TxtLider.DataValueField = "login";
            //Indico que o DataTextField é a  
            //propriedade NomeEstado da classe Estado 
            TxtLider.DataTextField = "nome";
            //Bindo o DropDownList 
            TxtLider.DataBind();
        }
    }
}