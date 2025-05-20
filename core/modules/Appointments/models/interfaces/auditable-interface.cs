using System;

namespace Core.Modules.Appointments.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }

        void RegisterAudit(string user);
    }
}
