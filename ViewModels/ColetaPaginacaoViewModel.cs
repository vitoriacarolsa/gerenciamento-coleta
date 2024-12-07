namespace fiap.ViewModels
{
    public class ColetaPaginacaoViewModel
    {

        public IEnumerable<ColetaViewModel> Coletas { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Coletas.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Coleta?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Coleta?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";



    }
}
