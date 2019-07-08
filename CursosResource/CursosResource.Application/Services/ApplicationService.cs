using CursosResource.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace CursosResource.Application.Services
{
    public class ApplicationService<TClass> where TClass : class
    {
        private readonly IServiceBase<TClass> _serviceBase;

        public ApplicationService(IServiceBase<TClass> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Alterar(TClass obj)
        {
            _serviceBase.Alterar(obj);
        }

        public void Deletar(TClass obj)
        {
            _serviceBase.Deletar(obj);
        }

        public void Incluir(TClass obj)
        {
            _serviceBase.Incluir(obj);
        }

        public TClass Pesquisar(int id)
        {
            return _serviceBase.Pesquisar(id);
        }

        public IEnumerable<TClass> PesquisarTodos()
        {
            return _serviceBase.PesquisarTodos();
        }
    }
}
