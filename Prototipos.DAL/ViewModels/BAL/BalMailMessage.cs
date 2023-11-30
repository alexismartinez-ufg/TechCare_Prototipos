namespace Prototipos.DAL.Models
{
    public class BalMailMessage
    {
        public string SmtpCliente { get; set; } = "smtp.office365.com";
        public string UserSender { get; set; } = "";
        public string UserPass { get; set; } = "";
        public string SendTo { get; set; }
        public string Title { get; set; }
        public string HTMLContent { get; set; }
    }
}
