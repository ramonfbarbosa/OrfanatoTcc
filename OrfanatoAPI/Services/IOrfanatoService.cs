using OrfanatoAPI.DTOs;
using OrfanatoAPI.Response;

namespace OrfanatoAPI.Services;

public interface IOrfanatoService
{
    OrfanatoDTO GetById(int id);
    List<OrfanatoDTO> GetAll();
    Task<ValidationResponse<OrfanatoDTO>> CreateAsync(OrfanatoDTO orfanatoDTO);
    Task<ValidationResponse<OrfanatoDTO>> UpdateAtivo(OrfanatoDTO updatedOrfanatoDto);
}
