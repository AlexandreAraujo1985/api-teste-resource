using System.Collections.Generic;

namespace CursosResource.Domain.Entities
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public int CursoId { get; set; }

        public bool ValidarProfessor()
        {
            return true;
        }
    }
}
