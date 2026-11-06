using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarefasApi.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Concluida { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        
    }
}