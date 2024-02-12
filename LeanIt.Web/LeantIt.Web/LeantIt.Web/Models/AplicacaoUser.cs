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
        public string ImagemDePerfil { get; set; } = "https://res.cloudinary.com/dubnbered/image/upload/v1702248124/perfil_bwxiye.png";
    }
}

