using fiap.Models;

namespace fiap.Services
{
    public interface IColetaService
    {
        IEnumerable<ColetaModel> ListarColetas();
        ColetaModel ObterColetaPorId(int id);

        IEnumerable<ColetaModel> ListarColetas(int pagina = 0, int tamanho = 10);
        IEnumerable<ColetaModel> ListarColetasUltimaReferencia(int ultimoId = 0, int tamanho = 10);
        void CriarColeta(ColetaModel coleta);
        void AtualizarColeta(ColetaModel coleta);
        void DeletarColeta(int id);
    }
}
