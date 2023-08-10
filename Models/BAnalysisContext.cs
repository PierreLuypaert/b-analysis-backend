using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace B_Analysis_BackEnd.Models;

public class BAnalysisContext : DbContext
{
    private readonly IWebHostEnvironment _env;

    public BAnalysisContext(DbContextOptions<BAnalysisContext> options, IWebHostEnvironment env)
        : base(options)
    {
        _env = env;
    }

    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Match> Matches { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_env.IsDevelopment())
            optionsBuilder.EnableSensitiveDataLogging();
    }
}