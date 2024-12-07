using AutoMapper;
using fiap.Data;
using fiap.Models;
using fiap.Services;
using fiap.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColetaController : ControllerBase
    {
        private readonly IColetaService _service;
        private readonly IMapper _mapper;

        public ColetaController(IColetaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ColetaPaginacaoReferenciaViewModel>> Get([FromQuery] int referencia = 0, [FromQuery] int tamanho = 10)
        {
            var coletas = _service.ListarColetasUltimaReferencia(referencia, tamanho);
            if (!coletas.Any())
                return NotFound("Nenhuma coleta encontrada.");

            var viewModelList = _mapper.Map<IEnumerable<ColetaViewModel>>(coletas);

            var viewModel = new ColetaPaginacaoReferenciaViewModel
            {
                Coletas = viewModelList,
                PageSize = tamanho,
                Ref = referencia,
                NextRef = viewModelList.Last().ColetaId
            };

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public ActionResult<ColetaViewModel> Get(int id)
        {
            var coleta = _service.ObterColetaPorId(id);
            if (coleta == null)
                return NotFound($"Coleta com ID {id} não encontrada.");

            var viewModel = _mapper.Map<ColetaViewModel>(coleta);
            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody] ColetaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var coleta = _mapper.Map<ColetaModel>(viewModel);
            _service.CriarColeta(coleta);
            return CreatedAtAction(nameof(Get), new { id = coleta.ColetaId }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Put(int id, [FromBody] ColetaViewModel viewModel)
        {
            if (id != viewModel.ColetaId)
                return BadRequest("O ID fornecido na URL não corresponde ao ID do recurso.");

            var coletaExistente = _service.ObterColetaPorId(id);
            if (coletaExistente == null)
                return NotFound($"Coleta com ID {id} não encontrada.");

            _mapper.Map(viewModel, coletaExistente);
            _service.AtualizarColeta(coletaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var coletaExistente = _service.ObterColetaPorId(id);
            if (coletaExistente == null)
                return NotFound($"Coleta com ID {id} não encontrada.");

            _service.DeletarColeta(id);
            return NoContent();
        }
    }
}
