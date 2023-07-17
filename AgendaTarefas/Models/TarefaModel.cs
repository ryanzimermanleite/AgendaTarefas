using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace AgendaTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o titulo da tarefa!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Digite a descrição da tarefa!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite a data da tarefa!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Digite o horario de inicio da tarefa!")]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage = "Digite o horario de final da tarefa!")]
        public DateTime Final { get; set; }

        [Required(ErrorMessage = "--------------------------- Escolha a prioridade da tarefa!")]
        public string Prioridade { get; set; }

        [Required(ErrorMessage = "--------------------------- Escolha se a tarefa está finalizada ou não!")]
        public string Finalizada { get; set; }

    }
}
