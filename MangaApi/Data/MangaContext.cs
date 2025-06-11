using Microsoft.EntityFrameworkCore;
using MangaApi.Models;

namespace MangaApi.Data;

public class MangaContext : DbContext
{
    public MangaContext(DbContextOptions<MangaContext> options) : base(options) { }

    public DbSet<Manga> Mangas => Set<Manga>();
}
