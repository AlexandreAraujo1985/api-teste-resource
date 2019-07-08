using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Repositories;
using CursosResource.Domain.Interfaces.Services;

namespace CursosResource.Domain.Services
{
    public class CursoService : ServiceBase<Curso>, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository) : base(cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
    }
}
