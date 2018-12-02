<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VincularProjetoColaborador.aspx.cs" Inherits="ProjetoFinal.Web.Pages.VincularProjetoColaborador" %>

<!DOCTYPE html>
<html lang="pt-br">
  <!--================================================================================
	Item Name: Materialize - Material Design Admin Template
	Version: 4.0
	Author: PIXINVENT
	Author URL: https://themeforest.net/user/pixinvent/portfolio
  ================================================================================ -->
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="msapplication-tap-highlight" content="no">
    <meta name="description" content="Materialize is a Material Design Admin Template,It's modern, responsive and based on Material Design by Google. ">
    <meta name="keywords" content="materialize, admin template, dashboard template, flat admin template, responsive admin template,">
    <title>Admin | SG Manager</title>
    <!-- Favicons-->
    <link rel="icon" href="../Content/images/favicon/favicon-32x32.png" sizes="32x32">
    <!-- Favicons-->
    <link rel="apple-touch-icon-precomposed" href="../Content/images/favicon/apple-touch-icon-152x152.png">
    <!-- For iPhone -->
    <meta name="msapplication-TileColor" content="#00bcd4">
    <meta name="msapplication-TileImage" content="../Content/images/favicon/mstile-144x144.png">
    <!-- For Windows Phone -->
    <!-- CORE CSS-->
    <link href="../Content/css//materialize.css" type="text/css" rel="stylesheet">
    <link href="../Content/css//style.css" type="text/css" rel="stylesheet">
    <!-- Custome CSS-->
    <link href="../Content/css/custom/custom.css" type="text/css" rel="stylesheet">
    <!-- INCLUDED PLUGIN CSS ON THIS PAGE -->
    <link href="../Content/vendors/perfect-scrollbar/perfect-scrollbar.css" type="text/css" rel="stylesheet">
    <link href="../Content/vendors/flag-icon/css/flag-icon.min.css" type="text/css" rel="stylesheet">
  </head>
  <body>
    <!-- Start Page Loading -->
    <div id="loader-wrapper">
      <div id="loader"></div>
      <div class="loader-section section-left"></div>
      <div class="loader-section section-right"></div>
    </div>
    <!-- End Page Loading -->
    <!-- //////////////////////////////////////////////////////////////////////////// -->
    <!-- START HEADER -->
    <header id="header" class="page-topbar">
      <!-- start header nav-->
      <div class="navbar-fixed">
        <nav class="navbar-color blue darken-4">
          <div class="nav-wrapper">
            <ul class="left">
              <li>
                <h1 class="logo-wrapper">
                  <a href="../Pages/Principal.aspx" class="brand-logo darken-1">
                    <img src="../Content/images/logo/materialize-logo.png" alt="materialize logo">
                    <span class="logo-text hide-on-med-and-down"><strong>SG</strong> Manager</span>
                  </a>
                </h1>
              </li>
            </ul>
            <ul class="right hide-on-med-and-down">
              <li>
                <a href="javascript:void(0);" class="waves-effect waves-block waves-light toggle-fullscreen">
                  <i class="material-icons">settings_overscan</i>
                </a>
              </li>
              <li>
                <a href="javascript:void(0);" class="waves-effect waves-block waves-light profile-button" data-activates="profile-dropdown">
                  <span class="avatar-status avatar-online">
                    <asp:Image ID="ImagemUser2" ImageUrl="../Pages/Imagens/usuario.png" alt="" class="circle responsive-img valign profile-image cyan" runat="server"/>
                    <i></i>
                  </span>
                </a>
              </li>
            </ul>
            <!-- translation-button -->
            
            <!-- profile-dropdown -->
            <ul id="profile-dropdown" class="dropdown-content">
              <li>
                <a href="../Pages/AlteracaoUsuario.aspx" class="grey-text text-darken-1">
                  <i class="material-icons">settings</i> Alterar Informações</a>
              </li>
              <li class="divider"></li>
              <li>
                <a href="../Pages/Login.aspx?logout=logout" class="grey-text text-darken-1">
                  <i class="material-icons">keyboard_tab</i> Logout</a>
              </li>
            </ul>
          </div>
        </nav>
      </div>
      <!-- end header nav-->
    </header>
    <!-- END HEADER -->
    <!-- //////////////////////////////////////////////////////////////////////////// -->
    <!-- START MAIN -->
    <div id="main">
      <!-- START WRAPPER -->
      <div class="wrapper">
        <!-- START LEFT SIDEBAR NAV-->
        <aside id="left-sidebar-nav">
          <ul id="slide-out" class="side-nav fixed leftside-navigation">
            <li class="user-details cyan darken-2">
              <div class="row">
                <div class="col col s4 m4 l4">
                    <asp:Image ID="ImagemUser" ImageUrl="../Pages/Imagens/usuario.png" alt="" class="circle responsive-img valign profile-image cyan" runat="server"/>
                    <!--<asp:Image src="../Content/images/avatar/avatar-7.png" alt="" class="circle responsive-img valign profile-image cyan" runat="server"/>-->
                    <!--<img src="../Content/images/avatar/avatar-7.png" alt="" class="circle responsive-img valign profile-image cyan">-->
                </div>
                <div class="col col s8 m8 l8">
                  
                  <a class="btn-flat waves-light white-text profile-btn" href="#" data-activates="profile-dropdown-nav"><asp:Label ID="LblNome" runat="server">Usuário</asp:Label> <i class="mdi-navigation-arrow-drop-down right"></i></a>
                  <p class="user-roal"><asp:Label ID="LblFuncao" runat="server">Função</asp:Label></p>
                </div>
              </div>
            </li>
            <li class="no-padding">
                        <ul class="collapsible" data-collapsible="accordion">
                            <li class="bold">
                                <a href="Principal.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">pie_chart_outlined</i>
                                    <span class="nav-text">Dashboard</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="ConsultaUsuario.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group</i>
                                    <span class="nav-text">Usuários</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="ConsultaGrupo.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group_work</i>
                                    <span class="nav-text">Grupos de Pesquisa</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaDocente.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group</i>
                                    <span class="nav-text">Docentes</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaDiscente.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group</i>
                                    <span class="nav-text">Discentes</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaTecnico.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group</i>
                                    <span class="nav-text">Técnicos</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaEquipamento.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">settings</i>
                                    <span class="nav-text">Equipamentos</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaProjetoPesquisa.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">work</i>
                                    <span class="nav-text">Projetos de pesquisa</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaPublicacao.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">title</i>
                                    <span class="nav-text">Publicações</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/SelecionarRelatorio.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">insert_drive_file</i>
                                    <span class="nav-text">Relatórios</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaReuniao.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">textsms</i>
                                    <span class="nav-text">Reuniões</span>
                                </a>
                            </li>
                            <li>
                                <a class="collapsible-header">Linhas de pesquisa<i class="material-icons">search</i></a>
                                <div class="collapsible-body">
                                    <ul>
                                        <li><a href="../Pages/ConsultaAreaConhecimento.aspx">Áreas do conhecimento</a></li>
                                        <li><a href="../Pages/ConsultaAreaAvaliacao.aspx">Áreas de avaliação</a></li>
                                        <li><a href="../Pages/ConsultaSubAreaAvaliacao.aspx">Sub áreas de avaliação</a></li>
                                        <li><a href="../Pages/ConsultaLinhaPesquisa.aspx">Linhas de pesquisa</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </li>
          </ul>
          <a href="#" data-activates="slide-out" class="sidebar-collapse btn-floating btn-medium waves-effect waves-light hide-on-large-only">
            <i class="material-icons">menu</i>
          </a>
        </aside>
        <!-- END LEFT SIDEBAR NAV-->
        <!-- //////////////////////////////////////////////////////////////////////////// -->
        <!-- START CONTENT -->
        <section id="content">
          <!--start container-->
            <div id="breadcrumbs-wrapper">
              <!-- Search for small screen -->
              <div class="header-search-wrapper grey lighten-2 hide-on-large-only">
                <input type="text" name="Search" class="header-search-input z-depth-2" placeholder="Explore Materialize">
              </div>
              <div class="container">
                <div class="row">
                  <div class="col s10 m6 l6">
                    <h5 class="breadcrumbs-title">Vínculo de Colaboradores</h5>
                    <ol class="breadcrumbs">
                      <li><a href="../Pages/Principal.aspx">Dashboard</a></li>
                      <li><a href="#">Projetos</a></li>
                      <li><a href="#">Vínculo de Colaboradores</a></li>
                    </ol>
                  </div>
                </div>
              </div>
            </div>
            <form class="col s12" runat="server">
            <div id="basic-form" class="section">
                <div class="row" style="display: inline-block">
                  <div class="col s12 m12 l12">
                    <div class="card-panel">
                      <h4 class="header2">Insira os dados nos campos abaixo para vincular</h4>
                      <div class="row">
                          <div class="row">
                            <div class="input-field col s12">
                              <asp:TextBox id="TxtProjeto" type="text" runat="server" Enabled="false"/>
                              <label for="TxtProjeto">Projeto</label>
                            </div>
                          </div>  

                          <div class="row">
                            <div class="input-field col s8">
                              <asp:TextBox id="TxtPesquisarColaborador" type="text" runat="server" />
                              <label for="TxtPesquisarDiscente">Pesquisar colaborador<span style="color: red;">*</span></label>
                            </div>
                          </div>
                          <div class="input-field col s1" style="float:right; margin-top: -74px;">                          
                            <asp:LinkButton ID="BtnPesquisar" class="btn waves-effect waves-light breadcrumbs-btn right teal lighten-2" runat="server" Text="Pesquisar" OnClick="BtnPesquisar_Click" />
                          </div>
                          <div class="row">
                            <div class='input-field col s12' style="margin-top: -10px">
                                <h5>Discentes</h5>
                                <asp:Repeater ID="RptColaborador" runat="server">
                                    <HeaderTemplate>
                                        <table class="striped responsive-table">
                                            <thead>
                                              <tr>
                                                  <th>Nome do colaborador</th>
                                                  <th>Ações</th>
                                              </tr>
                                            </thead>
                                        <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                         <tr>
                                            <td><asp:Label ID="TxtNomeColaborador" Text='<%# Eval("Nome") %>' runat="server"></asp:Label> </td>
                                            <td><asp:DropDownList ID="DdlAddColaborador" runat="server">
                                                    <asp:ListItem Text="Sim"></asp:ListItem>
                                                    <asp:ListItem Text="Não"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>               
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                      </table>
                                    </FooterTemplate>
                                </asp:Repeater> 
                            </div>
                          </div>
                         

                            <div class="row">
                                <div class="input-field col s12">
                                    <asp:Label ID="LblResposta" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                            </div> 

                          <div class="row">
                              <div class="input-field col s12">
                                  <asp:Button id="BtnVincular" class="btn waves-effect waves-light right teal lighten-2" type="submit" name="action" Text="Vincular" runat="server" OnClick="BtnVincular_Click">
                                  </asp:Button>
                              </div>
                          </div>                        
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </form>
          <!--end container-->
         </section>
      </div>
      <!-- END WRAPPER -->
    </div>
    <!-- END MAIN -->
    <!-- //////////////////////////////////////////////////////////////////////////// -->
    <!-- START FOOTER -->
    <footer class="page-footer gradient-45deg-light-blue-cyan">
        <div class="footer-copyright">
          <div class="container">
            <span>Copyright ©
              <script type="text/javascript">
                document.write(new Date().getFullYear());
              </script>
            <span class="right hide-on-small-only"> Desenvolvido por Fernando, Reginaldo e Eduardo </span>
          </div>
        </div>
    </footer>
    <!-- END FOOTER -->
    <!-- ================================================
    Scripts
    ================================================ -->
    <!-- jQuery Library -->
    <script type="text/javascript" src="../Content/vendors/jquery-3.2.1.min.js"></script>
    <!--materialize js-->
    <script type="text/javascript" src="../Content/js/materialize.min.js"></script>
    <!--scrollbar-->
    <script type="text/javascript" src="../Content/vendors/perfect-scrollbar/perfect-scrollbar.min.js"></script>
    <!--plugins.js - Some Specific JS codes for Plugin Settings-->
    <script type="text/javascript" src="../Content/js/plugins.js"></script>
    <!--custom-script.js - Add your own theme custom JS-->
    <script type="text/javascript" src="../Content/js/custom-script.js"></script>
    <script>$('.dropdown-trigger').dropdown();</script>
     <script src="../Content/js/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
         jQuery(function ($) {
             $("#TxtDataInicio").mask("99/99/9999");

         });
    </script>
  </body>
</html>
