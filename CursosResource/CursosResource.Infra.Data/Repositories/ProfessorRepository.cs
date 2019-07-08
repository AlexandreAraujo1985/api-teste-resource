using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Repositories;

namespace CursosResource.Infra.Data.Repositories
{
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
    }
}
