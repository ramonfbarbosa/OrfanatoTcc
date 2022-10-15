using OrfanatoAPI.DTOs;
using OrfanatoAPI.Models;
using OrfanatoAPI.Requests;
using OrfanatoAPI.Response;

namespace OrfanatoAPI.Services;

public interface IOrfanatoService
{
    OrfanatoDTOById GetById(int id);
    List<OrfanatoDTOMap> GetAll();
    Task<ValidationResponse<OrfanatoDTO>> CreateAsync(InsertOrfanatoRequest request);
    Task<AtivarOuDesativarOrfanatoResponse<Orphanage>> UpdateAtivo(UpdateAtivoRequest request);
}
