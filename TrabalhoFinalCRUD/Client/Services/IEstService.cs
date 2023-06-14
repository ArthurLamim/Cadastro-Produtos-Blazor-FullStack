using TrabalhoFinalCRUD.Shared.Models;

namespace TrabalhoFinalCRUD.Client.Services
{
    public interface IEstService
    {
        List<Produto> Produtos { get; set; }
        List<Categoria> Categorias { get; set; }
        Task GetCategorias();
        Task GetListProdutos();
        Task<Produto> GetProduto(int id);
        Task CreateNewProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task DeleteProduto(int id);
    }
}
