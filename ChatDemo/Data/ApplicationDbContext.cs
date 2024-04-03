using ChatDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChatDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
