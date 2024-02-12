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


    [HttpPost("carregar")]
    public async Task<IActionResult> CarregarImagemParaCloud(IFormFile imagem)
    {
        if (User.Identity.IsAuthenticated)
        {
            var idParaEncontrar = _signInManager.UserManager.GetUserId(User);
            var usuarioComNomeDeExibicao = _userManager.Users.FirstOrDefault(x => x.Id == idParaEncontrar);

            if (usuarioComNomeDeExibicao is not null)
            {
                if (imagem is not null)
                {
                    var image = await _cloud.FazerUploadDaImagemParaCloud(imagem);

                    if (image == null)
                    {
                        return BadRequest();
                    }

                    usuarioComNomeDeExibicao.ImagemDePerfil = image;
                    await _context.SaveChangesAsync();

                    return new JsonResult(new { Link = image });
                }
            }

            return BadRequest();
        }
        return BadRequest();
    }
}
