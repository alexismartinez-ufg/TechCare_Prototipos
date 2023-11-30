using Prototipos.BAL.Interfaces;
using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Prototipos.BAL.Services
{
    public class MailNotificationService : IMailNotificationService
    {
        public MailNotificationService() 
        {

        }

        public async Task<bool> NotifyReserva(ReservaViewModel model)
        {
            var senderModel = new BalMailMessage()
            {
                SendTo = model.Correo,
                Title = "Reserva exitosa.",
                HTMLContent = model.NotificationContent
            };

            return SendMail(senderModel);
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

            return true;
        }
    }
}
