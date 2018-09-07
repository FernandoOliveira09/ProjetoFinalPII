<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperaSenhaUsuario.aspx.cs" Inherits="ProjetoFinal.Web.Pages.RecuperaSenhaUsuario" %>

<html>

<head>
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css">
  <style>
    body {
      display: flex;
      min-height: 100vh;
      flex-direction: column;
    }

    main {
      flex: 1 0 auto;
    }

    body {
      background: #fff;
    }

    .input-field input[type=date]:focus + label,
    .input-field input[type=text]:focus + label,
    .input-field input[type=email]:focus + label,
    .input-field input[type=password]:focus + label {
      color: #1976d2;
    }

    .input-field input[type=date]:focus,
    .input-field input[type=text]:focus,
    .input-field input[type=email]:focus,
    .input-field input[type=password]:focus {
      border-bottom: 2px solid #1976d2;
      box-shadow: none;
    }
      
    .cadastro
    {
        margin-top: -4px;    
    }
  </style>
</head>

<body class="blue darken-4">
  <div class="section"></div>
  <main>
    <center>
      <h2 style="color: #fff" class="cadastro"><span style="font-weight: bolder">SG</span> Manager</h2>

      <h6 class="white-text cadastro">Detectamos que seu usuário foi bloqueado <br/>Por favor, insira os seus dados abaixo para recuperar sua conta:</h6>
      <div class="section"></div>

      <div class="container">
        <div class="z-depth-1 grey lighten-4 row" style="display: inline-block; padding: 32px 48px 0px 48px; border: 1px solid #EEE; width: 500px">

          <form class="col s12" method="post" runat="server">
            <div class='row'>
              <div class='col s12'>
              </div>
            </div>

            <div class='row'>
              <div class='input-field col s12 '>
                <asp:Textbox class='validate' type='password' id='TxtSenha' runat="server"/>
                <label for='password'>Senha</label>
              </div>
           </div>

           <div class='row'>
              <div class='input-field col s12 '>
                <asp:Textbox class='validate' type='password' id='TxtSenha2' runat="server"/>
                <label for='password'>insira novamente a senha</label>
              </div>
           </div>
            
            <center>
              <div class='row' align="center">
                <asp:Button type='submit' ID="BtnAlterar" name='btncadastrar' class='col s12 btn btn-large waves-effect blue darken-4' runat="server" Text="Enviar" style="text-align:center" OnClick="BtnAlterar_Click"></asp:Button>
              </div>
            </center>
          </form>
        </div>
      </div>
    </center>

  </main>

  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>
</body>

</html>

