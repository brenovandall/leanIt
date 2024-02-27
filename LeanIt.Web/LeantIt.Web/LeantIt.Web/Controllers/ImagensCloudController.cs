using LeantIt.Web.Data;
using LeantIt.Web.Models;
using LeantIt.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagensCloudController : ControllerBase
{
    private ImageUploadProvider _cloud;
    private readonly AppDbContext _context;
    private readonly UserManager<AplicacaoUser> _userManager;
    private readonly SignInManager<AplicacaoUser> _signInManager;

    public ImagensCloudController(ImageUploadProvider cloudImagesProvider, AppDbContext context, UserManager<AplicacaoUser> userManager, SignInManager<AplicacaoUser> signInManager)
    {
        _cloud = cloudImagesProvider;
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    //Rota
    [HttpPost("carregar")]
    public async Task<IActionResult> CarregarImagemParaCloud(IFormFile imagem)
    {
        //Verifica se o usuário está autenticado
        if (User.Identity.IsAuthenticated)
        {
            //Pega o id do usuário que está logado
            var idParaEncontrar = _signInManager.UserManager.GetUserId(User);

            //Verifica se existe o id do usuário logado no banco
            var usuarioComNomeDeExibicao = _userManager.Users.FirstOrDefault(x => x.Id == idParaEncontrar);

            //Se encontrar o id do usuário logado no banco a variável usuarioComNomeDeExibicao vai ter um valor, ou seja, ela não será nula, então ela vai para o if
            if (usuarioComNomeDeExibicao is not null)
            {
                //Verifica se a imagem que está recebendo não é nula, se não for cai no if
                if (imagem is not null)
                {
                    //Faz o upload da imagem que recebeu para o cloud, e a variável imagem armazena o valor de retorno da função FazerUploadDaImagemParaCloud
                    var image = await _cloud.FazerUploadDaImagemParaCloud(imagem);

                    //Se o valor de image for null, cai no if
                    if (image == null)
                    {
                        return BadRequest();
                    }

                    //Se não o usuário que está logado recebe a imagem no seu perfil, que é o valor armzenado na variável image
                    usuarioComNomeDeExibicao.ImagemDePerfil = image;

                    //Salva no banco
                    await _context.SaveChangesAsync();

                    //Retorna para o front em json o valor armazenado na variável image
                    return new JsonResult(new { Link = image });
                }
            }

            return BadRequest();
        }
        return BadRequest();
    }
}
