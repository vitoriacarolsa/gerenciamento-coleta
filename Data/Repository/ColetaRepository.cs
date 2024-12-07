using fiap.Models;
using Microsoft.EntityFrameworkCore;

namespace fiap.Data.Repository
{
    public class ColetaRepository : IcoletaRepository
    {
        private readonly DataBaseContext _context;

        public ColetaRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<ColetaModel> GetAll() => _context.Coletas.ToList();

        public IEnumerable<ColetaModel> GetAll(int page, int size)
        {
            return _context.Coletas
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        public IEnumerable<ColetaModel> GetAllReference(int lastReference, int size)
        {
            var coletas = _context.Coletas
                                .Where(c => c.ColetaId > lastReference)
                                .OrderBy(c => c.ColetaId)
                                .Take(size)
                                .AsNoTracking()
                                .ToList();

            return coletas;
        }

        public ColetaModel GetById(int id) => _context.Coletas.Find(id);

        public void Add(ColetaModel coleta)
        {
            _context.Coletas.Add(coleta);
            _context.SaveChanges();
        }

        public void Update(ColetaModel coleta)
        {
            _context.Coletas.Update(coleta);
            _context.SaveChanges();
        }

        public void Delete(ColetaModel coleta)
        {
            _context.Coletas.Remove(coleta);
            _context.SaveChanges();
        }
    }
}
