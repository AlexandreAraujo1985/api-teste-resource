using CursosResource.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CursosResource.Infra.Data.EntitiesConfigurations
{
    public class ProfessorConfiguration : EntityTypeConfiguration<Professor>
    {
        public ProfessorConfiguration()
        {
            ToTable("tb_professores");

            HasKey(p => p.ProfessorId);

            Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(100);

            HasRequired(c => c.Cursos).WithMany().HasForeignKey(c => c.CursoId);
        }
    }
}
