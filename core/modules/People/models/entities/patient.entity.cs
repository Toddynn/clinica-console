using System;

namespace Core.Modules.People.Models.Entities
{
    public class Patient : Person
    {
        public string HealthInsurance { get; set; }

        public Patient(string name, string document, DateTime birthDate, string healthInsurance)
            : base(name, document, birthDate)
        {
            HealthInsurance = healthInsurance;
        }

        public void ScheduleAppointment()
        {
            Console.WriteLine($"{Name} está agendando uma consulta.");
        }
    }
}
