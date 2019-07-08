using System.Collections.Generic;

namespace CursosResource.Application.Interfaces
{
    public interface IApplicationService<TClass> where TClass : class
    {
        IEnumerable<TClass> PesquisarTodos();
        TClass Pesquisar(int id);
        void Incluir(TClass obj);
        void Alterar(TClass obj);
        void Deletar(TClass obj);
    }
}
