using System;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Business
{
   [ServiceContract(Namespace = "")]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class SendEmail
   {
      [OperationContract]
      public String SendingEmail(String eMailTo, String eSubject, String eContent, String rutaAdjunto="")
      {
         String EmailSending = String.Empty;            

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(eMailTo));
						msg.From = new MailAddress("infoinvers.jcjm@gmail.com");
            msg.Subject = eSubject;
            msg.Body = eContent;				
            msg.IsBodyHtml = true;				
						if (rutaAdjunto != "")
						{							
							Attachment _Attachment = new Attachment(rutaAdjunto);
							msg.Attachments.Add(_Attachment);
						}

            SmtpClient clienteSmtp = new SmtpClient();
						clienteSmtp.Credentials = new NetworkCredential("infoinvers.jcjm@gmail.com", "infoinvers");					
						clienteSmtp.Host = "smtp.gmail.com";
            clienteSmtp.Port = 587;
            clienteSmtp.EnableSsl = true;
         try
         {
            clienteSmtp.Send(msg);
            EmailSending = "Enviado";
         }

         catch(Exception ex)
         {
            EmailSending = "** " + ex.Message + "\n **" + ex.StackTrace + "\n **" + ex.Source;
         }
         return EmailSending;
      }
   }
}
