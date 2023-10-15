using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;
        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Usuario entity, Endereco endereco)
        {
            entity.Enderecos = new List<Endereco> { endereco };
            _context.Add(entity);
            await 
                _context.SaveChangesAsync();
        }
        public async Task<IList<Usuario>> GetAllAsync()
        {
            return 
                await _context.Usuarios
                    .Include(e=>e.Enderecos)
                    .ToListAsync();      
        }

        public async Task<Usuario> GetByIdAsync(int entityId)
        {
            return
                await _context.Usuarios
                    .Include(e => e.Enderecos)
                    .SingleOrDefaultAsync(e => e.Id == entityId);
        }

        public async Task UpdateAsync(Usuario entity)
        {
            var existingUser = await _context.Usuarios
                .Include(e => e.Enderecos)
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(entity);
                await 
                    _context.SaveChangesAsync();
            }    
        }

        public async Task DeleteAsync(int entityId)
        {
           var existingUser = await _context.Usuarios
                .Include(e => e.Enderecos)
                .FirstOrDefaultAsync(e => e.Id == entityId);

            if(existingUser != null)
            {
                _context.Usuarios.Remove(existingUser);
                await 
                    _context.SaveChangesAsync();  
            }    
        }

        public bool InscreverUsuarioEmVoluntariado(int usuarioId, int voluntariadoId)
        {
            throw new NotImplementedException();

        }

        public bool CancelarInscricaoUsuarioEmVoluntariado(int usuarioId, int voluntariadoId)
        {
            throw new NotImplementedException();
        }

    }
}