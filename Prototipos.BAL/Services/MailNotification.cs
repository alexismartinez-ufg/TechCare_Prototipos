﻿using Prototipos.BAL.Interfaces;
using Prototipos.DAL.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Prototipos.BAL.Services
{
    public class MailNotification : IMailNotification
    {
        public MailNotification() 
        {

        }

        public async Task<bool> NotifyNewReparacion(BalMailMessage model)
        {
            return SendMail(model);
        }

        public bool SendMail(BalMailMessage senderModel)
        {
            SmtpClient smtpClient = new SmtpClient(senderModel.SmtpCliente);
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderModel.UserSender, senderModel.UserPass);
            smtpClient.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderModel.UserSender);
            mailMessage.To.Add(senderModel.SendTo);
            mailMessage.Subject = senderModel.Title;

            mailMessage.Body = senderModel.HTMLContent;
            mailMessage.IsBodyHtml = true;

            // Adjuntar la imagen
            string pathToImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Img\\imagen.png");
            var existe = File.Exists(pathToImage);
            Attachment inlineImage = new Attachment(pathToImage);
            inlineImage.ContentDisposition.Inline = true;
            inlineImage.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
            inlineImage.ContentId = "imagen.png";
            mailMessage.Attachments.Add(inlineImage);

            try
            {
                // Envío del correo
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);

                return false;
            }
            finally
            {
                // Limpiar recursos
                inlineImage.Dispose();
            }

            return true;
        }
    }
}
