using Brain.Core.Entities;
using Brain.Core.Interfaces;
using Brain.InfraEstrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace Brain.InfraEstrutura.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _context;

    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
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
        await _context.Itens.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Item item)
    {
        _context.Itens.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if (item != null)
        {
            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
