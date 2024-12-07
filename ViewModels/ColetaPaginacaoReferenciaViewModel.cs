namespace fiap.ViewModels
{
    public class ColetaPaginacaoReferenciaViewModel
    {

        public IEnumerable<ColetaViewModel> Coletas { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Coleta?referencia={Ref}&tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Coleta?referencia={NextRef}&tamanho={PageSize}" : "";



    }
}
