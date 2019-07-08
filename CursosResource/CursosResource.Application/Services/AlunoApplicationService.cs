using System.Threading.Tasks;
using CursosResource.Application.Interfaces;
using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Services;

namespace CursosResource.Application.Services
{
    public class AlunoApplicationService : ApplicationService<Aluno>, IAlunoApplication
    {
        private readonly IAlunoService _alunoService;

        public AlunoApplicationService(IAlunoService alunoService) : base(alunoService)
        {
            _alunoService = alunoService;
        }

        public int IncluirAluno(Aluno aluno)
        {
            _alunoService.IncluirAluno(aluno);
            return aluno.AlunoId;
        }

        public async Task<int> IncluirAlunoAsync(Aluno aluno)
        {
            await _alunoService.IncluirAlunoAsync(aluno);
            return aluno.AlunoId;
        }
    }
}
