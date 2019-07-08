using CursosResource.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CursosResource.Infra.Data.EntitiesConfigurations
{
    public class AlunoConfiguration : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguration()
        {
            ToTable("tb_alunos");

            HasKey(a => a.AlunoId);

            Property(a => a.Nome).HasColumnType("varchar").HasMaxLength(100);
        }
    }
}
