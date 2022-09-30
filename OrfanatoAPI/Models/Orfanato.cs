namespace OrfanatoAPI.Models;

public class Orfanato
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
    public virtual List<OrfanatoImagem> Imagens { get; set; }

    public Orfanato() { }
}
