using System.Net;
using System.Net.Mail;

namespace DormitoryManagement.Utils
{


    public static class MailUtil
    {

        public static void SendVerificationEmail(string token, string email)
        {
            SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);
            string _senderEmail = "quizzeroproject@gmail.com";
            string _senderPassword = "dytmgttusivorrvq";
            string _verificationBaseUrl = "https://localhost:7281";
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);

            string verificationLink = _verificationBaseUrl + "/Account/RegisterVerify?tokenCode=" + token + "&mail=" + email ;
            var mailMessage = new MailMessage(_senderEmail, email);
            mailMessage.Subject = "Email Verification for " + email;
            mailMessage.Body = $"Please click the following link to verify your email address: <a href='{verificationLink}'>Here</a>";
            mailMessage.IsBodyHtml = true;
            _smtpClient.Send(mailMessage);
        }
    }
}
