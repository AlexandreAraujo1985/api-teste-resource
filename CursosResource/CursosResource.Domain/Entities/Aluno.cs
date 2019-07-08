using System;

namespace CursosResource.Domain.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataIncricao { get; set; }
    }
}
