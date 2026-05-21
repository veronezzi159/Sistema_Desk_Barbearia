using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Database;

namespace SistemaDeAgendamento.Repositories
{
    
    public class BarbeiroRepository
    {
        
        public int Inserir(Barbeiro barbeiro)
        {
            using (IDbConnection conexao = DbConnection.Create())
            {
                conexao.Open();
                using (IDbTransaction transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        string sqlBarbeiro =
                            @"INSERT INTO barbeiro (nome, cpf, telefone, data_admissao, ativo)
                              VALUES (@Nome, @Cpf, @Telefone, @DataAdmissao, @Ativo)
                              RETURNING id;";

                        int idBarbeiro = conexao.ExecuteScalar<int>(sqlBarbeiro, barbeiro, transacao);

                        foreach (Especialidade esp in barbeiro.Especialidades)
                        {
                            esp.BarbeiroId = idBarbeiro;
                            InserirEspecialidade(conexao, transacao, esp);
                        }

                        transacao.Commit();
                        return idBarbeiro;
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }

       
        public List<Barbeiro> ListarTodos()
        {
            string sqlBarbeiros =
                @"SELECT id, nome, cpf, telefone, data_admissao AS DataAdmissao, ativo AS Ativo
                  FROM barbeiro
                  ORDER BY nome;";

            using (IDbConnection conexao = DbConnection.Create())
            {
                List<Barbeiro> barbeiros = conexao.Query<Barbeiro>(sqlBarbeiros).ToList();

                foreach (Barbeiro b in barbeiros)
                {
                    b.Especialidades = ListarEspecialidadesPorBarbeiro(b.Id);
                }

                return barbeiros;
            }
        }

        
        public Barbeiro BuscarPorId(int id)
        {
            string sql =
                @"SELECT id, nome, cpf, telefone, data_admissao AS DataAdmissao, ativo AS Ativo
                  FROM barbeiro
                  WHERE id = @Id;";

            using (IDbConnection conexao = DbConnection.Create())
            {
                Barbeiro barbeiro = conexao.QueryFirstOrDefault<Barbeiro>(sql, new { Id = id });
                if (barbeiro != null)
                {
                    barbeiro.Especialidades = ListarEspecialidadesPorBarbeiro(id);
                }
                return barbeiro;
            }
        }

        
        public void Editar(Barbeiro barbeiro)
        {
            string sql =
                @"UPDATE barbeiro
                  SET nome = @Nome,
                      cpf = @Cpf,
                      telefone = @Telefone,
                      data_admissao = @DataAdmissao,
                      ativo = @Ativo
                  WHERE id = @Id;";

            using (IDbConnection conexao = DbConnection.Create())
            {
                conexao.Execute(sql, barbeiro);
            }
        }

        
        public void Deletar(int id)
        {
            string sql = "DELETE FROM barbeiro WHERE id = @Id;";

            using (IDbConnection conexao = DbConnection.Create())
            {
                conexao.Execute(sql, new { Id = id });
            }
        }

        public List<Especialidade> ListarEspecialidadesPorBarbeiro(int barbeiroId)
        {
            string sql =
                @"SELECT id, nome, barbeiro_id AS BarbeiroId
                  FROM especialidade
                  WHERE barbeiro_id = @BarbeiroId
                  ORDER BY nome;";

            using (IDbConnection conexao = DbConnection.Create())
            {
                return conexao.Query<Especialidade>(sql, new { BarbeiroId = barbeiroId }).ToList();
            }
        }

       
        public int AdicionarEspecialidade(Especialidade especialidade)
        {
            using (IDbConnection conexao = DbConnection.Create())
            {
                return InserirEspecialidade(conexao, null, especialidade);
            }
        }

       
        public void RemoverEspecialidade(int especialidadeId)
        {
            string sql = "DELETE FROM especialidade WHERE id = @Id;";

            using (IDbConnection conexao = ConexaoBanco.Create())
            {
                conexao.Execute(sql, new { Id = especialidadeId });
            }
        }

        private int InserirEspecialidade(IDbConnection conexao, IDbTransaction transacao, Especialidade esp)
        {
            string sql =
                @"INSERT INTO especialidade (nome, barbeiro_id)
                  VALUES (@Nome, @BarbeiroId)
                  RETURNING id;";

            return conexao.ExecuteScalar<int>(sql, esp, transacao);
        }
    }
}