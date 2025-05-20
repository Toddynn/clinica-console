using System;

namespace Core.Modules.People.Models.Entities
{
    public class Employee : Person
    {
        public string Position { get; set; }

        public Employee(string name, string document, DateTime birthDate, string position)
            : base(name, document, birthDate)
        {
            Position = position;
        }

        public void PerformAttendance()
        {
            Console.WriteLine($"{Name} está realizando atendimento.");
        }
    }
}
