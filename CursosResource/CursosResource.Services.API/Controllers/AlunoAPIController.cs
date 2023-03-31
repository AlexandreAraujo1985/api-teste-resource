using CursosResource.Application.Interfaces;
using CursosResource.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CursosResource.Services.API.Controllers
{
    [RoutePrefix("api/aluno")]
    public class AlunoAPIController : ApiController
    {
        private readonly IAlunoApplication _alunoApplication;

        public AlunoAPIController(IAlunoApplication alunoApplication)
        {
            _alunoApplication = alunoApplication;
        }

        [HttpPost]
        [Route("incluirAluno/{descricaoCurso}")]
        public HttpResponseMessage InscrisaoAlunoCurso([FromBody] Aluno aluno, string descricaoCurso)
        {
            try
            {
                if (string.IsNullOrEmpty(aluno.Nome) || aluno.Idade <= 17)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { mensagem = "Favor verifique se o nome digitado está correto ou a idade esta dentro para permitido para este curso" });

                var alunoId = _alunoApplication.IncluirAluno(aluno);
                var client = new HttpClient();
                var matricula = new Matricula { AlunoId = alunoId };

                client.BaseAddress = new Uri("http://localhost:50187/");

                return client.PostAsJsonAsync($"api/alunoMatricula/matricularAluno/{descricaoCurso}", matricula).Result;

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Erro ao realizar inscrição" });
            }
        }

        [HttpPost]
        [Route("incluirAlunoAsync/{descricaoCurso}")]
        public async Task<HttpResponseMessage> InscrisaoAlunoCursoAsync([FromBody] Aluno aluno, string descricaoCurso)
        {
            try
            {
                var teste = "a";
                if (string.IsNullOrEmpty(aluno.Nome) || aluno.Idade < 17)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { mensagem = "Favor verifique se o nome digitado está correto ou a idade esta dentro para permitido para este curso" });

                var alunoId = await _alunoApplication.IncluirAlunoAsync(aluno);

                var client = new HttpClient();
                var matricula = new Matricula { AlunoId = alunoId };
                client.BaseAddress = new Uri("http://localhost:50187/");

                return client.PostAsJsonAsync($"api/alunoMatricula/matricularAlunoAsync/{descricaoCurso}", matricula).Result;
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Erro ao realizar inscrição" });
            }
        }
    }
}
