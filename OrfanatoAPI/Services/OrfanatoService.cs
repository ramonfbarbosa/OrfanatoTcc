using FluentValidation;
using OrfanatoAPI.DTOs;
using OrfanatoAPI.Models;
using OrfanatoAPI.Repositories;
using OrfanatoAPI.Response;

namespace OrfanatoAPI.Services;

public class OrfanatoService : IOrfanatoService
{
    public IOrfanatoRepository OrfanatoRepository { get; }
    public IImagensRepository ImagensRepository { get; }
    private IValidator<Orfanato> Validator { get; }

    public OrfanatoService(
        IOrfanatoRepository orfanatoRepository,
        IImagensRepository imagensRepository,
        IValidator<Orfanato> validator)
    {
        OrfanatoRepository = orfanatoRepository;
        ImagensRepository = imagensRepository;
        Validator = validator;
    }

    public OrfanatoDTO GetById(int id)
    {
        var entity = OrfanatoRepository.GetById(id);
        return new OrfanatoDTO(entity);
    }

    public List<OrfanatoDTO> GetAll()
    {
        var orfanatos = OrfanatoRepository.GetAll();
        var dtos = new List<OrfanatoDTO>();
        foreach (var orfanato in orfanatos)
        {
            var dto = new OrfanatoDTO(orfanato.Id, orfanato.Nome,
                orfanato.Latitude, orfanato.Longitude, orfanato.Sobre,
                orfanato.Instrucoes, orfanato.HoraDeAbertura, orfanato.AbertoFimDeSemana,
                orfanato.Ativo);
            dtos.Add(dto);
        }
        return dtos;
    }

    public async Task<ValidationResponse<OrfanatoDTO>> CreateAsync(OrfanatoDTO orfanatoDTO)
    {
        var orfanato = orfanatoDTO.GetEntity();
        var validationResult = Validator.Validate(orfanato);
        if (validationResult.IsValid)
        {
            var entity = await OrfanatoRepository.CreateAsync(orfanato);
            var dto = new OrfanatoDTO(entity);
            return ValidationResponse<OrfanatoDTO>.Valid(validationResult, dto);
        }
        else
        {
            return ValidationResponse<OrfanatoDTO>.Invalid(validationResult);
        }
    }

    public async Task<ValidationResponse<OrfanatoDTO>> UpdateAtivo(OrfanatoDTO updatedOrfanatoDto)
    {
        var updatedOrfanato = updatedOrfanatoDto.GetEntity();
        var validationResult = await Validator.ValidateAsync(updatedOrfanato);
        if (validationResult.IsValid)
        {
            var entity = await OrfanatoRepository.UpdateAtivo(updatedOrfanato);
            var updatedDto = new OrfanatoDTO(entity);
            return ValidationResponse<OrfanatoDTO>.Valid(validationResult, updatedDto);
        }
        else
        {
            return ValidationResponse<OrfanatoDTO>.Invalid(validationResult);
        }
    }
}
