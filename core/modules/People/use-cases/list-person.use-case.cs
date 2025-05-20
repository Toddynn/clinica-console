using System;
using System.Collections.Generic;
using Core.Modules.People.Models.Entities;

namespace Core.Modules.People.UseCases
{
    public class ListPersonUseCase
    {
        private readonly List<Person> _person;

        public ListPersonUseCase(List<Person> person)
        {
            _person = person;
        }

        public void Execute()
        {
            if (_person.Count == 0)
            {
                Console.WriteLine("Nenhuma pessoa cadastrada.");
                return;
            }

            Console.WriteLine("Lista de Pessoas:");

            for (int i = 0; i < _person.Count; i++)
            {
                var person = _person[i];
                Console.Write($"{i} - ");

                if (person is Patient patient)
                {
                    Console.WriteLine(
                        $"Paciente: {patient.Name}, Documento: {patient.Document}, Convênio: {patient.HealthInsurance}"
                    );
                }
                else if (person is Employee employee)
                {
                    Console.WriteLine(
                        $"Funcionário: {employee.Name}, Documento: {employee.Document}, Cargo: {employee.Position}"
                    );
                }
                else
                {
                    Console.WriteLine($"Pessoa: {person.Name}, Documento: {person.Document}");
                }
            }
        }
    }
}
