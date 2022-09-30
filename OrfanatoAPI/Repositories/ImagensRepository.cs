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

    public async Task CreateImagensAsync(List<OrfanatoImagem> novasImagens)
    {
        using var transaction = OrfanatoContext.Database.BeginTransaction();
        try
        {
            OrfanatoContext.Imagens.AddRange(novasImagens);
            await OrfanatoContext.SaveChangesAsync();
            transaction.Commit();
        }
        catch (Exception)
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception) { }
            throw;
        }
    }
}
