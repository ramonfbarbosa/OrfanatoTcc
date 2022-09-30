using OrfanatoAPI.Models;

namespace OrfanatoAPI.Repositories;

public interface IOrfanatoRepository
{
    Orfanato GetById(int id);
    List<Orfanato> GetAll();
    Task<Orfanato> CreateAsync(Orfanato novoOrfanato);
    Task<Orfanato> UpdateAtivo(Orfanato orfanatoAtualizado);
}
