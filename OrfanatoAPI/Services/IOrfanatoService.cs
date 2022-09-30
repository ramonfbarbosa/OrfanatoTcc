using OrfanatoAPI.DTOs;
using OrfanatoAPI.Models;
using OrfanatoAPI.Requests;
using OrfanatoAPI.Response;

namespace OrfanatoAPI.Services;

public interface IOrfanatoService
{
    OrfanatoDTO GetById(int id);
    List<OrfanatoDTO> GetAll();
    Task<ValidationResponse<OrfanatoDTO>> CreateAsync(InsertOrfanatoRequest request);
    Task<AtivarOuDesativarOrfanatoResponse<Orfanato>> UpdateAtivo(UpdateAtivoRequest request);
}
