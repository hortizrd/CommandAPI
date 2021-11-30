using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CommandAPI.Data
{
    public interface ICommandContext
    {
        DbSet<Command> Command { get; set; }

        //Task<int> SaveChanges();
    }
}