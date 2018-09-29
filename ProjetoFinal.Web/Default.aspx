<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjetoFinal.Web.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,
    initial-scale=1.0">
    <title>@ViewBag.Title - SG Manager</title>
    <link href="../Content/css/materialize.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="../Content/js/materialize.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Inconsolata" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">

</head>

<body>
    <nav>
        <div class="nav-wrapper teal">
            <div class="container">
                <a href="" class="brand-logo">SG Manager</a>
                <ul id="nav-mobile" class="right hide-on-med-and-down">
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <asp:Repeater ID="RptConsulta" runat="server">
                     <ItemTemplate>
                         <h3><%# Eval("Nome") %> - (<%# Eval("Sigla") %>)</h3>
                         <p><%# Eval("Texto_Descricao") %></p>
                         <p>Lattes - <a href="<%# Eval("Lattes") %>"><%# Eval("Lattes") %></a></p>
                         <p><a class="btn btn-default" href="../Pages/Login.aspx?grupo=<%# Eval("Nome") %>">Acesso a nossa Pagina &raquo;</a></p>
                         <hr />
                     </ItemTemplate>
                 </asp:Repeater>
            </div>
            <div class="col-md-4">
                <h3>Cadastramento de grupos de pesquisa</h3>
                <p>
                    A Pró-Reitoria de Pesquisa, Inovação e Pós-Graduação (PRP) é a responsável pelo cadastramento no
                    Diretório dos Grupos de Pesquisa no Brasil, no Conselho Nacional de Desenvolvimento Científico e
                    Tecnológico (CNPq), e mantém a relação dos grupos cadastrados no link <a href="https://prp.ifsp.edu.br/diretoria-de-pesquisa/grupos-de-pesquisa/grupos" target="_blank">Grupos de Pesquisa do IFSP.</a><br />
                    <br />

                    A Portaria nº 1.718, de 5 de maio de 2017, estabeleceu o novo regulamento dos Grupos de Pesquisa
                    Institucionais e está disponível para consulta no link <a href="https://prp.ifsp.edu.br/diretoria-de-pesquisa/grupos-de-pesquisa" target="_blank">Grupos de Pesquisa</a> da PRP. Conforme o Art. 17
                    desta Portaria, para a proposta de criação de grupo deverá ser utilizado o formulário de Grupo de Pesquisa
                    Institucional, disponível no link supracitado, a ser encaminhado pelo primeiro líder ao presidente do
                    Compesq do câmpus por e-mail para <a href="mailto:pesquisa.brt@ifsp.edu.br" target="_blank">pesquisa.brt@ifsp.edu.br</a> , com a indicação do assunto “Criação de Grupo
                    de Pesquisa”. Devem constar as seguintes informações no corpo da mensagem: <br /><br />

                    • nome do grupo de pesquisa; <br /><br />
                    • nome do primeiro líder, titulação, câmpus de lotação e n.º do CPF;<br /><br />
                    • nome e titulação dos membros pesquisadores;<br /><br />
                    • linhas de pesquisa;<br /><br />
                    • justificativa para a formação do grupo, demonstrando a relevância e as perspectivas de contribuição
                    científica, tecnológica, artística ou cultural em até 600 caracteres, incluindo os espaços;<br /><br />
                    • justificativa para atipicidade, se for o caso, considerando os termos do Art. 23 da referida Portaria,
                    em até 200 caracteres, incluindo os espaços;<br /><br />
                    • descrição do grupo de, no máximo, 400 caracteres, incluindo os espaços, para ser apresentada na página
                    da PRP, junto com a logomarca.<br /><br />


                    É importante que o primeiro líder, antes de enviar a proposta, observe o disposto no Art. 9.º e no Art. 30 da referida Portaria.
                </p>
            </div>
            <div class="col-md-4">
                <h2>Produção Científica e Tecnológica</h2>
                <p>
                    Dados referentes às produções científica e tecnológica dos servidores do câmpus podem ser consultados na
                    pasta abaixo. Essas informações foram extraídas da Plataforma Lattes do CNPq, a partir da Plataforma Stela
                    Experta, e são válidas até a data indicada no nome do arquivo.
                </p>
                <br />
                <a href="https://brt.ifsp.edu.br/grupos-de-pesquisa/stela-experta" target="_blank">Stela Experta</a>
            </div>
        </div>
        <hr />
    </div>

    <footer class="page-footer teal">

        <div class="footer-copyright">
            <div class="container">
                © 2018 Copyright Fernando, Reginaldo, Eduardo
                <a class="grey-text text-lighten-4 right" href="#!">Home</a>
            </div>
        </div>
    </footer>

    <script src="~/Scripts/jquery-2.1.1.min.js"></script>

</body>

</html>
