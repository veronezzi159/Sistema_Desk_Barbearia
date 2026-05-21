using System;
using System.Collections.Generic;

namespace SistemaDeAgendamento.Models
{
    public class Barbeiro
    {
        
        public int Id { get; set; }

       
        public string Nome { get; set; }

       
        public string Cpf { get; set; }

        
        public string Telefone { get; set; }

       
        public DateTime DataAdmissao { get; set; }

        
        public bool Ativo { get; set; }

        
        public List<Especialidade> Especialidades { get; set; }

        public Barbeiro()
        {
            
            Especialidades = new List<Especialidade>();
            Ativo = true;
        }

        public override string ToString()
        {
            string status = Ativo ? "Ativo" : "Inativo";
            return $"{Nome} ({status}) - {Especialidades.Count} especialidade(s)";
        }
    }
}