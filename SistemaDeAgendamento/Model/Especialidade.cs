using System;

namespace SistemaDeAgendamento.Models
{
    
    public class Especialidade
    {
        
        public int Id { get; set; }

        public string Nome { get; set; }

        
        public int BarbeiroId { get; set; }

        public Especialidade()
        {
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}