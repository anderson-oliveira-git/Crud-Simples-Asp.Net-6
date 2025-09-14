using WebApiBase.Models;

namespace WebApiBase.Services.FuncionarioService;

public interface IFuncionarioInterface
{
    Task<ServiceResponse<List<Funcionario>>> GetFuncionarios();
    Task<ServiceResponse<Funcionario>> CreateFuncionario(Funcionario funcionario);
    Task<ServiceResponse<Funcionario>> UpdateFuncionario(Funcionario funcionario);
    Task<ServiceResponse<Funcionario>> GetFuncionarioById(int id);
    Task<ServiceResponse<Funcionario>> DeleteFuncionario(int id);
    Task<ServiceResponse<Funcionario>> InativaFuncionario(int id);
}
