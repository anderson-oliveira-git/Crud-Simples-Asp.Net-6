using Microsoft.AspNetCore.Mvc;
using WebApiBase.Models;
using WebApiBase.Services.FuncionarioService;

namespace WebApiBase.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioInterface _funcionarioInterface;

    public FuncionarioController(IFuncionarioInterface funcionarioInterface)
    {
        _funcionarioInterface = funcionarioInterface;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> GetFuncionarios()
    {
        var response = await _funcionarioInterface.GetFuncionarios();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Funcionario>>> GetFuncionarioById(int id)
    {
        var response = await _funcionarioInterface.GetFuncionarioById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> CreateFuncionario(Funcionario funcionario)
    {
        var response = await _funcionarioInterface.CreateFuncionario(funcionario);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<Funcionario>>> UpdateFuncionario(Funcionario funcionario)
    {
        var response = await _funcionarioInterface.UpdateFuncionario(funcionario);
        return Ok(response);
    }

    [HttpPut("inativar")]
    public async Task<ActionResult<ServiceResponse<Funcionario>>> InativaFuncionario(int id)
    {
        var response = await _funcionarioInterface.InativaFuncionario(id);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<Funcionario>>> DeleteFuncionario(int id)
    {
        var response = await _funcionarioInterface.DeleteFuncionario(id);
        return Ok(response);
    }
}
