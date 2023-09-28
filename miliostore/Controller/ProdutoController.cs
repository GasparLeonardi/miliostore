using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using miliostore.Model;
using miliostore.Service;

namespace miliostore.Controller
{
    [Route("~/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IValidator<Produto> _produtoValidator;

        public ProdutoController(
            IProdutoService produtoService, 
            IValidator<Produto> postagemValidator)
        {
            _produtoService = produtoService;
            _produtoValidator = postagemValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _produtoService.GetById(id);
            if (Resposta is null)
            {
                return NotFound();
            }
            return Ok(Resposta);
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            return Ok(await _produtoService.GetByNome(nome));
        }

        [HttpGet("console/{console}")]
        public async Task<ActionResult> GetByConsole(string console)
        {
            return Ok(await _produtoService.GetByConsole(console));
        }

        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _produtoValidator.ValidateAsync(produto);
            
            if (!validarProduto.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);
            }
            
            var Resposta = await _produtoService.Create(produto);

            if (Resposta is null)
                return BadRequest("Categoria não encontrada!");

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if (produto.Id == 0)
                return BadRequest("Id do Produto é Invalido");

            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Update(produto);

            if (Resposta is null)
                return NotFound("Produto e/ou Categoria Não Encontrados !!");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscarProduto = await _produtoService.GetById(id);

            if (BuscarProduto is null)
                return NotFound("Produto não Encontrado.");

            await _produtoService.Delete(BuscarProduto);

            return NoContent();
        }
    }
}
