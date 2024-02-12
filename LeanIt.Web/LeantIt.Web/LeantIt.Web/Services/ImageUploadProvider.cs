using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Net;

namespace LeantIt.Web.Services;

public class ImageUploadProvider
{
    private readonly IConfiguration _configuration;
    private readonly CloudinaryDotNet.Cloudinary _cloud;
    public ImageUploadProvider(IConfiguration configuration)
    {
        _configuration = configuration;
        Account account = new Account(
                //  ****** getting the information from appsettings *******
                _configuration.GetSection("Cloudinary")["CloudName"],
                _configuration.GetSection("Cloudinary")["ApiKey"],
                _configuration.GetSection("Cloudinary")["ApiSecrets"]
            );

        _cloud = new CloudinaryDotNet.Cloudinary(account);
    }

    public async Task<string> FazerUploadDaImagemParaCloud(IFormFile imagem) // OBS: TODAS AS IMAGENS DEVE TER O NOME DE VARIAVEL "imagem"
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(imagem.FileName, imagem.OpenReadStream()),
            DisplayName = imagem.FileName
        };
        var uploadResult = await _cloud.UploadAsync(uploadParams);

        if (uploadResult != null && uploadResult.StatusCode == HttpStatusCode.OK)
        {
            return uploadResult.SecureUri.ToString();
        }

        return null;
    }
}
