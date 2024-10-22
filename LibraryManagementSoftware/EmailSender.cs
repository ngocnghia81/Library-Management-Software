﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSoftware
{
    internal class EmailSender
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly bool _enableSsl;
        private readonly string _fromEmail;
        private readonly string _fromPassword;

        public EmailSender(string smtpHost, int smtpPort, bool enableSsl, string fromEmail, string fromPassword)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _enableSsl = enableSsl;
            _fromEmail = fromEmail;
            _fromPassword = fromPassword;
        }

        public bool SendEmail(string toEmail, string subject, string body, bool isBodyHtml = false)
        {
            try
            {
                var fromAddress = new MailAddress(_fromEmail);
                var toAddress = new MailAddress(toEmail);

                var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHtml 
                };

                using (var smtp = new SmtpClient
                {
                    Host = _smtpHost,
                    Port = _smtpPort,
                    EnableSsl = _enableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_fromEmail, _fromPassword)
                })
                {
                    smtp.Send(mailMessage); 
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false; 
            }
        }

    }
}
