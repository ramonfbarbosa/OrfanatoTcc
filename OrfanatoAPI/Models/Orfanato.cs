namespace OrfanatoAPI.Models;

public class Orfanato
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
    public virtual List<Imagens> Imagens { get; }

    public Orfanato() { }

    public Orfanato(
        int id, string nome, decimal latitude,
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
}
