using ClassScore.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassScore.data;

public class materiacontext : DbContext
{
    public materiacontext(DbContextOptions<materiacontext> opts) : base(opts)
    {

    }
    public DbSet<Materia> materia { get; set; }

}
