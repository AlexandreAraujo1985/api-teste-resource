using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Repositories;
using CursosResource.Domain.Interfaces.Services;

namespace CursosResource.Domain.Services
{
    public class ProfessorService : ServiceBase<Professor>, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository) : base(professorRepository)
        {
            _professorRepository = professorRepository;
        }
    }
}
