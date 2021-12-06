using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UploadArquivo.Core.Entities;
using UploadArquivo.Core.Interface;
using UploadArquivo.Core.Request;
using UploadArquivo.Infraestrutura.Data;

namespace UploadArquivo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivosController : ControllerBase
    {
        private readonly IArquivoRepository _repository;

        public ArquivosController(IArquivoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Arquivos
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Arquivo>>> Get()
        {
            var arquivos = await _repository.GetArquivosAsync();
            if (arquivos == null)
            {
                return NotFound("Produtos não encontrados");
            }
            return Ok(arquivos);
        }

        // GET: api/Arquivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arquivo>> GetArquivo(long id)
        {
            var arquivo = await _repository.GetByIdAsync(id);

            if (arquivo == null)
            {
                return NotFound();
            }

            return arquivo;
        }

        // PUT: api/Arquivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<ActionResult> Put(long id, [FromBody] Arquivo arquivo)
        {
            if (id != arquivo.ArquivoId)
            {
                return BadRequest("Dados invalidos");
            }

            if (arquivo == null)
                return BadRequest("Dados invalidos");

            await _repository.UpdateAsync(arquivo);

            return Ok(arquivo);
        }

        
        // POST: api/Arquivos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ArquivoRequest request)
        {
            if (request == null)
                return BadRequest("Dados Invalidos");

            await _repository.CreateAsync(request);

            return new CreatedAtRouteResult("GetArquivo",
                new { id = request.ArquivoID }, request);
        }
        
        // DELETE: api/Arquivos/5
        [HttpDelete("{id}")]

        public async Task<ActionResult<Arquivo>> Delete(long id)
        {
            var arquivo = await _repository.GetByIdAsync(id);

            if (arquivo == null)
            {
                return NotFound("Arquivos não encontrados");
            }

            await _repository.RemoveAsync(id);

            return Ok(arquivo);
        }
    }
}
