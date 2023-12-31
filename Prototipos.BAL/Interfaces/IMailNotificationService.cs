﻿using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace Prototipos.BAL.Interfaces
{
    public interface IMailNotificationService
    {
        Task<bool> NotifyReserva(ReservaViewModel model);
    }
}
