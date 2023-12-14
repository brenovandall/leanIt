using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeantIt.Web.Models.ViewModels;

public class EditarCarroViewModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Year { get; set; }
    public string Placa { get; set; }
    public string Cor { get; set; }
    public string UrlImagem { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public IEnumerable<SelectListItem>? Categoria { get; set; }
    public string CategoriaSelecionada { get; set; }
    public bool Status { get; set; }
}
