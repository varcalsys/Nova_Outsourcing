using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovaOutsourcing.Domain.Entities;
using NovaOutsourcing.Domain.Interfaces.Repositories;

namespace NovaOutsourcing.Util.Repositories
{
    public class NewsletterRepository: RepositoryBase<Newsletter>, INewsletterRepository
    {
    }
}
