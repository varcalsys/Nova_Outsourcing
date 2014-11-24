using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovaOutsourcing.Domain.Entities;

namespace NovaOutsourcing.Domain.Interfaces.Services
{
    public interface IVisitanteService: IServiceBase<Visitante>
    {
        int Contador();
    }
}
