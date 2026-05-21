using System;

namespace SistemaDeAgendamento.Models
{
    public class Pessoa
    {
        
        public int Id { get; set; }

       
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public Pessoa()
        {
        }

        public override string ToString()
        {
            return $"{Nome} - CPF: {Cpf}";
        }
    }
}