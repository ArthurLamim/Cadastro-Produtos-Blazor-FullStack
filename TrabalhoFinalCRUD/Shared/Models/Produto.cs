namespace TrabalhoFinalCRUD.Shared.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string ValorProduto { get; set; } = string.Empty;
        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }

    }
}
