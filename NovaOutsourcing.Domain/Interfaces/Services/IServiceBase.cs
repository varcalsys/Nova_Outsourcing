using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaOutsourcing.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T: class
    {
        void Inserir(T entity);
        void Alterar(T entity);
        void Excluir(T entity);
        T ListarId(int id);
        IEnumerable<T> ListarTodos();
    }
}
