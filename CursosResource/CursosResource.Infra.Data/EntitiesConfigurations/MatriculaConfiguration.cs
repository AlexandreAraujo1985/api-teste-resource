using CursosResource.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CursosResource.Infra.Data.EntitiesConfigurations
{
    public class MatriculaConfiguration : EntityTypeConfiguration<Matricula>
    {
        public MatriculaConfiguration()
        {
            ToTable("tb_matriculas");

            HasKey(m => m.MatriculaId);

            HasRequired(m => m.Alunos).WithMany().HasForeignKey(m => m.AlunoId);
            HasRequired(m => m.Cursos).WithMany().HasForeignKey(m => m.CursoId);
        }
    }
}
