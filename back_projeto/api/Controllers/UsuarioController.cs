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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuarioDTOs = _mapper.Map<IList<UsuarioDTO>>(usuarios);

            return
                HttpMessageOk(usuarioDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return
                HttpMessageOk(usuarioDTO);
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateAsync([FromBody] UsuarioViewModel createModel)
        // {
        //     if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

        //     var usuario = _mapper.Map<Usuario>(createModel);
        //     var endereco = _mapper.Map<Endereco>(createModel);

        //     await _usuarioRepository.CreateAsync(usuario, endereco);

        //     var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
        //     return HttpMessageOk(usuarioDTO);
        // }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UsuarioViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var usuario = _mapper.Map<Usuario>(createModel);

            // Mapeie os endereços de UsuarioViewModel para Endereco
            var enderecos = _mapper.Map<List<Endereco>>(createModel.EnderecoViews);

            // Associe os endereços ao usuário
            usuario.Enderecos = enderecos;

            // Salve o usuário e os endereços no banco de dados
            await _usuarioRepository.CreateAsync(usuario , enderecos.FirstOrDefault());

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return HttpMessageOk(usuarioDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, UsuarioViewModel model )
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            
            var usuario = _mapper.Map<Usuario>(model);
            usuario.Id = id;
            await _usuarioRepository.UpdateAsync(usuario);

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return
                HttpMessageOk(usuarioDTO);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            await _usuarioRepository.DeleteAsync(id);
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