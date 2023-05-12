using Chat.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Database
{
    public class DataContext : DbContext
    {
        public DbSet<Chatroom> Chatroom { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}