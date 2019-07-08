using CursosResource.Domain.Interfaces.Repositories;
using CursosResource.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CursosResource.Infra.Data.Repositories
{
    public class RepositoryBase<TClass> : IDisposable, IRepositoryBase<TClass> where TClass : class
    {
        protected CursosResourceContext db = new CursosResourceContext();

        public TClass Pesquisar(int id) => db.Set<TClass>().Find(id);

        public IEnumerable<TClass> PesquisarTodos() => db.Set<TClass>().ToList();

        public void Incluir(TClass obj)
        {
            db.Set<TClass>().Add(obj);
            db.SaveChanges();
        }

        public void Alterar(TClass obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Deletar(TClass obj)
        {
            db.Set<TClass>().Remove(obj);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
