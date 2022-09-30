﻿using Microsoft.AspNetCore.Mvc;
using OrfanatoAPI.DTOs;
using OrfanatoAPI.Requests;
using OrfanatoAPI.Services;

namespace OrfanatoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrphanagesController : Controller
{
    private ILogger<OrphanagesController> Logger { get; }
    public IOrfanatoService OrfanatoService { get; }

    public OrphanagesController(IOrfanatoService orfanatoService, ILogger<OrphanagesController> logger)
    {
        OrfanatoService = orfanatoService;
        Logger = logger;
    }

    [HttpGet("{orfanatoId:int}")]
    public ActionResult<List<OrfanatoDTO>> GetById([FromRoute] int orfanatoId) =>
        Ok(OrfanatoService.GetById(orfanatoId));

    [HttpGet("orphanages")]
    public ActionResult<List<OrfanatoDTO>> GetAll() =>
         Ok(OrfanatoService.GetAll());

    [HttpPost("insert")]
    public async Task<IActionResult> InsertOrfanato(InsertOrfanatoRequest request)
    {
        try
        {
            var result = await OrfanatoService.CreateAsync(request);
            if (result.Sucesso)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        catch (Exception e)
        {
            string errorMessage = $"InsertOrfanato error - {e.Message}";
            Logger.LogError(e, errorMessage);
            return StatusCode(500, errorMessage);
        }
    }

    [HttpPost("ativar-ou-desativar")]
    public async Task<IActionResult> AtivarOuDesativarOrfanato([FromBody] UpdateAtivoRequest request)
    {
        try
        {
            var result = await OrfanatoService.UpdateAtivo(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Errors);
        }

        catch (Exception e)
        {
            string errorMessage = $"ActiveOrDesactiveMethod error - {e.Message}";
            Logger.LogError(e, errorMessage);
            return StatusCode(500, errorMessage);
        }
    }
}