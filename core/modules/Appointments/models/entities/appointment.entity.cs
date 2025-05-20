using System;
using Core.Modules.Appointments.Interfaces;
using Core.Modules.People.Models.Entities;

namespace Core.Modules.Appointments.Models.Entities
{
    public class Appointment : IAuditable
    {
        public Patient Patient { get; set; }
        public Employee Employee { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public Appointment(Patient patient, Employee employee, DateTime scheduledAt, string notes)
        {
            Patient = patient;
            Employee = employee;
            ScheduledAt = scheduledAt;
            Notes = notes;
        }

        public void RegisterAudit(string user)
        {
            CreatedAt = DateTime.Now;
            CreatedBy = user;
        }
    }
}
