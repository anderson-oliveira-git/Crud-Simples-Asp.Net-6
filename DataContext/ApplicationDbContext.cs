using Microsoft.EntityFrameworkCore;
using WebApiBase.Models;

namespace WebApiBase.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
    ) : base(options)
    { }

    public DbSet<Funcionario> Funcionarios { get; set; } = null!;
}
