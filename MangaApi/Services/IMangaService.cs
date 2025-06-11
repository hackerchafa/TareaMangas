using MangaApi.Models;

namespace MangaApi.Services;

public interface IMangaService
{
    IEnumerable<Manga> GetAll();
    Manga? GetById(int id);
    Manga Create(Manga manga);
    Manga? Update(int id, Manga manga);
    bool Delete(int id);
}
