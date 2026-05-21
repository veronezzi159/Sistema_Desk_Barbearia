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
            string sql = @"INSERT INTO pessoa (nome, cpf, telefone, email, data_nascimento)
                           VALUES (@Nome, @Cpf, @Telefone, @Email, @DataNascimento)
                           RETURNING id;";

            using (IDbConnection conexao =  DbConnection.Create())
            {
                return conexao.ExecuteScalar<int>(sql, pessoa);
            }
        }

        public List<Pessoa> ListarTodos()
        {
            string sql = @"SELECT id, nome, cpf, telefone, email, data_nascimento AS DataNascimento
                           FROM pessoa
                           ORDER BY nome;";

            using (IDbConnection conexao =  DbConnection.Create())
            {
                return conexao.Query<Pessoa>(sql).ToList();
            }
        }

       
        public Pessoa BuscarPorId(int id)
        {
            string sql = @"SELECT id, nome, cpf, telefone, email, data_nascimento AS DataNascimento
                           FROM pessoa
                           WHERE id = @Id;";

            using (IDbConnection conexao =  DbConnection.Create())
            {
                return conexao.QueryFirstOrDefault<Pessoa>(sql, new { Id = id });
            }
        }

       
        public void Editar(Pessoa pessoa)
        {
            string sql = @"UPDATE pessoa
                           SET nome = @Nome,
                               cpf = @Cpf,
                               telefone = @Telefone,
                               email = @Email,
                               data_nascimento = @DataNascimento
                           WHERE id = @Id;";

            using (IDbConnection conexao =  DbConnection.Create())
            {
                conexao.Execute(sql, pessoa);
            }
        }

       
        public void Deletar(int id)
        {
            string sql = "DELETE FROM pessoa WHERE id = @Id;";

            using (IDbConnection conexao =  DbConnection.Create())
            {
                conexao.Execute(sql, new { Id = id });
            }
        }
    }
}