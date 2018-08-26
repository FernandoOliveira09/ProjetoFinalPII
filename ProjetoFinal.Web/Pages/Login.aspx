<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoFinal.Web.Pages.Login" %>
<!DOCTYPE html>
<html>

<head>
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="../Content/css/materialize.min.css">
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
    color: #e91e63;
  }

  .input-field input[type=date]:focus,
  .input-field input[type=text]:focus,
  .input-field input[type=email]:focus,
  .input-field input[type=password]:focus {
    border-bottom: 2px solid #e91e63;
    box-shadow: none;
  }
</style>
</head>

<body class="blue darken-4">
  <div class="section"></div>
  <main>
    <center>
      <!--<img class="responsive-img" style="width: 250px;" src="https://i.imgur.com/ax0NCsK.gif" />-->
      <h2 class="white-text"><strong>SG</strong> Manager</h2>
      <h5 class="white-text">Por favor, faça login na sua conta</h5>
      <div class="section"></div>

      <div class="container" >
        <div class="z-depth-1 grey lighten-4 row" style="display: inline-block; padding: 32px 48px 0px 48px; border: 1px solid #EEE;">

          <form class="col s12" method="post" runat="server">
            <div class='row'>
              <div class='col s12'>
              </div>
            </div>

            <div class='row' runat="server">
              <div class='input-field col s12'>
                <asp:TextBox type='email' name='email' id='TxtLogin' runat="server"/>
                <label for='email'>Prontuário</label>
              </div>
            </div>

            <div class='row'>
              <div class='input-field col s12'>
                <asp:TextBox type='text' name='password' id='TxtSenha' runat="server" />
                <label for='password'>Senha</label>
              </div>
              <label style='float: right;'>
                <a class='blue-text' href='#!'><b>Esqueceu a sua senha?</b></a>
              </label>
            </div>

            <br />
            <center>
              <div class='row'>
                <asp:LinkButton type='submit' id="BtnLogar" name='btn_login' class='col s12 btn btn-large waves-effect blue darken-4' runat="server" Text="Login" style='text-align: center' OnClick="BtnLogar_Click"></asp:LinkButton>
              </div>
            </center>
          </form>
        </div>
      </div>
      <a href="#!"><span class="white-text">Crie sua conta</span></a>
    </center>
  </main>

  <script type="text/javascript" src="../Content/js/jquery.min.js"></script>
  <script type="text/javascript" src="../Content/js/materialize.min.js"></script>
</body>

</html>