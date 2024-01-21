using Microsoft.AspNetCore.Identity;

namespace LeantIt.Web.Models
{
    public class AplicacaoUser : IdentityUser
    {
        public string CNH { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string DataNascimento { get; set; }
        public string Nome { get; set; }
    }
}

