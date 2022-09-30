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

    private IQueryable<Orfanato> OrfanatosWithIncludes =>
           OrfanatoContext.Orfanatos.Include(x => x.Imagens);

    public List<Orfanato> GetAll() =>
            OrfanatosWithIncludes.ToList();

    public Orfanato GetById(int id) =>
            OrfanatosWithIncludes.AsNoTracking().FirstOrDefault(x => x.Id == id);

    public async Task<Orfanato> CreateAsync(Orfanato novoOrfanato)
    {
        using var transaction = OrfanatoContext.Database.BeginTransaction();
        try
        {
            var proxy = OrfanatoContext.Orfanatos.Add(novoOrfanato);
            await OrfanatoContext.SaveChangesAsync();
            transaction.Commit();
            return proxy.Entity;
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

    public async Task<Orfanato> UpdateAtivo(Orfanato orfanatoAtualizado)
    {
        var proxy = OrfanatoContext.Attach(orfanatoAtualizado);
        proxy.State = EntityState.Modified;
        OrfanatoContext.Update(orfanatoAtualizado);
        await OrfanatoContext.SaveChangesAsync();
        return proxy.Entity;
    }
}
