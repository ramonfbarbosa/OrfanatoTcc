namespace OrfanatoAPI.Models;

public class OrfanatoImagem
{
    public int Id { get; set; }
    public string ImagemUrl { get; set; }
    public int OrfanatoId { get; set; }

    public OrfanatoImagem() { }

    public OrfanatoImagem(string caminho, int orfanatoId)
    {
        ImagemUrl = caminho;
        OrfanatoId = orfanatoId;
    }
}
