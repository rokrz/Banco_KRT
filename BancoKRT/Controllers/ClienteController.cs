using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BancoKRT.Models;
using BancoKRT.Repositories;

namespace BancoKRT.Controllers;
[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IClienteRepository _repository;

    public ClienteController(ILogger<ClienteController> logger, IClienteRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Cliente user)
    {
        if (ValidaNovoUsuario(user))
        {
            await _repository.Adicionar(user);
            return Ok();
        }
        else
        {
            return BadRequest("Os campos não estçao corretamente preenchidos");
        }
        
    }

    [HttpPut]
    public async Task<IActionResult> Update(Cliente user)
    {
        //Implementar a validacao para alterar somente o valor do limite do PIX
        await _repository.Atualizar(user);
        return Ok();
    }

    private bool ValidaNovoUsuario(Cliente user)
    {
        bool isNewUserValid = true;

        //Verirfica que os campos nao sao nulos
        if (!string.IsNullOrEmpty(user.NumeroAgencia)|| !string.IsNullOrEmpty(user.NumeroConta) || !string.IsNullOrEmpty(user.CPF) || user.LimitePIX != 0 )
        {
            isNewUserValid = false;
        }

        return isNewUserValid;
    }

    [HttpDelete("{agencia}/{conta}")]
    public async Task<IActionResult> Delete(string agencia, string conta)
    {
        await _repository.Deletar(agencia, conta);
        return Ok();
    }
}
