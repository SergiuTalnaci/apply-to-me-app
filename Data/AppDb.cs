using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDb : DbContext
    {
    public AppDb(DbContextOptions<AppDb> options) : base(options)
    {
    }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
