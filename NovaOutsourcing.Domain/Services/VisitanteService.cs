using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovaOutsourcing.Domain.Entities;
using NovaOutsourcing.Domain.Interfaces.Repositories;
using NovaOutsourcing.Domain.Interfaces.Services;

namespace NovaOutsourcing.Domain.Services
{
    public class VisitanteService: ServiceBase<Visitante>, IVisitanteService
    {
        private IVisitanteRepository _visitanteRepository;

        public VisitanteService(IVisitanteRepository visitanteRepository)
            :base(visitanteRepository)
        {
            _visitanteRepository = visitanteRepository;
        }

        public int Contador()
        {
            return ListarTodos().Count();
        }
    }
}
