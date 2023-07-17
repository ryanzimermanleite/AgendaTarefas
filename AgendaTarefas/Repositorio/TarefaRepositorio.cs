using AgendaTarefas.Data;
using AgendaTarefas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AgendaTarefas.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public TarefaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public TarefaModel ListarPorId(int Id)
        {
            return _bancoContext.Tarefas.FirstOrDefault(x => x.Id == Id);   
        }

        public List<TarefaModel> BuscarTodos()
        {
            return _bancoContext.Tarefas.ToList();
        }

        public TarefaModel Adicionar(TarefaModel tarefa)
        {
            _bancoContext.Tarefas.Add(tarefa);
            _bancoContext.SaveChanges();
            return tarefa;
            // Gravar no banco de dados
        }

        public TarefaModel Atualizar(TarefaModel tarefa)
        {
            TarefaModel tarefaDB = ListarPorId(tarefa.Id);
            if (tarefaDB == null) throw new System.Exception("Houve um erro na atualização da tarefa!");

            tarefaDB.Titulo     = tarefa.Titulo;
            tarefaDB.Descricao  = tarefa.Descricao;
            tarefaDB.Data       = tarefa.Data;
            tarefaDB.Inicio     = tarefa.Inicio;
            tarefaDB.Final      = tarefa.Final;
            tarefaDB.Prioridade = tarefa.Prioridade;
            tarefaDB.Finalizada = tarefa.Finalizada;

            _bancoContext.Tarefas.Update(tarefaDB);
            _bancoContext.SaveChanges();

            return tarefaDB;
        }

        public bool Apagar(int Id)
        {
            TarefaModel tarefaDB = ListarPorId(Id);
            if (tarefaDB == null) throw new System.Exception("Houve um erro na deleção da tarefa!");

            _bancoContext.Tarefas.Remove(tarefaDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public List<ListaModel> ObterHorasDia()
        {
            return _bancoContext.Listas.ToList();
        }
    }
}
