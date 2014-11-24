using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaOutsourcing.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T: class
    {
        void Inserir(T entity);
        void Alterar(T entity);
        void Excluir(T entity);
        T ListarId(int id);
        IEnumerable<T> ListarTodos();
    }
}
