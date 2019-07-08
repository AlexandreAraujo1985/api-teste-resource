using CursosResource.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CursosResource.Infra.Data.EntitiesConfigurations
{
    public class CursoConfiguration : EntityTypeConfiguration<Curso>
    {
        public CursoConfiguration()
        {
            ToTable("tb_cursos");

            HasKey(c => c.CursoId);

            Property(c => c.Descricao).HasColumnType("varchar").HasMaxLength(150);
        }
    }
}
