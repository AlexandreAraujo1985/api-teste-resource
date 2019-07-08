using System.Collections.Generic;

namespace CursosResource.Domain.Entities
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
    }
}
