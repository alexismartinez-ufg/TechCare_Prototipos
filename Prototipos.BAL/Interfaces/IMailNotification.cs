using Prototipos.DAL.Models;

namespace Prototipos.BAL.Interfaces
{
    public interface IMailNotification
    {
        Task<bool> NotifyNewReparacion(BalMailMessage model);
    }
}
