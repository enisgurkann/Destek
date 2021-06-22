using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Destek
{
    public class MailHelper : IDisposable
    {

        public class AuthCredential
        {
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string smtpadres { get; set; }
            public int port { get; set; }
            public bool IsSSL { get; set; }
        }
        public class Mesaj
        {
            public string toMail { get; set; }
            public string toSubject { get; set; }
            public string toBody { get; set; }
            public bool IsHtml { get; set; }
        }
        public bool SendMail(Mesaj isMessage, AuthCredential isAuth)
        {
            try
            {

                SmtpClient client = new SmtpClient()
                {
                    Host = isAuth.smtpadres,
                    Port = isAuth.port,
                    UseDefaultCredentials = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = isAuth.IsSSL,
                    Credentials = new NetworkCredential(isAuth.username, isAuth.password)
                };
                MailMessage Message = new MailMessage(isAuth.email, isMessage.toMail)
                {
                    Body = isMessage.toBody,
                    Subject = isMessage.toSubject,
                    IsBodyHtml = isMessage.IsHtml,
                    BodyEncoding = System.Text.Encoding.GetEncoding("windows-1254")
                };

                client.Send(Message);
            }
            catch (Exception ex)
            {
              
            }
            return true;
        }


        public bool MailGonder(Mesaj isMessage)
        {
            MailHelper.AuthCredential auth = new MailHelper.AuthCredential();
            auth.email = "";
            auth.password = "";
            auth.smtpadres = "";
            auth.username = "";
            auth.IsSSL = false;
            auth.port = 587;
            return SendMail(isMessage, auth);
        }
        public void Dispose()
        {

        }
    }
}