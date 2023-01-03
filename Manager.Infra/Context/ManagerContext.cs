using Manager.Domain.Entities;
// using Manager.Infra.Interfaces;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context;

public class ManagerContext : DbContext
{
    public ManagerContext(){}

    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var database_name = "NameDB";
        optionsBuilder.UseSqlServer(
        @"Data Source=DESKTOP-652APCE\SQLEXPRESS;Initial Catalog="+database_name+";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            );
    }
    public virtual DbSet<User> Users {  get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }
}