﻿namespace LeantIt.Web.Models.ViewModels;

public class AdicionarCarroViewModel
{
    public string Descricao { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public DateOnly Year { get; set; }
    public string Placa { get; set; }
    public string Cor { get; set; }
    public string Status { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

}
