using OrfanatoAPI.Models;

namespace OrfanatoAPI.DTOs;

public class OrfanatoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string Sobre { get; set; }
    public string Instrucoes { get; set; }
    public DateTime HoraDeAbertura { get; set; }
    public bool AbertoFimDeSemana { get; set; }
    public bool Ativo { get; set; }

    public OrfanatoDTO() { }

    public OrfanatoDTO(int id, string nome, decimal latitude,
        decimal longitude, string sobre, string instrucoes,
        DateTime horaDeAbertura, bool abertoFimDeSemana, bool ativo)
    {
        Id = id;
        Nome = nome;
        Latitude = latitude;
        Longitude = longitude;
        Sobre = sobre;
        Instrucoes = instrucoes;
        HoraDeAbertura = horaDeAbertura;
        AbertoFimDeSemana = abertoFimDeSemana;
        Ativo = ativo;
    }

    public OrfanatoDTO(Orfanato orfanato)
    {
        Id = orfanato.Id;
        Nome = orfanato.Nome;
        Latitude = orfanato.Latitude;
        Longitude = orfanato.Longitude;
        Sobre = orfanato.Sobre;
        Instrucoes = orfanato.Instrucoes;
        HoraDeAbertura = orfanato.HoraDeAbertura;
        AbertoFimDeSemana = orfanato.AbertoFimDeSemana;
        Ativo = orfanato.Ativo;
    }

    public Orfanato GetEntity() =>
        new()
        {
            Id = Id,
            Nome = Nome,
            Latitude = Latitude,
            Longitude = Longitude,
            Sobre = Sobre,
            Instrucoes = Instrucoes,
            HoraDeAbertura = HoraDeAbertura,
            AbertoFimDeSemana = AbertoFimDeSemana,
            Ativo = Ativo
        };
}