using fiap.Models;

namespace fiap.Data.Repository
{
    public interface IcoletaRepository
    {
        IEnumerable<ColetaModel> GetAll();
        IEnumerable<ColetaModel> GetAll(int page, int size);
        IEnumerable<ColetaModel> GetAllReference(int lastReference, int size);
        ColetaModel GetById(int id);
        void Add(ColetaModel coleta);
        void Update(ColetaModel coleta);
        void Delete(ColetaModel coleta);
    }
}
