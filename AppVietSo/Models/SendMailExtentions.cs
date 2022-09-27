using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class SendMailExtentions
    {
        public static bool SendEmail(string[] _email, string Subject, string body, string[] _cc = null)
        {
            //  return false;
             MailMessage mail = new MailMessage();

            try
            {
                foreach (var item in _email)
                {
                    try
                    {
                        if (item.Contains("@"))
                        {
                            mail.To.Add(item);
                        }
                    }
                    catch
                    {
                    }

                }
                if (mail.To.Count == 0)
                {
                    return false;
                }

                if (_cc != null)
                {
                    foreach (var item in _cc)
                    {
                        mail.CC.Add(item);
                    }
                }

                mail.From = new MailAddress("HUYCHU.work@gmail.com");
                mail.Subject = Subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("HUYCHU.work@gmail.com", "songthat");
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.Send(mail);


                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }

}