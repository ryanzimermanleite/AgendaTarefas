using System;
using System.ComponentModel.DataAnnotations;
namespace AgendaTarefas.Models
{
    public class ListaModel
    {
        public DateTime DataHr { get; set; }
        public string DiferencaHr { get; set; }

        public int TotalTarefas { get; set; }

        public string Media { get; set; }

        public int TotalFinalizadas { get; set; }

        public string Percentual { get; set; }
    }
}
