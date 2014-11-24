using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovaOutsourcing.Domain.Interfaces.Repositories;
using NovaOutsourcing.Domain.Interfaces.Services;

namespace NovaOutsourcing.Domain.Services
{
    public class ServiceBase<T>: IServiceBase<T> where T: class
    {
        private IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void Inserir(T entity)
        {
            _repository.Inserir(entity);
        }

        public void Alterar(T entity)
        {
            _repository.Alterar(entity);
        }

        public void Excluir(T entity)
        {
            _repository.Excluir(entity);
        }

        public T ListarId(int id)
        {
            return _repository.ListarId(id);
        }

        public IEnumerable<T> ListarTodos()
        {
            return _repository.ListarTodos();
        }
    }
}
