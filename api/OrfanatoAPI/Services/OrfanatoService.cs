using FluentValidation;
using OrfanatoAPI.DTOs;
using OrfanatoAPI.Models;
using OrfanatoAPI.Repositories;
using OrfanatoAPI.Requests;
using OrfanatoAPI.Response;

namespace OrfanatoAPI.Services;

public class OrfanatoService : IOrfanatoService
{
    public IOrfanatoRepository OrfanatoRepository { get; }
    private IValidator<Orphanage> OrfanatoValidator { get; }

    public OrfanatoService(
        IOrfanatoRepository orfanatoRepository,
        IValidator<Orphanage> orfanatoValidator
        )
    {
        OrfanatoRepository = orfanatoRepository;
        OrfanatoValidator = orfanatoValidator;
    }

    public OrfanatoDTOById GetById(int id)
    {
        var entity = OrfanatoRepository.GetById(id);
        var imagensDto = entity.Imagens.Select(x => new ImageDTO(x)).ToList();

        return new OrfanatoDTOById
        {
            Name = entity.Name,
            Latitude = entity.Latitude,
            Longitude = entity.Longitude,
            Instructions = entity.Instructions,
            About = entity.About,
            Whatsapp = entity.Whatsapp,
            OpeningHours = entity.HoraDeAbertura,
            OpenOnWeekends = entity.AbertoFimDeSemana,
            Images = imagensDto
        };
    }

    public List<OrfanatoDTOMap> GetAll() =>
        OrfanatoRepository.GetAll().Select(x => new OrfanatoDTOMap(x)).ToList();

    public async Task<ValidationResponse<OrfanatoDTO>> CreateAsync(InsertOrfanatoRequest request)
    {
        var orfanato = request.GetEntity();
        var imagens = request.Images.Select(x => new Image(x)).ToList();
        orfanato.Imagens = imagens;

        var orfanatoValidationResult = OrfanatoValidator.Validate(orfanato);
        if (orfanatoValidationResult.IsValid)
        {
            var orfanatoEntity = await OrfanatoRepository.CreateAsync(orfanato);
            var dto = new OrfanatoDTO(orfanatoEntity);
            return ValidationResponse<OrfanatoDTO>.Valid(orfanatoValidationResult, dto);
        }
        else
        {
            return ValidationResponse<OrfanatoDTO>.Invalid(orfanatoValidationResult);
        }
    }

    public async Task<AtivarOuDesativarOrfanatoResponse<Orphanage>> UpdateAtivo(UpdateAtivoRequest request)
    {
        try
        {
            var orfanato = OrfanatoRepository.GetById(request.Id);
            if (orfanato is null)
            {
                return AtivarOuDesativarOrfanatoResponse<Orphanage>.Invalid(new List<string> { "id não existente" });
            }
            else if (request.Desejo is "ativar")
            {
                orfanato.Ativo = true;
            }
            else if (request.Desejo is "desativar")
            {
                orfanato.Ativo = false;
            }
            var updatedOrfanato = await OrfanatoRepository.UpdateAtivo(orfanato);
            return AtivarOuDesativarOrfanatoResponse<Orphanage>.Valid(updatedOrfanato.Id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
