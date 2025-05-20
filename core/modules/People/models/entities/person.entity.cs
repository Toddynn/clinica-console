using System;

namespace Core.Modules.People.Models.Entities
{
    public abstract class Person
    {
        private string _name;
        private string _document;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome inválido.");
                _name = value;
            }
        }

        public string Document
        {
            get => _document;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Documento inválido.");
                _document = value;
            }
        }

        public DateTime BirthDate { get; set; }

        protected Person(string name, string document, DateTime birthDate)
        {
            Name = name;
            Document = document;
            BirthDate = birthDate;
        }
    }
}
