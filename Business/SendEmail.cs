using System;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Business
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SendEmail
    {
        [OperationContract]
        public String SendingEmail(String eMailTo, String eSubject, String eContent, String rutaAdjunto = "")
        {
            String EmailSending = String.Empty;

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(eMailTo));
            msg.From = new MailAddress("infoinvers.jcjm@gmail.com");
            msg.Subject = eSubject;
            //msg.Body = eContent;
            StringBuilder sbBody = new StringBuilder();
            sbBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sbBody.Append("<head>");
            sbBody.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />");
            sbBody.Append("<title>Untitled Document</title>'");
            sbBody.Append("</head>");
            sbBody.Append("<body>");
            sbBody.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
            sbBody.Append("<tr>");
            sbBody.Append("<td align='center' valign='top' bgcolor='#BADBE7' style='background-color:#BADBE7;'>");
            sbBody.Append("<br>");
            sbBody.Append("<br>");
            sbBody.Append("<table width='600' border='0' cellspacing='0' cellpadding='0'>");
            sbBody.Append("<tr>");
            sbBody.Append("<td height='70' align='left' valign='middle'>");
            sbBody.Append("<img src='https://googledrive.com/host/0BzRIQpXsD5ySZXE0SkUxUDVPZ2c/_siisa.png' width='292' height='54' style='display:block;'>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            //sbBody.Append("<tr>");
            //sbBody.Append("<td align='left' valign='top'>");
            //sbBody.Append("<img src='images/top.png' width='600' height='13' style='display:block;'>");
            //sbBody.Append("</td>");
            //sbBody.Append("</tr>");
            sbBody.Append("<tr>");
            sbBody.Append("<td align='left' valign='top' bgcolor='#475883' style='background-color:#475883; font-family:Arial, Helvetica, sans-serif; padding:10px;'>");
            sbBody.Append("<div style='font-size:36px; color:#BADBE7;'>");
            sbBody.Append("<b>" + eSubject + "</b>");
            sbBody.Append("</div>");
            //sbBody.Append("<div style='font-size:13px; color:#a29881;'>");
            //sbBody.Append("<b>Newsletter SubTitle</b>");
            sbBody.Append("</div>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            sbBody.Append("<tr>");
            sbBody.Append("<td align='left' valign='top' bgcolor='#ffffff' style='background-color:#ffffff;'>");
            //sbBody.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
            //sbBody.Append("<tr>");
            //sbBody.Append("<td align='center' valign='middle' style='padding:10px; color:#564319; font-size:42px; font-family:Georgia, 'Times New Roman', Times, serif;'>30% Off, Special Discount</td>");
            //sbBody.Append("</tr>");
            //sbBody.Append("</table>");
            //sbBody.Append("<table width='95%' border='0' align='center' cellpadding='0' cellspacing='0'>");
            //sbBody.Append("<tr>");
            //sbBody.Append("<td width='40%' align='center' valign='middle' style='padding:10px;'>");
            //sbBody.Append("<img src='images/mainpic.jpg' width='169' height='187' style='display:block'>");
            //sbBody.Append("</td>");
            //sbBody.Append("<td align='left' valign='middle' style='color:#525252; font-family:Arial, Helvetica, sans-serif; padding:10px;'>");
            //sbBody.Append("<div style='font-size:24px;'>Lorem ipsum dolor sit amet, consectetur tempor </div>");
            //sbBody.Append("<div style='font-size:12px;'>Aliquam sed velit vitae nibh pulvinar iaculis. Aenean hendrerit, lorem eu luctus cursus, sapien justo auctor ligula, id bibendum lorem leo quis leo. Suspendisse sit amet aliquam orci. Aliquam erat volutpat. Aliquam erat volutpat. Nunc ac justo enim. Morbi eleifend feugiat turpis non placerat. Etiam sed tellus ac lectus lacinia molestie nec eu nisl. </div>");
            //sbBody.Append("</td>");
            //sbBody.Append("</tr>");
            //sbBody.Append("</table>");
            //sbBody.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
            //sbBody.Append("<tr>");
            //sbBody.Append("<td align='center' valign='middle' style='padding:5px;'>");
            //sbBody.Append("<img src='images/divider.gif' width='566' height='30'>");
            //sbBody.Append("</td>");
            //sbBody.Append("</tr>");
            //sbBody.Append("</table>");
            sbBody.Append("<table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' style='margin-bottom:15px;'>");
            sbBody.Append("<tr>");
            sbBody.Append("<td align='left' valign='middle' style='padding:15px; font-family:Arial, Helvetica, sans-serif;'>");
            //sbBody.Append("<div style='font-size:20px; color:#564319;'>Lorem ipsum dolor sit amet, consectetur</div>");
            sbBody.Append("<div style='font-size:13px; color:#525252;'>");
            sbBody.Append(eContent);
            sbBody.Append("</div>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            sbBody.Append("</table>");
            //sbBody.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0' style='margin-bottom:10px;'>");
            //sbBody.Append("<tr>");
            //sbBody.Append("<td align='left' valign='middle' style='padding:15px; background-color:#564319; font-family:Arial, Helvetica, sans-serif;'>");
            //sbBody.Append("<div style='font-size:20px; color:#ffe77b;'>Lorem ipsum dolor sit amet, consectetur</div>");
            //sbBody.Append("<div style='font-size:13px; color:#ffe77b;'>tempor venenatis eros. Aliquam sed velit vitae nibh pulvinar iaculis. Aenean hendrerit, lorem eu luctus cursus, sapien justo auctor ligula, id bibendum lorem leo quis leo. Suspendisse sit amet aliquam orci. Aliquam erat volutpat. Aliquam erat volutpat. Nunc ac justo enim. <br>");
            //sbBody.Append("<br>");
            //sbBody.Append("<a href='#' style='color:#ffe77b; text-decoration:underline;'>CLICK HERE</a>");
            //sbBody.Append("FOR MORE INFORMATION ");
            //sbBody.Append("</div>");
            //sbBody.Append("</td>");
            //sbBody.Append("</tr>");
            //sbBody.Append("</table>");
            sbBody.Append("<table width='95%' border='0' align='center' cellpadding='0' cellspacing='0'>");
            sbBody.Append("<tr>");
            sbBody.Append("<td width='50%' align='left' valign='middle' style='padding:10px;'>");
            sbBody.Append("<table width='75%' border='0' cellspacing='0' cellpadding='4'>");
            sbBody.Append("<tr>");
            sbBody.Append("<td align='left' valign='top' style='font-family:Verdana, Geneva, sans-serif; font-size:14px; color:#000000;'>");
            sbBody.Append("<b>Siganos en:</b>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            sbBody.Append("<tr>");
            sbBody.Append("<td align='left' valign='top' style='font-family:Verdana, Geneva, sans-serif; font-size:12px; color:#000000;'>");
            sbBody.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
            sbBody.Append("<tr>");
            sbBody.Append("<td width='33%' align='left' valign='middle'>");
            sbBody.Append("<a href='https://twitter.com/siisa_sas'><img src='https://pbs.twimg.com/profile_images/2284174758/v65oai7fxn47qv9nectx.png' width='48' height='48'></a>");
            sbBody.Append("</td>");
            sbBody.Append("<td width='34%' align='left' valign='middle'>");
            sbBody.Append("<a href='https://www.youtube.com/channel/UC2y7wYad_yoKrW64ZfVpgiA'><img src='http://i451.photobucket.com/albums/qq234/Gustable_2008/youtube-logo.png' width='48' height='48'></a>");
            sbBody.Append("</td>");
            sbBody.Append("<td width='33%' align='left' valign='middle'>");
            sbBody.Append("<img src='http://cdn.slidesharecdn.com/profile-photo-linkedin-96x96.jpg' width='48' height='48'>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            sbBody.Append("</table>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            sbBody.Append("</table>");
            sbBody.Append("</td>");
            sbBody.Append("<td width='50%' align='left' valign='middle' style='color:#564319; font-size:11px; font-family:Arial, Helvetica, sans-serif; padding:10px;'>");
            //sbBody.Append("<b>Hours:</b> ");
            //sbBody.Append("Mon-Fri 9:30-5:30, Sat. 9:30-3:00, Sun. Closed <br>");
            sbBody.Append("<b>Soporte:</b>");
            sbBody.Append("<a href='mailto:carlos.yy@gmail.com' style='color:#564319; text-decoration:none;'>soporte@siisa.com.co</a>");
            sbBody.Append("<br>");
            sbBody.Append("<br>");
            sbBody.Append("<b>Página web</b>");
            sbBody.Append("<br>Dirección URL: ");
            sbBody.Append("<a href='http://www.siisa.com.co' target='_blank'  style='color:#564319; text-decoration:none;'>http://www.siisa.com.co</a>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            sbBody.Append("</table>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            //sbBody.Append("<tr>");
            //sbBody.Append("<td align='left' valign='top'>");
            //sbBody.Append("<img src='images/bot.png' width='600' height='37' style='display:block;'>");
            //sbBody.Append("</td>");
            //sbBody.Append("</tr>");
            sbBody.Append("</table>");
            sbBody.Append("<br>");
            sbBody.Append("<br>");
            sbBody.Append("</td>");
            sbBody.Append("</tr>");
            sbBody.Append("</table>");
            sbBody.Append("</body>");
            sbBody.Append("</html>");

            msg.Body = sbBody.ToString();
            msg.IsBodyHtml = true;

            if (rutaAdjunto != "")
            {
                Attachment _Attachment = new Attachment(rutaAdjunto);
                msg.Attachments.Add(_Attachment);
            }

            //   AlternateView html = new AlternateView(
            //html = AlternateView.CreateAlternateViewFromString(strBodyHTML, Nothing, "text/html")

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

            catch (Exception ex)
            {
                EmailSending = "** " + ex.Message + "\n **" + ex.StackTrace + "\n **" + ex.Source;
            }
            return EmailSending;
        }
    }
}
