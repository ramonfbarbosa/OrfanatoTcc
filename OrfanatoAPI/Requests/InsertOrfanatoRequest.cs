using OrfanatoAPI.Models;

namespace OrfanatoAPI.Requests;

public class InsertOrfanatoRequest
{
    public string Nome { get; set; }
    public string Whatsapp { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string Sobre { get; set; }
    public string Instrucoes { get; set; }
    public DateTime HoraDeAbertura { get; set; }
    public bool AbertoFimDeSemana { get; set; }
    public List<string> ImagensUrl { get; set; }

    public InsertOrfanatoRequest() { }

    public Orfanato GetEntity() =>
        new()
        {
            Nome = Nome,
            Whatsapp = Whatsapp,
            Latitude = Latitude,
            Longitude = Longitude,
            Sobre = Sobre,
            Instrucoes = Instrucoes,
            HoraDeAbertura = HoraDeAbertura,
            AbertoFimDeSemana = AbertoFimDeSemana
        };
}
