using OrfanatoAPI.Models;

namespace OrfanatoAPI.Repositories;

public interface IImagensRepository
{
    Task<Imagens> CreateImagensAsync(Imagens novasImagens);
}
