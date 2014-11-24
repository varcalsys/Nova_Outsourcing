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
    public class NewsletterService: ServiceBase<Newsletter>, INewsletterService
    {
        private INewsletterRepository _newsletterRepository;

        public NewsletterService(INewsletterRepository newsletterRepository)
            :base(newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }
    }
}
