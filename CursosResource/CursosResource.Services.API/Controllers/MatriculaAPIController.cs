using CursosResource.Application.Interfaces;
using CursosResource.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CursosResource.Services.API.Controllers
{
    [RoutePrefix("api/alunoMatricula")]
    public class MatriculaAPIController : ApiController
    {
        private readonly IMatriculaApplication _matriculaApplication;

        public MatriculaAPIController(IMatriculaApplication matriculaApplication)
        {
            _matriculaApplication = matriculaApplication;
        }

        [HttpPost]
        [Route("matricularAluno/{descricaoCurso}")]
        public HttpResponseMessage MatricularAluno([FromBody] Matricula matricula, string descricaoCurso)
        {
            try
            {
                var retono = _matriculaApplication.InscrisaoAlunoCurso(matricula, descricaoCurso);

                if (retono == "Matrícula realizada com sucesso")
                    return Request.CreateResponse(HttpStatusCode.Created, new { mensagem = $"Aluno - inscrito com sucesso no curso {descricaoCurso}" });

                else if (retono == $"Limite de Matrículas Execidos para o Curso {descricaoCurso}")
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { mensagem = retono });

                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { mensagem = $"Curso {descricaoCurso} não encontrado" });

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Erro ao realizar inscrição" });
            }
        }

        [HttpPost]
        [Route("matricularAlunoAsync/{descricaoCurso}")]
        public async Task<HttpResponseMessage> MatricularAlunoAsync([FromBody] Matricula matricula, string descricaoCurso)
        {
            try
            {
                var retono = await _matriculaApplication.InscrisaoAlunoCursoAsync(matricula, descricaoCurso);

                if (retono == "Matrícula realizada com sucesso")
                    return Request.CreateResponse(HttpStatusCode.Created, new { mensagem = $"Aluno - inscrito com sucesso no curso {descricaoCurso}" });

                else if (retono == $"Limite de Matrículas Execidos para o Curso {descricaoCurso}")
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { mensagem = retono });

                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { mensagem = $"Curso {descricaoCurso} não encontrado" });

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Erro ao realizar inscrição" });
            }
        }
    }
}
