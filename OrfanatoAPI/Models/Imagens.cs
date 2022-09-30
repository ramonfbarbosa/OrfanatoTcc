namespace OrfanatoAPI.Models;

public class Imagens
{
    public int Id { get; set; }
    public string ImagemUrl { get; set; }
    public virtual Orfanato Orfanato { get; set; }
    public int OrfanatoId { get; set; }

    public Imagens() { }

    public Imagens(int id, string caminho, int orfanatoId)
    {
        Id = id;
        ImagemUrl = caminho;
        OrfanatoId = orfanatoId;
    }
}
