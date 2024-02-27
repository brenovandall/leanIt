using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LeantIt.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AplicacaoUser> _userManager;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, SignInManager<AplicacaoUser> signInManager, UserManager<AplicacaoUser> userManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //Transformamos a tabela de Carros em lista, e demos o include para acessarmos os dados relacionados e armazenamos em uma váriavel
            var carros = _context.Carros.Include(carros => carros.Categoria).ToList();

            //Armazenamos em váriavel a QUANTIDADE de registros da variável acima
            var qntCarros = carros.Count();

            //Passamos para uma ViewBag o valor da variável acima, para utilizarmos no front
            ViewBag.QntCarros = qntCarros;

            //Tranformamos a tabela de Users em lista e armazenamos em uma váriavel
            var pessoas = _context.Users.ToList();

            //Armazenamos em uma ViewBag o valor da QUANTIDADE de registros que retornou na váriavel acima, para poder utilizar no front 
            ViewBag.QntPessoas = pessoas.Count();

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

            return View(carros);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Rota
        [HttpPost("api/chat")]
        //Está recebendo uma requisição
        public async Task<JsonResult> Chat(RequestApi request)
        {
            Func<char, bool> isSpecialCharacter = c =>
            {
                return !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c);
            };

            // Cria uma array com todos os caracteres especiais
            var arrayDeCaracteresNaoAceitos = Enumerable.Range(char.MinValue, char.MaxValue)
                .Select(c => (char)c)
                .Where(c => isSpecialCharacter(c))
                .Select(c => c.ToString())
                .ToArray();

            //Verifica se a requisição tem valor, se tiver ela cai no if
            if (request is not null)
            {
                //Percorre pela array dos caracteres especiais
                foreach(var item in arrayDeCaracteresNaoAceitos)
                {
                    //Verifica se na requisição tem algum caracter especial, se tiver cai no if
                    if (request.mensagem.Contains(item))
                    {
                        //Fazemos um replace para retirar o caracter especial, por uma string vazia
                        request.mensagem = request.mensagem.Replace(item, string.Empty);
                    }
                }

                //Verificamos se na requisicao tem 2 espaços, se tiver cai no if
                if(request.mensagem.Contains("  "))
                {
                    //Fazemos um replace para retirar os 2 espaços, por um 1 espaço
                    request.mensagem = request.mensagem.Replace("  ", " ");
                }

                //Verifica se na tabela RespostaChat, na coluna Mensagem, possui o que venho da requisição
                var mensagemCompleta = await _context.RespostaChat.FirstOrDefaultAsync(x => x.Mensagem.ToUpper() == request.mensagem.ToUpper());
                
                //Se tiver encontrado algo na validação acima, ele cai no if
                if (mensagemCompleta is not null)
                {
                    //Na variável mensagemCompleta, ela armzena um registro
                    //Agora pegamos desse registro o valor da coluna Resposta, e criamos um objeto
                    var respostaCompleta = new ResponseApi { resposta = mensagemCompleta.Resposta };

                    //Passamos para json o objeto criado
                    return Json(respostaCompleta);
                }

                var respostaChat = await _context.RespostaChat.FirstOrDefaultAsync(m => m.Mensagem.ToUpper().Contains(request.mensagem.ToUpper()));

                if (respostaChat != null)
                {
                    var resposta = new ResponseApi { resposta = respostaChat.Resposta };

                    return Json(resposta);
                }
                else
                {
                    //Criamos um objeto, passando um texto dizendo que não foi possível encontrar
                    var resposta = new ResponseApi
                    {
                        resposta = "Não consigo " +
                        "compreender sua mensagem. Tente reformular sua pergunta de forma mais clara"
                    };

                    //Passamos para json o objeto criado
                    return Json(resposta);
                }
            }
            return null;
        }
    }
}