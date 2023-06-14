using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalCRUD.Server.Data;
using TrabalhoFinalCRUD.Shared.Models;

namespace TrabalhoFinalCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly DataContext _db;

        public EstoqueController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            var produtos = await _db.Produtos.Include(sh => sh.Categoria).ToListAsync();  
            return Ok(produtos);
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategorias()
        {
            var categorias = await _db.Categorias.ToListAsync();
            return Ok(categorias);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _db.Produtos.Include(sh => sh.Categoria).FirstOrDefaultAsync(h => h.Id == id);
            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduto(Produto produto)
        {
            produto.Categoria = null;
            _db.Produtos.Add(produto);
            await _db.SaveChangesAsync();

            return Ok(await GetDBProdutos());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> AtualizarProduto(Produto produto, int id)
        {
            var produtoDB = await _db.Produtos.Include(sh => sh.Categoria).FirstOrDefaultAsync(h => h.Id == id);
            if(produtoDB == null) return NotFound();

            produtoDB.NomeProduto = produto.NomeProduto;
            produtoDB.ValorProduto = produto.ValorProduto;
            produtoDB.CategoriaId = produto.CategoriaId;
            await _db.SaveChangesAsync();

            return Ok(await GetDBProdutos());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteProduto(int id)
        {
            var produtoDB = await _db.Produtos.Include(sh => sh.Categoria).FirstOrDefaultAsync(h => h.Id == id);
            if (produtoDB == null) return NotFound();

            _db.Produtos.Remove(produtoDB);
            await _db.SaveChangesAsync();

            return Ok(await GetDBProdutos());

        }

        private async Task<List<Produto>> GetDBProdutos()
        {
            return await _db.Produtos.Include(sh => sh.Categoria).ToListAsync();
        }
    }

}

