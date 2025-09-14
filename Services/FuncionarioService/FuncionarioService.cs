using Microsoft.EntityFrameworkCore;
using WebApiBase.DataContext;
using WebApiBase.Models;

namespace WebApiBase.Services.FuncionarioService;

public class FuncionarioService : IFuncionarioInterface
{
    private readonly ApplicationDbContext _context;

    public FuncionarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<Funcionario>>> GetFuncionarios()
    {
        ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

        try
        {
            var response = await _context.Funcionarios.ToListAsync();

            if (response.Count == 0)
            {
                serviceResponse.Dados = response;
                serviceResponse.Mensagem = "Nenhum dado encontrado!";
                serviceResponse.Success = true;
            }
            else
            {
                serviceResponse.Dados = response;
                serviceResponse.Mensagem = "Usuários retornados com sucesso!";
                serviceResponse.Success = true;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<Funcionario>> CreateFuncionario(Funcionario funcionario)
    {
        ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

        try
        {
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informe os dados do funcionário!";
                serviceResponse.Success = false;
            }
            else
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = funcionario;
                serviceResponse.Mensagem = "Funcionário cadastrado com sucesso!";
                serviceResponse.Success = true;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<Funcionario>> UpdateFuncionario(Funcionario funcionarioAtualizar)
    {
        ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

        try
        {
            Funcionario? funcionario = await _context.Funcionarios.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == funcionarioAtualizar.Id);

            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum dado encontrado!";
                serviceResponse.Success = false;
            }
            else
            {
                funcionario.DataAtualizacao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionarioAtualizar);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = funcionarioAtualizar;
                serviceResponse.Mensagem = "Funcionário atualizado com sucesso!";
                serviceResponse.Success = true;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<Funcionario>> GetFuncionarioById(int id)
    {
        ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

        try
        {
            Funcionario? funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.Id == id);

            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum dado encontrado!";
                serviceResponse.Success = false;
            }
            else
            {
                serviceResponse.Dados = funcionario;
                serviceResponse.Mensagem = "Funcionário retornado com sucesso!";
                serviceResponse.Success = true;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<Funcionario>> DeleteFuncionario(int id)
    {
        ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

        try
        {
            Funcionario? funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.Id == id);

            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum dado encontrado!";
                serviceResponse.Success = false;
            }
            else
            {
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = funcionario;
                serviceResponse.Mensagem = "Funcionário removido com sucesso!";
                serviceResponse.Success = true;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<Funcionario>> InativaFuncionario(int id)
    {
        ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

        try
        {
            Funcionario? funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.Id == id);

            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum dado encontrado!";
                serviceResponse.Success = false;
            }
            else
            {
                funcionario.Ativo = false;
                funcionario.DataAtualizacao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = funcionario;
                serviceResponse.Mensagem = "Funcionário inativado com sucesso!";
                serviceResponse.Success = true;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}
