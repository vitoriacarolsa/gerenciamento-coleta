namespace fiap.Models
{
    public class ColetaModel
    {
        public int ColetaId { get; set; }
        public string? rota { get; set; }
        public string? status { get; set; }
        public DateTime dataHora { get; set; }

    }
}
