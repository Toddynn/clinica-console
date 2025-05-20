using System;
using System.Collections.Generic;
using Core.Modules.Appointments.Models.Entities;
using Core.Modules.Appointments.UseCases;
using Core.Modules.People.Models.Entities;
using Core.Modules.People.UseCases;

namespace App.ConsoleUI
{
    class Program
    {
        static List<Person> people = new();
        static List<Appointment> appointments = new();

        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Clínica Médica ===\n");
                Console.WriteLine("1. Cadastrar Paciente");
                Console.WriteLine("2. Cadastrar Funcionário");
                Console.WriteLine("3. Agendar Consulta");
                Console.WriteLine("4. Listar Pessoas");
                Console.WriteLine("5. Listar Consultas");
                Console.WriteLine("0. Sair\n");
                Console.Write("Escolha uma opção: ");
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        new RegisterPatientUseCase(people).Execute();
                        break;
                    case 2:
                        new RegisterEmployeeUseCase(people).Execute();
                        break;
                    case 3:
                        new ScheduleAppointmentUseCase(appointments, people).Execute();
                        break;
                    case 4:
                        new ListPersonUseCase(people).Execute();
                        break;
                    case 5:
                        new ListAppointmentsUseCase(appointments).Execute();
                        break;
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            } while (option != 0);
        }
    }
}
