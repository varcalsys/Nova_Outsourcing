using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovaOutsourcing.Domain.Interfaces.Repositories;

namespace NovaOutsourcing.Util.Repositories
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        protected readonly EfContext Db = new EfContext();   
        public void Inserir(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
        }

        public void Alterar(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Excluir(T entity)
        {
            Db.Set<T>().Remove(entity);
            Db.SaveChanges();
        }

        public T ListarId(int id)
        {
           return Db.Set<T>().Find(id);
        }

        public IEnumerable<T> ListarTodos()
        {
            return Db.Set<T>();
        }
    }
}
