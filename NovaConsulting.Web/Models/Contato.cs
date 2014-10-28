using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovaConsulting.Web.Models
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
    }
}