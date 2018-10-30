using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Utilitarios
{
    public class EnviaEmail
    {
        public void EnvioEmail(string emailDestinatario, string nomeDestinatario, string senha, string prontuario)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("sgmanagersystem@gmail.com", "ifsp2018");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("sgmanagersystem@gmail.com", "SG Manager");
            mail.From = new MailAddress("sgmanagersystem@gmail.com", "SG Manager");
            mail.To.Add(new MailAddress(emailDestinatario, nomeDestinatario));
            mail.Subject = nomeDestinatario + ", Bem vindo ao SG Manager!";
            mail.Body = "<br/>Você acaba de ser incluido no SG Manager!"
                + "<br/>Para acessar a sua conta, usar os dados abaixo: <br/>"
                + "Prontuário (login): " + prontuario
                + "<br/>Senha: " + senha
                + "<br/>Após o primeiro login, você será capaz de mudar a senha atual.";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception)
            {
               //trata erro
            }
            finally
            {
                mail = null;
            }
        }

        public void EnvioEmailRecuperacao(string emailDestinatario, string senha, string prontuario)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("sgmanagersystem@gmail.com", "ifsp2018");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("sgmanagersystem@gmail.com", "SG Manager");
            mail.From = new MailAddress("sgmanagersystem@gmail.com", "SG Manager");
            mail.To.Add(new MailAddress(emailDestinatario));
            mail.Subject = "Recuperação de senha";
            mail.Body = "<br/>Você acabou de solicitar a mudança da sua senha"
                + "<br/>Para acessar a página de recuperação, digite o código abaixo: <br/>"
                + "<br/>Senha: " + senha;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (System.Exception)
            {
                //trata erro
            }
            finally
            {
                mail = null;
            }
        }

        public void EnvioEmailAvisoGrupo(string emailDestinatario, string grupo, string nome)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("sgmanagersystem@gmail.com", "ifsp2018");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("sgmanagersystem@gmail.com", "SG Manager");
            mail.From = new MailAddress("sgmanagersystem@gmail.com", "SG Manager");
            mail.To.Add(new MailAddress(emailDestinatario));
            mail.Subject = nome + " , Há um novo grupo disponível";
            mail.Body = "<br/>O grupo <strong>" + grupo + "</strong> foi adicionado ao SG Manager."
                + "<br/>Acesse o sistema para atualizar o status do grupo. <br/>";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception)
            {
                //trata erro
            }
            finally
            {
                mail = null;
            }
        }
    }
}
