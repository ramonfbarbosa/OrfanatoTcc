using OrfanatoAPI.Context;
using OrfanatoAPI.Models;

namespace OrfanatoAPI.Repositories;

public class ImagensRepository : IImagensRepository
{
    private OrfanatoContext OrfanatoContext { get; }

    public ImagensRepository(OrfanatoContext orfanatoContext)
    {
        OrfanatoContext = orfanatoContext;
    }

    public async Task<Imagens> CreateImagensAsync(Imagens novasImagens)
    {
        OrfanatoContext.Add(novasImagens);
        await OrfanatoContext.SaveChangesAsync();
        return novasImagens;
    }
}
