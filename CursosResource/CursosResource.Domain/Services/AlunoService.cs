using System.Threading.Tasks;
using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Repositories;
using CursosResource.Domain.Interfaces.Services;

namespace CursosResource.Domain.Services
{
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository) : base(alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public int IncluirAluno(Aluno aluno)
        {
            _alunoRepository.IncluirAluno(aluno);
            return aluno.AlunoId;
        }

        public async Task<int> IncluirAlunoAsync(Aluno aluno)
        {
            await _alunoRepository.IncluirAlunoAsync(aluno);
            return aluno.AlunoId;
        }
    }
}
