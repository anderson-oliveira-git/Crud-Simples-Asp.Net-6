
using System.ComponentModel.DataAnnotations;
using WebApiBase.Enums;

namespace WebApiBase.Models;

public class Funcionario
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string SobreNome { get; set; }
    public bool Ativo { get; set; }

    public TurnoEnum Turno { get; set; }
    public DepartamentoEnum Departamento { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataAtualizacao { get; set; } = DateTime.Now.ToLocalTime();
}
