using CursosResource.Application.Interfaces;
using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Services;

namespace CursosResource.Application.Services
{
    public class ProfessorApplicationService : ApplicationService<Professor>, IProfessorApplication
    {
        private readonly IProfessorService _professorService;

        public ProfessorApplicationService(IProfessorService professorService) : base(professorService)
        {
            _professorService = professorService;
        }
    }
}
