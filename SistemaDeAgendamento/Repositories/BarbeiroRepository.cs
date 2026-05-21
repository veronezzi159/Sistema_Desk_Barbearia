using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Database;

namespace SistemaDeAgendamento.Repositories
{
    
    public class BarbeiroDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public override string ToString() => FullName;
    }

    public class BarbeiroRepository
    {
        public List<BarbeiroDto> ListarTodos()
        {
            using (IDbConnection db = DbConnection.Create())
                return db.Query<BarbeiroDto>(@"
                SELECT id, first_name AS FirstName, last_name AS LastName,
                        cpf, phone
                FROM   barbers
                ORDER  BY first_name, last_name").ToList();
        }

        public int Inserir(BarbeiroDto barbeiro)
        {
            using (IDbConnection db = DbConnection.Create())
                return db.ExecuteScalar<int>(@"
                INSERT INTO barbers (first_name, last_name, cpf, phone)
                VALUES (@FirstName, @LastName, @Cpf, @Phone)
                RETURNING id", barbeiro);
        }

        public void Editar(BarbeiroDto barbeiro)
        {
            using (IDbConnection db = DbConnection.Create())
                db.Execute(@"
                UPDATE barbers
                SET    first_name = @FirstName,
                        last_name  = @LastName,
                        cpf        = @Cpf,
                        phone      = @Phone
                WHERE  id = @Id", barbeiro);
        }

        public void Deletar(int id)
        {
            using (IDbConnection db = DbConnection.Create())
                db.Execute("DELETE FROM barbers WHERE id = @Id", new { Id = id });
        }
    }
}