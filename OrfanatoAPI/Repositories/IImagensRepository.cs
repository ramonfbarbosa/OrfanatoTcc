using OrfanatoAPI.Models;

namespace OrfanatoAPI.Repositories;

public interface IImagensRepository
{
    Task CreateImagensAsync(List<OrfanatoImagem> novasImagens);
}
