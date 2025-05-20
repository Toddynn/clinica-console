using System;
using System.Collections.Generic;
using Core.Modules.Appointments.Models.Entities;
using Core.Modules.People.Models.Entities;

namespace Core.Modules.Appointments.UseCases
{
    public class ScheduleAppointmentUseCase
    {
        private readonly List<Appointment> _appointments;
        private readonly List<Person> _people;

        public ScheduleAppointmentUseCase(List<Appointment> appointments, List<Person> people)
        {
            _appointments = appointments;
            _people = people;
        }

        public void Execute()
        {
            Console.WriteLine("Selecione o Paciente:");
            var patients = _people.FindAll(p => p is Patient);
            for (int i = 0; i < patients.Count; i++)
            {
                var p = (Patient)patients[i];
                Console.WriteLine($"{i} - {p.Name} (Documento: {p.Document})");
            }

            if (
                !int.TryParse(Console.ReadLine(), out int patientIndex)
                || patientIndex < 0
                || patientIndex >= patients.Count
            )
            {
                Console.WriteLine("Paciente inválido.");
                return;
            }

            var patient = (Patient)patients[patientIndex];

            Console.WriteLine("Selecione o Funcionário:");
            var employees = _people.FindAll(p => p is Employee);
            for (int i = 0; i < employees.Count; i++)
            {
                var e = (Employee)employees[i];
                Console.WriteLine($"{i} - {e.Name} (Cargo: {e.Position})");
            }

            if (
                !int.TryParse(Console.ReadLine(), out int employeeIndex)
                || employeeIndex < 0
                || employeeIndex >= employees.Count
            )
            {
                Console.WriteLine("Funcionário inválido.");
                return;
            }

            var employee = (Employee)employees[employeeIndex];

            Console.Write("Data da Consulta (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Formato de data inválido.");
                return;
            }

            Console.Write("Observações: ");
            string? notes = Console.ReadLine() ?? "";

            var appointment = new Appointment(patient, employee, date, notes);
            appointment.RegisterAudit("Sistema");

            _appointments.Add(appointment);

            Console.WriteLine("Consulta agendada com sucesso!");
        }
    }
}
