using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace NovaOutsourcing.Web.Models
{
    public class SendMail
    {
        const string nomeRemetente = "Nova Consulting & OutSourcing";
        const string emailRemetente = "novaoutsourcing@novaoutsourcing.com.br";
        const string senha = "cleber30";
        const string SMTP = "webmail.novaoutsourcing.com.br";
        const string assuntoMensagem = "Recebimento Confirmado";
        string emailDestinatario = "";

        //Cria objeto com os dados do SMTP
        SmtpClient objSmtp = new SmtpClient();
        
        NetworkCredential credentials = new NetworkCredential(emailRemetente, senha);

        public void EnviarEmail(Contato contato)
        {
            string conteudoMensagem = "Agradecemos seu contato, "+contato.Nome+" <br/><br/> Seu email foi encaminhado para o setor responsável com sucesso" +
                                      " <br/> Retornaremos o contato o mais breve possível" +
                                      " <br/><br/> Obrigado" +
                                      " <br/> "+nomeRemetente;

            emailDestinatario = contato.Email;
            //Criacao do email
            var objEmail = new MailMessage();
            objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");
            objEmail.To.Add(emailDestinatario);
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = assuntoMensagem;
            objEmail.Body = conteudoMensagem;
            //Evitar caracteres estranhos
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            //Alocamos o endereço do host para enviar os e-mails  
            objSmtp.Credentials = credentials;
            objSmtp.Host = SMTP;
            objSmtp.Port = 587;
                //objSmtp.EnableSsl = true;

            Enviar(objEmail);
        }

        public void EnviaEmailResponsavel(Contato contato)
        {
            //Criacao do email
            var objEmail = new MailMessage();
            objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");
            objEmail.To.Add("contato@novaoutsourcing.com.br");
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = "Nova Mensagem do Site";
            objEmail.Body = contato.Mensagem;
            //Evitar caracteres estranhos
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            //Alocamos o endereço do host para enviar os e-mails  
            objSmtp.Credentials = credentials;
            objSmtp.Host = SMTP;
            objSmtp.Port = 587;
            //objSmtp.EnableSsl = true;

           Enviar(objEmail);         
        }


        private void Enviar(MailMessage objEmail)
        {
            try
            {
                objSmtp.Send(objEmail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }
        }        
    }
}
