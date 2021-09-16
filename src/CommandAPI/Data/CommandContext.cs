using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.Data
{
    public class CommandContext : DbContext, ICommandContext
    {
        public CommandContext(DbContextOptions<CommandContext> options)
          : base(options)
        {
        }
        public DbSet<Command> Command { get; set; }


        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
