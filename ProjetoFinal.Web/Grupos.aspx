<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grupos.aspx.cs" Inherits="ProjetoFinal.Web.Grupos" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,
    initial-scale=1.0">
    <title>SG Manager</title>
    <link href="../Content/css/materialize.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="../Content/js/materialize.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Inconsolata" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</head>

<body style="display: flex; min-height: 100vh; flex-direction: column;">
    <nav>
        <div class="nav-wrapper teal">
            <div class="container">
                <a href="Default.aspx" class="brand-logo">SG Manager</a>
                <ul id="nav-mobile" class="right hide-on-med-and-down">
                    <li><a href="../Pages/Login.aspx">Login</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
        <div class="row">
            <div class="col s12 container">
                <asp:Repeater ID="RptConsulta" runat="server">
                    <ItemTemplate>
                        <h3 style="text-align: center; margin-top: 40px;"><%# Eval("Nome") %> - <%# Eval("Sigla") %></h3>
                        <hr />
                        <div class="row">
                            <div style="float: left">
                                <asp:Image ID="Image1" Style="float: left; margin-left: 20%; margin-top: 10px" ImageUrl='<%# string.Format("../Pages/{0}", Eval("Logotipo"))%>' alt="" Width="175" Height="175" class="circle responsive-img valign profile-image cyan" runat="server" />
                            </div>
                            <div class="col-md-4" style="margin-left: 25%">
                                <p>Lider do grupo: <%# Eval("Lider") %></p>
                                <p>Situação: <%# Eval("Situacao") %></p>
                                <p>Data de início: <%# Eval("Data", "{0:d}") %></p>
                                <p>Link no lattes: <a href="<%# Eval("Lattes") %>" target="_blank"><%# Eval("Lattes") %></a></p>
                                <p>Descrição: <%# Eval("Texto_Descricao") %></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col s12 container">
                <h5 style="text-align: center; margin-top: 40px;">Docentes</h5>
                <asp:Repeater ID="RPTDocente" runat="server">
                    <ItemTemplate>
                        <hr />
                        <div class="row">
                            <div style="float: left">
                                <asp:Image ID="ImgDocente" Style="float: left; margin-left: 60%; margin-top: 10px" ImageUrl='<%# string.Format("../Pages/{0}", Eval("Foto"))%>' alt="" Width="100" Height="100" class="circle responsive-img valign profile-image cyan" runat="server" />
                            </div>
                            <div class="col-md-4" style="margin-left: 25%">
                                <p>Nome: <%# Eval("Nome") %></p>
                                <p>Formação: <%# Eval("Formacao") %></p>
                                <p>lattes: <%# Eval("Lattes") %></p>
                                <p>Data Entrada: <%# Eval("Data_Entrada", "{0:d}") %></p>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col s12 container">
                <h5 style="text-align: center; margin-top: 40px;">Técnicos</h5>
                <asp:Repeater ID="RPTTecnico" runat="server">
                    <ItemTemplate>
                        <hr />
                        <div class="row">
                            <div style="float: left">
                                <asp:Image ID="ImgTecnico" Style="float: left; margin-left: 60%; margin-top: 10px" ImageUrl='<%# string.Format("../Pages/{0}", Eval("Foto"))%>' alt="" Width="100" Height="100" class="circle responsive-img valign profile-image cyan" runat="server" />
                            </div>
                            <div class="col-md-4" style="margin-left: 25%">
                                <p>Nome: <%# Eval("Nome") %></p>
                                <p>Formação: <%# Eval("Formacao") %></p>
                                <p>lattes: <%# Eval("Lattes") %></p>
                                <p>Data Entrada: <%# Eval("Data_Entrada", "{0:d}") %></p>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col s12 container">
                <h5 style="text-align: center; margin-top: 40px;">Linhas de pesquisa</h5>
                <asp:Repeater ID="RPTLinha" runat="server">
                    <ItemTemplate>
                        <hr />
                        <div class="row">
                            <div class="col-md-4" style="margin-left: 25%">
                                <p>Linha: <%# Eval("Nome_linha") %></p>
                                <p>Descrição: <%# Eval("Descricao") %></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col s12 container">
                <h5 style="text-align: center; margin-top: 40px;">Projetos de pesquisa</h5>
                <asp:Repeater ID="RPTProjetos" runat="server">
                    <ItemTemplate>
                        <hr />
                        <div class="row">
                            <div class="col-md-4" style="margin-left: 25%">
                                <p><%# Eval("Titulo") %> - <a href="Projetos.aspx?id=<%# Eval("id_projeto") %>">Ver publicações</a></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col s12 container">
                <h5 style="text-align: center; margin-top: 40px;">Publicações do grupo</h5>
                <asp:Repeater ID="RPTPublicacao" runat="server">
                    <ItemTemplate>
                        <hr />
                        <div class="row">
                            <div class="col-md-4" style="margin-left: 25%">
                                <p>Título: <%# Eval("Titulo") %></p>
                                <p>Orientador: <%# Eval("Orientador") %></p>
                                <p>Linha de pesquisa: <%# Eval("Linha") %></p>
                                <p>Tipo de publicação: <%# Eval("Tipo") %></p>
                                <p>Linha de pesquisa: <%# Eval("Data") %></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col s12 container">
                <h5 style="text-align: center; margin-top: 40px;">Discentes</h5>
                <asp:Repeater ID="RPTDiscente" runat="server">
                    <ItemTemplate>
                        <hr />
                        <div class="row">
                            <div class="col-md-4" style="margin-left: 25%">
                                <p>Linha: <%# Eval("Nome") %></p>
                                <p>Curso: <%# Eval("Curso") %></p>
                                <p>Lattes: <a href="<%# Eval("Lattes") %>"><%# Eval("Lattes") %></a></p>
                                <p>Projeto de pesquisa: <%# Eval("Projeto") %></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col s12 container">
                <h5 style="text-align: center; margin-top: 40px;">Equipamentos</h5>
                <asp:Repeater ID="RptEquipamento" runat="server">
                    <ItemTemplate>
                        <hr />
                        <div class="row">
                            <div class="col-md-4" style="margin-left: 25%">
                                <p>Nome: <%# Eval("Nome") %></p>
                                <p>Descricao: <%# Eval("Descricao") %></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <hr />
    </div>
    <div class="row">
        <form runat="server">
            <h5 style="text-align: center; margin-top: 40px;">Reuniões</h5>
            <hr />
            <div class="col-md-4">
                <asp:Calendar ID="CldReuniao" runat="server" Width="500" Height="250" OnDayRender="CldReuniao_DayRender" OnVisibleMonthChanged="CldReuniao_VisibleMonthChanged" SelectionMode="None"></asp:Calendar>
            </div>
        </form>
    </div>
    <div class='row' style="margin-top: -20px">
        <div class='input-field col s12'>
            <asp:Repeater ID="RptReuniao" runat="server">
                <HeaderTemplate>
                    <table class="striped responsive-table">
                        <thead>
                            <tr>
                                <th>Data</th>
                                <th>Pauta</th>
                                <th>Ver ata</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("data_reuniao", "{0:d}") %></td>
                        <td><%# Eval("Pauta") %></td>
                        <td><a class="btn waves-effect waves-light teal lighten-2" href="Reunioes.aspx?id=<%# Eval("id_reuniao") %>"><i class="material-icons">remove_red_eye</i></a></td>
                        <%--                                <td><button class="waves-effect waves-light btn teal lighten-2 BtnAlterar"><i class="material-icons">edit</i><a href="../Pages/Login.aspx"></a></button>&nbsp<button class="waves-effect waves-light btn teal lighten-2 BtnMais"><i class="material-icons">visibility</i></button></td>--%>
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
        <hr />
    </div>
    
    <hr />
    <br />

    <footer class="page-footer teal" style="bottom: 0; position: fixed; width: 100%">

        <div class="footer-copyright">
            <div class="container">
                © 2018 Copyright Fernando, Reginaldo, Eduardo
                <a class="grey-text text-lighten-4 right" href="Default.aspx">Home</a>
            </div>
        </div>
    </footer>

    <script src="~/Scripts/jquery-2.1.1.min.js"></script>

</body>

</html>
