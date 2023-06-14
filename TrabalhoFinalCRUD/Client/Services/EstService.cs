using Microsoft.AspNetCore.Components;
using TrabalhoFinalCRUD.Client.Pages;

using System.Net.Http.Json;
using TrabalhoFinalCRUD.Shared.Models;


namespace TrabalhoFinalCRUD.Client.Services
{
    public class EstService : IEstService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigate;

        public EstService(HttpClient http, NavigationManager navigate)
        {
            _http = http;
            _navigate = navigate;
        }

        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public List<Categoria> Categorias { get ; set ; } = new List<Categoria>();

        public async Task GetCategorias()
        {
            var result = await _http.GetFromJsonAsync<List<Categoria>>("api/produto/categorias");
            Categorias = result;

        }

        public async Task<Produto> GetProduto(int id)
        {
            var result = await _http.GetFromJsonAsync<Produto>($"api/produto/{id}");
            return result;
        }             

        public async Task GetListProdutos()
        {

            var result = await _http.GetFromJsonAsync<List<Produto>>("api/produto");
            if (result != null) Produtos = result;
        }
        public void setProdutos(List<Produto> response)
        { 
             Produtos = response;
             _navigate.NavigateTo("produtos");
        }

        public async Task CreateNewProduto(Produto produto)
        {
            var result = await _http.PostAsJsonAsync("api/produto", produto);
            var response = await result.Content.ReadFromJsonAsync<List<Produto>>();
            setProdutos(response);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            var result = await _http.PutAsJsonAsync($"api/produto/{produto.Id}", produto);
            var response = await result.Content.ReadFromJsonAsync<List<Produto>>();
            setProdutos(response);
            Console.WriteLine(response);
        }

        public async Task DeleteProduto(int id)
        {
            var result = await _http.DeleteAsync($"api/produto/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Produto>>();
            setProdutos(response);
            Console.WriteLine(response);
        }

    

        

      
    }
}
