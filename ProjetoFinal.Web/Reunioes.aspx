<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reunioes.aspx.cs" Inherits="ProjetoFinal.Web.Reunioes" %>

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
                <asp:Repeater ID="RptPauta" runat="server">
                    <ItemTemplate>
                        <h4 style="text-align: center; margin-top: 40px;">Pauta: <%# Eval("Pauta") %> </h4>
                        <hr />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col s12 container">
                <h4 style="text-align: center;">Participantes </h4>
                <hr />
                <asp:Repeater ID="RptParticipante" runat="server">
                    <ItemTemplate>
                        <p style="margin-left: 40%"><%# Eval("Nome") %></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>       
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col s12 container">
                <h4 style="text-align: center;">Convidados</h4>
                <hr />
                <asp:Repeater ID="RptConvidado" runat="server">
                    <ItemTemplate> 
                        <p style="margin-left: 40%"> <%# Eval("Nome") %></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col s12 container">
                <asp:Repeater ID="RptConsulta" runat="server">
                    <ItemTemplate>
                        <h4 style="text-align: center;">Ata da reunião</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-4" style="margin-left: 5%; margin-right: 5%; text-align: justify">
                                <p><%# Eval("ata") %></p>
                            </div>
                        </div>
                        <div class="row" >
                            <div class="col-md-4" >
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class='row' style="margin-top: -20px">
        <div class='input-field col s12'>
            <form>
                <asp:Label ID="LblResposta" runat="server" Text=""></asp:Label>
            </form>
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
