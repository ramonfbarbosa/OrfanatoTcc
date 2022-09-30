using OrfanatoAPI.Models;

namespace OrfanatoAPI.DTOs;

public class OrfanatoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Whatsapp { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string Sobre { get; set; }
    public string Instrucoes { get; set; }
    public DateTime HoraDeAbertura { get; set; }
    public bool AbertoFimDeSemana { get; set; }
    public bool Ativo { get; set; }
    public List<OrfanatoImagem> Imagens { get; set; }

    public OrfanatoDTO() { }

    public OrfanatoDTO(int id, string nome, string whatsapp, decimal latitude,
        decimal longitude, string sobre, string instrucoes,
        DateTime horaDeAbertura, bool abertoFimDeSemana, bool ativo, List<OrfanatoImagem> imagens)
    {
        Id = id;
        Nome = nome;
        Whatsapp = whatsapp;
        Latitude = latitude;
        Longitude = longitude;
        Sobre = sobre;
        Instrucoes = instrucoes;
        HoraDeAbertura = horaDeAbertura;
        AbertoFimDeSemana = abertoFimDeSemana;
        Ativo = ativo;
        Imagens = imagens;
    }

    public OrfanatoDTO(Orfanato orfanato)
    {
        Id = orfanato.Id;
        Nome = orfanato.Nome;
        Whatsapp = orfanato.Whatsapp;
        Latitude = orfanato.Latitude;
        Longitude = orfanato.Longitude;
        Sobre = orfanato.Sobre;
        Instrucoes = orfanato.Instrucoes;
        HoraDeAbertura = orfanato.HoraDeAbertura;
        AbertoFimDeSemana = orfanato.AbertoFimDeSemana;
        Ativo = orfanato.Ativo;
        Imagens = orfanato.Imagens;
    }

    public OrfanatoDTO(Orfanato orfanato, List<OrfanatoImagem> imagens)
    {
        Id = orfanato.Id;
        Nome = orfanato.Nome;
        Whatsapp = orfanato.Whatsapp;
        Latitude = orfanato.Latitude;
        Longitude = orfanato.Longitude;
        Sobre = orfanato.Sobre;
        Instrucoes = orfanato.Instrucoes;
        HoraDeAbertura = orfanato.HoraDeAbertura;
        AbertoFimDeSemana = orfanato.AbertoFimDeSemana;
        Ativo = orfanato.Ativo;
        Imagens = imagens;
    }
}