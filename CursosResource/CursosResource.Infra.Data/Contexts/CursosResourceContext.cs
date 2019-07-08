using CursosResource.Domain.Entities;
using CursosResource.Infra.Data.EntitiesConfigurations;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace CursosResource.Infra.Data.Contexts
{
    public class CursosResourceContext : DbContext
    {
        public CursosResourceContext()
            : base("ConexaoCursosResource")
        {

        }

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());
            modelBuilder.Conventions.Remove(new OneToManyCascadeDeleteConvention());
            modelBuilder.Conventions.Remove(new ManyToManyCascadeDeleteConvention());

            modelBuilder.Configurations.Add(new ProfessorConfiguration());
            modelBuilder.Configurations.Add(new CursoConfiguration());
            modelBuilder.Configurations.Add(new AlunoConfiguration());
            modelBuilder.Configurations.Add(new MatriculaConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var obj in ChangeTracker.Entries().Where(obj => obj.Entity.GetType().GetProperty("DataIncricao") != null))
            {
                if (obj.State == EntityState.Added)
                {
                    obj.Property("DataIncricao").CurrentValue = DateTime.Now;
                }

                if (obj.State == EntityState.Modified)
                {
                    obj.Property("DataIncricao").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
