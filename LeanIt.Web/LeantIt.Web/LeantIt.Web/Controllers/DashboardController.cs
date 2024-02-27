using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private readonly UserManager<AplicacaoUser> _userManager;

        public DashboardController(AppDbContext context, SignInManager<AplicacaoUser> signInManager, UserManager<AplicacaoUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            //Verifica se o usuário está autenticado
            if (User.Identity.IsAuthenticated)
            {
                //Pega o id do usuário que está logado
                var idParaEncontrar = _signInManager.UserManager.GetUserId(User);

                //Verifica se existe o id do usuário logado no banco
                var usuarioComNomeDeExibicao = _userManager.Users.FirstOrDefault(x => x.Id == idParaEncontrar);

                //Se encontrar o id do usuário logado no banco a variável usuarioComNomeDeExibicao vai ter um valor, ou seja, ela não será nula, então ela vai para o if
                if (usuarioComNomeDeExibicao != null)
                {
                    //Pega o nome do usuário logado e armazenamos em uma ViewBag, para poder usar no front
                    ViewBag.User = usuarioComNomeDeExibicao.Nome;
                }

                //Armazena na variável o name do usuário autenticado
                var user = User.Identity.Name;

                //Verifica se no banco possui o name do usuário autenticado, se tiver vai armazena na variável o registro do usuário
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

                //Verifica se o usuário que tá logado possui alguma pendência de aluguel na tabela AluguelCarros
                var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);

                //Armazena o registro da verificação acima, está em uma ViewBag  para poder usar no front
                ViewBag.Pendente = pendente;
            }

            //Armazena na variável o registro da categoria Basico
            var categoriaBasico = _context.Categorias.FirstOrDefault(categoriaCarro => categoriaCarro.Descricao == "Basico");

            //Armazena na variável a QUANTIDADE de carros que foram alugados da categoria Basico
            var carroBasico = _context.AlguelCarros.Where(aluguelCarro => aluguelCarro.Carro.Categoria.Descricao == categoriaBasico.Descricao).Count();

            //Armazena na ViewBag o valor da variável acima, está em uma ViewBag para poder usar no front
            ViewBag.CarroBasico = carroBasico;

            //Armazena na variável o registro da categoria Familia
            var categoriaFamilias = _context.Categorias.FirstOrDefault(categoriaF => categoriaF.Descricao == "Familia");

            //Armazena na variável a QUANTIDADE de carros que foram alugados da categoria Familia
            var carroFamilia = _context.AlguelCarros.Where(carroF => carroF.Carro.Categoria.Descricao == categoriaFamilias.Descricao).Count();

            //Armazena na ViewBag o valor da variável acima, está em uma ViewBag para poder usar no front
            ViewBag.CarroFamilia = carroFamilia;

            //Armazena na variável o registro da categoria Carga
            var categoriaCarga = _context.Categorias.FirstOrDefault(categoriaC => categoriaC.Descricao == "Carga");

            //Armazena na variável a QUANTIDADE de carros que foram alugados da categoria Carga
            var carroCarga = _context.AlguelCarros.Where(carroC => carroC.Carro.Categoria.Descricao == categoriaCarga.Descricao).Count();

            //Armazena na ViewBag o valor da variável acima, está em uma ViewBag para poder usar no front
            ViewBag.CarroCarga = carroCarga;



            //
            var carroAtivo = _context.Carros.Where(carroA => carroA.Status == true).Count();
            ViewBag.CarroAtivo = carroAtivo;

            var carroInativo = _context.Carros.Where(carroI => carroI.Status == false).Count();
            ViewBag.CarroInativo = carroInativo;



            var qCarrosBasico = _context.Carros.Where(QCarro => QCarro.Categoria.Descricao == "Basico").Count();
            ViewBag.QCarroBasico = qCarrosBasico;

            var qCarrosFamilia = _context.Carros.Where(QCarro => QCarro.Categoria.Descricao == "Familia").Count();
            ViewBag.QCarroFamilia = qCarrosFamilia;

            var qCarrosCarga = _context.Carros.Where(QCarro => QCarro.Categoria.Descricao == "Carga").Count();
            ViewBag.QCarroCarga = qCarrosCarga;

            return View();
        }
    }
}
