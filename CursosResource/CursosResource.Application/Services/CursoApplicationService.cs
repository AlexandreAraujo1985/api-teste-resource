using CursosResource.Application.Interfaces;
using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Services;

namespace CursosResource.Application.Services
{
    public class CursoApplicationService : ApplicationService<Curso>, ICursoApplication
    {
        private readonly ICursoService _cursoService;

        public CursoApplicationService(ICursoService cursoService) : base(cursoService)
        {
            _cursoService = cursoService;
        }
    }
}
