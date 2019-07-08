namespace CursosResource.Infra.Data.Migrations
{
    using CursosResource.Domain.Entities;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CursosResource.Infra.Data.Contexts.CursosResourceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CursosResource.Infra.Data.Contexts.CursosResourceContext context)
        {
            if (!context.Cursos.Any(c => c.CursoId > 0))
            {
                context.Cursos.Add(new Curso { Descricao = "C Sharp", DataInicio = DateTime.Now, DataFim = Convert.ToDateTime("31/07/2019"), ProfessorId = 1, LimiteInscritos = 30 });
                context.Cursos.Add(new Curso { Descricao = "Java", DataInicio = DateTime.Now, DataFim = Convert.ToDateTime("31/07/2019"), ProfessorId = 2, LimiteInscritos = 60 });
            }
            if (!context.Professores.Any(c => c.CursoId > 0))
            {
                context.Professores.Add(new Professor { Nome = "Anders Hejlsberg", CursoId = 1 });
                context.Professores.Add(new Professor { Nome = "James Gosling", CursoId = 2 });
            }
        }
    }
}
