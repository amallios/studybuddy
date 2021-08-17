using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyBuddyAPI.Models;

namespace StudyBuddyAPI
{
    public static class Functions
    {
        public enum EmailTemplates
        {
            Register,
            PasswordReset,
            ModuleRegistration,
            Reminder
        }

        private static StringBuilder emailBody = new StringBuilder();

        /// <summary>
        /// Send email using gmail email provided
        /// </summary>
        /// <param name="user"></param>
        /// <param name="template"></param>
        public static void SendEmail(User user, EmailTemplates template)
        {
            var fromAddress = new MailAddress("rdeswardt@gmail.com", "From StudyBuddy");
            var toAddress = new MailAddress(user.Email, $"To {user.Firstname} {user.Lastname}");
           
            const string fromPassword = "ybctdwodzekpohmt";
            const string subject = "StudyBuddy Registration";
            string body = GenerateEmailBody(user, EmailTemplates.Register);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }

        }

        /// <summary>
        /// Generate Email templates based on template type 
        /// </summary>
        /// <param name="user">User details to be used</param>
        /// <param name="template">Template Type</param>
        /// <returns></returns>
        public static string GenerateEmailBody(User user, EmailTemplates template)
        {
            emailBody.Append("<p><img src=\"https://i.imgur.com/lgt29eZ.png\" alt=\"\" /></p>");

            switch (template)
            {
                case EmailTemplates.Register:
                {
                    emailBody.Append(
                        "<p>Dear %FIRSTNAME% %LASTNAME%,&nbsp;</p>\r\n<p>Thank you for registering with Study Buddy.</p>\r\n<p><span style=\"text-decoration: underline;\"><a href=\"http://www.studybuddy.com/activate/username=%USERNAME%\" title=\"Click here\">Click here</a> </span>to reset your password using our secure server.</p>\r\n<p>If you did not register with the Study Budy, please ignore this email.</p>\r\n<p>If clicking the link doesn't seem to work, you can copy and paste the link into your browser's address window, or retype it there. After using the link, your account will be activated.&nbsp;</p>");
                }
                    break;
                default:
                {
                }
                    break;
            }

            emailBody.Replace("%FIRSTNAME%", user.Firstname);
            emailBody.Replace("%LASTNAME%", user.Lastname);
            emailBody.Replace("%USERNAME%", user.Username);

            emailBody.Append("<p>Yours truly, <br />The Study Buddy Team</p>");
            emailBody.Append("<p><br /><a href=\"http://www.studybuddy.com\">http://www.studybuddy.com</a> <br /><em>staying on track</em></p>");
         

            return emailBody.ToString();
        }

        /// <summary>
        /// SHA256 encrypted hash for userpassword to be sotred in the database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSHA256(string value)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] hashData = sha256.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder returnValue = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            return returnValue.ToString();
        }
    }
}
