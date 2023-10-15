using Domain.Entities;
using Domain.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class VoluntariadoRepository : IVoluntariadoRepository
    {
        private readonly DataContext _context;
        public VoluntariadoRepository(DataContext context)
        {
            _context = context;
        }
      
        public async Task CreateAsync(Voluntariado entity, Instituto institutoId)
        {
           var instituto = await _context.Institutos.FindAsync(institutoId);

            if (instituto != null)
            {
                entity.InstitutoId = instituto.Id;
                entity.Instituto = instituto;
               
                _context.Voluntariados.Add(entity);
                await 
                    _context.SaveChangesAsync();
            }
        }
        public async Task<IList<Voluntariado>> GetAllAsync()
        {
           return
                await _context.Voluntariados
                    .Include(i => i.Instituto)
                    .ToListAsync();
        }

        public async Task<Voluntariado> GetByIdAsync(int entityId)
        {
            return
                await _context.Voluntariados
                    .Include(i => i.Instituto)
                    .SingleOrDefaultAsync(v => v.Id == entityId);
        }

        public Task UpdateAsync(Voluntariado entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }


        //Voluntarido Inscricao
        public Task InscreverUsuarioAsync(int voluntariadoId, int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task CancelarInscricaoUsuarioAsync(int voluntariadoId, int usuarioId)
        {
            throw new NotImplementedException();
        }

    }
}