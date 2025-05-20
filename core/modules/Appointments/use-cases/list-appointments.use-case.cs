using System;
using System.Collections.Generic;
using Core.Modules.Appointments.Models.Entities;

namespace Core.Modules.Appointments.UseCases
{
    public class ListAppointmentsUseCase
    {
        private readonly List<Appointment> _appointments;

        public ListAppointmentsUseCase(List<Appointment> appointments)
        {
            _appointments = appointments;
        }

        public void Execute()
        {
            Console.WriteLine("Consultas Agendadas:");

            if (_appointments.Count == 0)
            {
                Console.WriteLine("Nenhuma consulta agendada.");
                return;
            }

            foreach (var app in _appointments)
            {
                Console.WriteLine(
                    $"- Paciente: {app.Patient.Name}, Funcionário: {app.Employee.Name}, "
                        + $"Data: {app.ScheduledAt}, Observações: {app.Notes}"
                );
            }
        }
    }
}
