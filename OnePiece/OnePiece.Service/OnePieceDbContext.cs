using Microsoft.EntityFrameworkCore;
using OnePiece.Modelos;

namespace OnePiece.Service
{
    public class OnePieceDbContext : DbContext
    {
        public OnePieceDbContext(DbContextOptions<OnePieceDbContext> options) : base(options) { }

        public DbSet<Pirata> pirata { get; set; }

        public OnePieceDbContext() { }
    }
}