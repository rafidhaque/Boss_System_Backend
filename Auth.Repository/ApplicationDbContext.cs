using System;
using Auth.Core.Model;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
namespace Auth.Repository
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public  DbSet<Uzer> Uzers { get; set; }
    }
}
