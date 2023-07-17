using AgendaTarefas.Models;
using System.Collections.Generic;

namespace AgendaTarefas.Repositorio
{
    public interface ITarefaRepositorio
    {
        TarefaModel ListarPorId(int Id);

        List<TarefaModel> BuscarTodos();

        List<ListaModel> ObterHorasDia();

        TarefaModel Adicionar(TarefaModel tarefa);

        TarefaModel Atualizar(TarefaModel tarefa);

        bool Apagar(int Id);
       
    }
}
