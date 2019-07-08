using System;

namespace CursosResource.Domain.Entities
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Descricao { get; set; }
        public int LimiteInscritos { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int ProfessorId { get; set; }

        public bool ValidarCurso()
        {
            return true;
        }
    }
}
