using System;
using System.Collections.Generic;

namespace SistemaDeAgendamento.Models
{
    public class Barbeiro
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() => FullName;
    }
}