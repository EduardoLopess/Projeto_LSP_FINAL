using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DataContext _context;
        public EnderecoRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task CreateAsync(Endereco entity, int usuarioId)
        {
            entity.UsuarioId = usuarioId;
            _context.Enderecos.Add(entity);
            await
                 _context.SaveChangesAsync();

        }
        public async Task<IList<Endereco>> GetAllAsync()
        {
            return
                await _context.Enderecos
                    .Include(u => u.Usuario)
                    .ToListAsync();
        }

        public async Task<Endereco> GetByIdAsync(int entityId)
        {
            return
                await _context.Enderecos
                    .Include(u => u.Usuario)
                    .SingleOrDefaultAsync(u => u.Id == entityId);
        }

        public async Task UpdateAsync(Endereco entity)
        {
            var existingEndereco = await _context.Enderecos
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(u => u.Id == entity.Id);

            if(existingEndereco != null)
            {
                _context.Entry(existingEndereco).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }    
        }

        public async Task DeleteAsync(int entityId)
        {
           var existingEndereco = await _context.Enderecos
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(u => u.Id == entityId);

            if(existingEndereco != null)
            {
                _context.Enderecos.Remove(existingEndereco);
                await
                    _context.SaveChangesAsync();
            }    
        }
        

    

    }
}