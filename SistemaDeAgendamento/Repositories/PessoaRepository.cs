using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Database;

namespace SistemaDeAgendamento.Repositories
{
    public class PessoaRepository
    {
        public int Inserir(Pessoa pessoa)
        {
            using (IDbConnection db = DbConnection.Create())
                return db.ExecuteScalar<int>(@"
                    INSERT INTO clients (first_name, last_name, cpf, phone)
                    VALUES (@FirstName, @LastName, @Cpf, @Phone)
                    RETURNING id", pessoa);
        }

        public List<Pessoa> ListarTodos()
        {
            using (IDbConnection db = DbConnection.Create())
                return db.Query<Pessoa>(@"
                    SELECT id,
                           first_name AS FirstName,
                           last_name  AS LastName,
                           cpf,
                           phone
                    FROM   clients
                    ORDER  BY first_name, last_name").ToList();
        }

        public Pessoa BuscarPorId(int id)
        {
            using (IDbConnection db = DbConnection.Create())
                return db.QueryFirstOrDefault<Pessoa>(@"
                    SELECT id,
                           first_name AS FirstName,
                           last_name  AS LastName,
                           cpf,
                           phone
                    FROM   clients
                    WHERE  id = @Id", new { Id = id });
        }

        public void Editar(Pessoa pessoa)
        {
            using (IDbConnection db = DbConnection.Create())
                db.Execute(@"
                    UPDATE clients
                    SET    first_name = @FirstName,
                           last_name  = @LastName,
                           cpf        = @Cpf,
                           phone      = @Phone
                    WHERE  id = @Id", pessoa);
        }

        public void Deletar(int id)
        {
            using (IDbConnection db = DbConnection.Create())
                db.Execute("DELETE FROM clients WHERE id = @Id", new { Id = id });
        }
    }
}