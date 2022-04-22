using Microsoft.EntityFrameworkCore;

namespace Pokrocile_programovaci_prostredky.Api.Data;
public class NemocniceDbContext : DbContext
{
    public NemocniceDbContext(DbContextOptions<NemocniceDbContext> options) : base(options)
    {

    }

    public DbSet<VybaveniData> Vybavenis => Set<VybaveniData>();
    public DbSet<RevizeData> Revizes => Set<RevizeData>();
}

