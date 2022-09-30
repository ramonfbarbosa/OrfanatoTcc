using Microsoft.EntityFrameworkCore;
using OrfanatoAPI.Context;
using OrfanatoAPI.Models;

namespace OrfanatoAPI.Repositories;

public class OrfanatoRepository : IOrfanatoRepository
{
    private OrfanatoContext OrfanatoContext { get; }

    public OrfanatoRepository(OrfanatoContext orfanatoContext)
    {
        OrfanatoContext = orfanatoContext;
    }

    public List<Orfanato> GetAll() =>
            OrfanatoContext.Orfanatos.ToList();

    public Orfanato GetById(int id) =>
            OrfanatoContext.Orfanatos.AsNoTracking().FirstOrDefault(x => x.Id == id);

    public async Task<Orfanato> CreateAsync(Orfanato novoOrfanato)
    {
        OrfanatoContext.Add(novoOrfanato);
        await OrfanatoContext.SaveChangesAsync();
        return novoOrfanato;
    }

    public async Task<Orfanato> UpdateAtivo(Orfanato orfanatoAtualizado)
    {
        var proxy = OrfanatoContext.Attach(orfanatoAtualizado);
        proxy.State = EntityState.Modified;
        OrfanatoContext.Update(orfanatoAtualizado);
        await OrfanatoContext.SaveChangesAsync();
        return proxy.Entity;
    }
}
