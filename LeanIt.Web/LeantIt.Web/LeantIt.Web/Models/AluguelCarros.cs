using Microsoft.AspNetCore.Identity;

namespace LeantIt.Web.Models
{
    public class AluguelCarros
    {
        public Guid Id { get; set; }
        public int Minutos { get; set; }
        public CarroModel Carro { get; set; }
        public string User { get; set; }
        public bool Pendente { get; set; }
        public double Preco {  get; set; }
    }
}
