using OrfanatoAPI.Models;

namespace OrfanatoAPI.Requests;

public class InsertImageRequest
{
    public string ImageUrl { get; set; }
    public int OrfanatoFK { get; set; }

    public InsertImageRequest() { }

    public InsertImageRequest(string imageUrl, int orfanatoFk)
    {
        ImageUrl = imageUrl;
        OrfanatoFK = orfanatoFk;
    }

    public InsertImageRequest(OrfanatoImagem imagem)
    {
        ImageUrl = imagem.ImagemUrl;
        OrfanatoFK = imagem.OrfanatoId;
    }

    public OrfanatoImagem GetEntity() =>
        new()
        {
            ImagemUrl = ImageUrl,
            OrfanatoId = OrfanatoFK
        };
}
