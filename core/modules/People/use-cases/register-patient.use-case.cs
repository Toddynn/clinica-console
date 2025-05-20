using System;
using System.Collections.Generic;
using Core.Modules.People.Models.Entities;

namespace Core.Modules.People.UseCases
{
    public class RegisterPatientUseCase
    {
        private readonly List<Person> _people;

        public RegisterPatientUseCase(List<Person> people)
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
                if (existing is Patient)
                {
                    Console.WriteLine("Este documento já está cadastrado como paciente.");
                    return;
                }

                if (existing is Employee)
                {
                    Console.WriteLine("Este documento pertence a um funcionário.");
                    Console.Write("Deseja cadastrar também como paciente? (s/n): ");
                    var option = Console.ReadLine()?.ToLower();

                    if (option != "s")
                    {
                        Console.WriteLine("Cadastro cancelado.");
                        return;
                    }

                    Console.Write("Convênio: ");
                    string? insurance = Console.ReadLine() ?? "";

                    var employee = (Employee)existing;
                    var patient = new Patient(
                        employee.Name,
                        employee.Document,
                        employee.BirthDate,
                        insurance
                    );

                    _people.Remove(employee);
                    _people.Add(patient);

                    Console.WriteLine("Funcionário promovido também a paciente!");
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

            Console.Write("Convênio: ");
            string? insuranceNew = Console.ReadLine() ?? "";

            var newPatient = new Patient(name, document, birthDate, insuranceNew);
            _people.Add(newPatient);

            Console.WriteLine("Paciente cadastrado com sucesso!");
        }
    }
}
