using CursosResource.Application.Interfaces;
using CursosResource.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CursosResource.Services.API.Controllers
{
    //Para fins de análise, a empresa precisa conhecer a idade mínima, a
    //idade máxima e idade média dos alunos que se inscreveram em cada curso.
    //Considere que isso precisa continuar trabalhando de forma eficiente quando houver milhões
    //de inscrições por dia: calcular essa informação a cada solicitação é inviável.

    //- GET list: que retorna uma lista com as informações acima para cada curso, mais
    //a capacidade total do curso e o número atual de alunos
    //- GET detalhes: que retorna as informações acima para um único curso, mais
    //o professor e a lista de alunos matriculados

    [RoutePrefix("api/curso")]
    public class CursoAPIController : ApiController
    {
        private readonly ICursoApplication _cursoApplication;

        public CursoAPIController(ICursoApplication cursoApplication)
        {
            _cursoApplication = cursoApplication;
        }

        [HttpGet]
        [Route("listarAlunosMatriculadosPorCurso")]
        public HttpResponseMessage ListarAlunosMatriculadosPorCurso(string curso)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { mensagem = $"Aluno - cadastrado com sucesso!" });
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { mensagem = $"Aluno - cadastrado com sucesso!" });
            }
        }

        [HttpGet]
        [Route("listarAlunosMatriculadosEmTodosCursos")]
        public HttpResponseMessage ListarAlunosMatriculadosEmTodosCursos()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { mensagem = $"Aluno - cadastrado com sucesso!" });
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { mensagem = $"Aluno - cadastrado com sucesso!" });
            }
        }
    }
}
