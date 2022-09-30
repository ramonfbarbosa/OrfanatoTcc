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
    public IImagensRepository ImagensRepository { get; }
    private IValidator<Orfanato> OrfanatoValidator { get; }

    public OrfanatoService(
        IOrfanatoRepository orfanatoRepository,
        IValidator<Orfanato> orfanatoValidator,
        IImagensRepository imagensRepository
        )
    {
        OrfanatoRepository = orfanatoRepository;
        OrfanatoValidator = orfanatoValidator;
        ImagensRepository = imagensRepository;
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
            var dto = new OrfanatoDTO(orfanato.Id, orfanato.Nome, orfanato.Whatsapp,
                orfanato.Latitude, orfanato.Longitude, orfanato.Sobre,
                orfanato.Instrucoes, orfanato.HoraDeAbertura, orfanato.AbertoFimDeSemana,
                orfanato.Ativo, orfanato.Imagens);
            dtos.Add(dto);
        }
        return dtos;
    }

    public async Task<ValidationResponse<OrfanatoDTO>> CreateAsync(InsertOrfanatoRequest request)
    {
        var orfanato = request.GetEntity();
        var orfanatoValidationResult = OrfanatoValidator.Validate(orfanato);
        if (orfanatoValidationResult.IsValid)
        {
            var orfanatoEntity = await OrfanatoRepository.CreateAsync(orfanato);
            var listaDeImagens = new List<OrfanatoImagem>();
            foreach (var item in request.ImagensUrl)
            {
                var obj = new OrfanatoImagem(item, orfanatoEntity.Id);
                listaDeImagens.Add(obj);
            }
            await ImagensRepository.CreateImagensAsync(listaDeImagens);
            var dto = new OrfanatoDTO(orfanatoEntity, listaDeImagens);
            return ValidationResponse<OrfanatoDTO>.Valid(orfanatoValidationResult, dto);
        }
        else
        {
            return ValidationResponse<OrfanatoDTO>.Invalid(orfanatoValidationResult);
        }
    }

    public async Task<AtivarOuDesativarOrfanatoResponse<Orfanato>> UpdateAtivo(UpdateAtivoRequest request)
    {
        try
        {
            var orfanato = OrfanatoRepository.GetById(request.Id);
            if (orfanato is null)
            {
                return AtivarOuDesativarOrfanatoResponse<Orfanato>.Invalid(new List<string> { "id não existente" });
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
            return AtivarOuDesativarOrfanatoResponse<Orfanato>.Valid(updatedOrfanato.Id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
