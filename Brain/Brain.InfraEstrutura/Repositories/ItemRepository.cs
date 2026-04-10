using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Brain.Core.Entities;

namespace Brain.InfraEstrutura.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Itens.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Itens.ToListAsync();
        }

        public async Task AddAsync(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Itens.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Itens.FindAsync(id);
            if (item != null)
            {
                _context.Itens.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
