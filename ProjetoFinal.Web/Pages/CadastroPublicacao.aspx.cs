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
    public partial class CadastroPublicacao : System.Web.UI.Page
    {
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
                CarregaGrupo();
                CarregaProjeto();
                CarregaDocente();
                CarregaLinha();
            }
            
        }

        protected void ChkProjeto_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkProjeto.Checked == true)
                TxtProjeto.Enabled = true;
            else
                TxtProjeto.Enabled = false;

            CarregaDocente();
            CarregaLinha();
        }

        private void CarregaGrupo()
        {
            MODGrupo grupo = new MODGrupo();
            TxtGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
            TxtGrupo.DataValueField = "IdGrupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }

        private void CarregaProjeto()
        {
            MODProjetoPesquisa projeto = new MODProjetoPesquisa();

            if(TxtGrupo.Text != "")
            {
                projeto.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                TxtProjeto.DataSource = BLLProjeto_Pesquisa.PesquisarProjetos(projeto, "grupo");
                TxtProjeto.DataValueField = "IdProjeto";
                TxtProjeto.DataTextField = "Titulo";
                TxtProjeto.DataBind();
            } 
        }

        private void CarregaDocente()
        {
            MODDocente docente = new MODDocente();

            if (ChkProjeto.Checked == false)
            {
                MODGrupoDocente grupoDocente = new MODGrupoDocente();
                if (TxtGrupo.Text != "")
                {
                    grupoDocente.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                    TxtDocente.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "grupo");
                    TxtDocente.DataValueField = "id_docente";
                    TxtDocente.DataTextField = "Nome";
                    TxtDocente.DataBind();
                }       
            }
            else
            {
                MODProjetoPesquisa projetoPesquisa = new MODProjetoPesquisa();
                if (TxtProjeto.Text != "")
                {
                    projetoPesquisa.IdProjeto = Convert.ToInt32(TxtProjeto.SelectedValue);
                    projetoPesquisa = BLLProjeto_Pesquisa.PesquisarDocente(projetoPesquisa);
                    docente.IdDocente = projetoPesquisa.FkDocente;
                    TxtDocente.DataSource = BLLDocente.Pesquisar(docente, "id");
                    TxtDocente.DataValueField = "IdDocente";
                    TxtDocente.DataTextField = "nome";
                    TxtDocente.DataBind();
                }
                    
            }
            
        }

        private void CarregaLinha()
        {
            if(ChkProjeto.Checked == false)
            {
                MODDocente_Linha_Pesquisa docenteLinha = new MODDocente_Linha_Pesquisa();
                if (TxtGrupo.Text != "")
                {
                    docenteLinha.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                    docenteLinha.FkDocente = Convert.ToInt32(TxtDocente.SelectedValue);
                    TxtLinha.DataSource = BLLDocente_Linha_Pesquisa.Pesquisar(docenteLinha, "docente");
                    TxtLinha.DataValueField = "id_linha";
                    TxtLinha.DataTextField = "nome_linha";
                    TxtLinha.DataBind();
                }     
            }
            else
            {
                MODProjetoPesquisa_Linha projetoLinha = new MODProjetoPesquisa_Linha();
                if (TxtProjeto.Text != "")
                {
                    projetoLinha.FkProjeto = Convert.ToInt32(TxtProjeto.SelectedValue);
                    TxtLinha.DataSource = BLLProjeto_Pesquisa.PesquisarLinha(projetoLinha);
                    TxtLinha.DataValueField = "id_linha";
                    TxtLinha.DataTextField = "nome_linha";
                    TxtLinha.DataBind();
                }
                    
            }
            
        }

        protected void TxtGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaProjeto();
            CarregaDocente();
            CarregaLinha();
        }

        protected void TxtDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaLinha();
        }

        protected void TxtProjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaDocente();
            CarregaLinha();
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODPublicacao publicacao = new MODPublicacao();
            MODProjetoPesquisa_Linha projetoLinha = new MODProjetoPesquisa_Linha();
            MODLinha_Pesquisa linhaPesquisa = new MODLinha_Pesquisa();

            if (TxtTitulo.Text.Trim() == "")
            {
                LblResposta.Text = Erros.TituloVazio;
            }
            else if (TxtDataPublicacao.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else if (TxtReferencia.Text.Trim() == "")
            {
                LblLiderExiste.Text = "O campo referência ABNT é obrigatório!";
            }
            else
            {
                publicacao.Titulo = TxtTitulo.Text.Trim();
                publicacao.TipoPublicacao = TxtTipoPublicacao.Text.Trim();
                publicacao.DataPublicacao = Convert.ToDateTime(TxtDataPublicacao.Text.Trim());
                publicacao.ReferenciaABNT = TxtReferencia.Text.Trim();

                publicacao.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                publicacao.FkDocente = Convert.ToInt32(TxtDocente.SelectedValue);
                publicacao.FkLinha = Convert.ToInt32(TxtLinha.SelectedValue);

                if (ChkProjeto.Checked == true)
                {
                    if(TxtProjeto.Text == "")
                    {
                        LblResposta.Text = "Não há projetos de pesquisa nesse grupo!";
                    }
                    else
                    {
                        publicacao.FKProjeto = Convert.ToInt32(TxtProjeto.SelectedValue);
                        BLLPublicacao.Inserir(publicacao);

                        LblResposta.Text = "Publicação cadastrada com sucesso!";
                    }
                    
                }
                else
                {
                    BLLPublicacao.Inserir(publicacao);

                    LblResposta.Text = "Publicação cadastrada com sucesso!";
                }
            }
        }
    }
}