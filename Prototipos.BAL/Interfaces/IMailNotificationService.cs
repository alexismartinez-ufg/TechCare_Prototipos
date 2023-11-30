using Prototipos.DAL.Models;

namespace Prototipos.BAL.Interfaces
{
    public interface IMailNotificationService
    {
        Task<bool> NotifyNewReparacion(BalMailMessage model);
    }
}
