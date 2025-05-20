using System;
using System.Collections.Generic;
using Core.Modules.People.Models.Entities;

namespace Core.Modules.People.UseCases
{
    public class RegisterEmployeeUseCase
    {
        private readonly List<Person> _people;

        public RegisterEmployeeUseCase(List<Person> people)
        {
            _people = people;
        }

        public void Execute()
        {
            Console.Write("Documento: ");
            string? document = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(document))
            {
                Console.WriteLine("Documento inválido.");
                return;
            }

            var existing = _people.Find(p => p.Document == document);

            if (existing != null)
            {
                if (existing is Employee)
                {
                    Console.WriteLine("Este documento já está cadastrado como funcionário.");
                    return;
                }

                if (existing is Patient)
                {
                    Console.WriteLine("Este documento pertence a um paciente.");
                    Console.Write("Deseja cadastrar também como funcionário? (s/n): ");
                    var option = Console.ReadLine()?.ToLower();

                    if (option != "s")
                    {
                        Console.WriteLine("Cadastro cancelado.");
                        return;
                    }

                    Console.Write("Cargo: ");
                    string? position = Console.ReadLine() ?? "";

                    // Criar novo funcionário com os dados do paciente
                    var patient = (Patient)existing;
                    var employee = new Employee(
                        patient.Name,
                        patient.Document,
                        patient.BirthDate,
                        position
                    );

                    _people.Remove(patient);
                    _people.Add(employee);

                    Console.WriteLine("Paciente promovido também a funcionário!");
                    return;
                }
            }

            Console.Write("Nome: ");
            string? name = Console.ReadLine() ?? "";

            DateTime birthDate;
            while (true)
            {
                Console.Write("Data de Nascimento (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    break;
                Console.WriteLine("Formato inválido.");
            }

            Console.Write("Cargo: ");
            string? role = Console.ReadLine() ?? "";

            var newEmployee = new Employee(name, document, birthDate, role);
            _people.Add(newEmployee);

            Console.WriteLine("Funcionário cadastrado com sucesso!");
        }
    }
}
