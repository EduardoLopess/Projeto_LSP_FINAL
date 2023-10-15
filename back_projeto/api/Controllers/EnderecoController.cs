using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        public EnderecoController(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var endereco = await _enderecoRepository.GetAllAsync();
            var enderecoDTOs = _mapper.Map<IList<EnderecoDTO>>(endereco);

            return
                HttpMessageOk(enderecoDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            if (endereco == null) return NotFound();

            var enderecoDTO = _mapper.Map<EnderecoDTO>(endereco);
            return
                HttpMessageOk(enderecoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EnderecoViewModel enderecoModel, int usuarioId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados incorretos");
            }
            var endereco = _mapper.Map<Endereco>(enderecoModel);
            
            try
            {
                await _enderecoRepository.CreateAsync(endereco, usuarioId);
                return Ok("Endereço criado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, EnderecoViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var endereco = _mapper.Map<Endereco>(model);
            endereco.Id = id;
            await _enderecoRepository.UpdateAsync(endereco);

            var enderecoDTO = _mapper.Map<EnderecoDTO>(endereco);
            return
                HttpMessageOk(enderecoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            if (endereco == null) return NotFound();

            await _enderecoRepository.DeleteAsync(id);
            return
                HttpMessageOk(id);
        }


        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
                return NoContent();
            else
                return Ok(new { data });
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new { message });
        }
    }
}