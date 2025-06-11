using MangaApi.Data;
using MangaApi.Models;

namespace MangaApi.Services;

public class MangaService : IMangaService
{
    private readonly MangaContext _context;

    public MangaService(MangaContext context)
    {
        _context = context;
    }

    public IEnumerable<Manga> GetAll() => _context.Mangas.ToList();

    public Manga? GetById(int id) => _context.Mangas.Find(id);

    public Manga Create(Manga manga)
    {
        _context.Mangas.Add(manga);
        _context.SaveChanges();
        return manga;
    }

    public Manga? Update(int id, Manga manga)
    {
        var dbManga = _context.Mangas.Find(id);
        if (dbManga == null) return null;

        dbManga.Titulo = manga.Titulo;
        dbManga.Autor = manga.Autor;
        dbManga.Genero = manga.Genero;
        dbManga.Capitulos = manga.Capitulos;

        _context.SaveChanges();
        return dbManga;
    }

    public bool Delete(int id)
    {
        var manga = _context.Mangas.Find(id);
        if (manga == null) return false;

        _context.Mangas.Remove(manga);
        _context.SaveChanges();
        return true;
    }
}
