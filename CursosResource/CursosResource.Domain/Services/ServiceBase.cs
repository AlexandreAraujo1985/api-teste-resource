using CursosResource.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace CursosResource.Domain.Services
{
    public class ServiceBase<TClass> where TClass : class
    {
        private readonly IRepositoryBase<TClass> _repositoryBase;

        public ServiceBase(IRepositoryBase<TClass> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public IEnumerable<TClass> PesquisarTodos()
        {
            return _repositoryBase.PesquisarTodos();
        }

        public TClass Pesquisar(int id)
        {
            return _repositoryBase.Pesquisar(id);
        }

        public void Alterar(TClass obj)
        {
            _repositoryBase.Alterar(obj);
        }

        public void Deletar(TClass obj)
        {
            _repositoryBase.Deletar(obj);
        }

        public void Incluir(TClass obj)
        {
            _repositoryBase.Incluir(obj);
        }
    }
}
