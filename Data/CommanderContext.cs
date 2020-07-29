using System;
using Commander.Dtos;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt): base(opt)
        {
        }
        public DbSet<Command> Commands { get; set; }

        public DbSet<CommandModified> pa_Command {get; set;}
    }
}
