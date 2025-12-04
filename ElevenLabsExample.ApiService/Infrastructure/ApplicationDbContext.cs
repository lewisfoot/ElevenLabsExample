using ElevenLabsExample.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace ElevenLabsExample.ApiService.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<PhoneCall> PhoneCalls { get; set; }
    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}
