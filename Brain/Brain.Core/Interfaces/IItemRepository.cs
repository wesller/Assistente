using Brain.Core.Entities;

namespace Brain.Core.Interfaces;

/// <summary>
/// Interface para o repositório de itens.
/// </summary>
public interface IItemRepository
{
    /// <summary>
    /// Obtém um item pelo ID.
    /// </summary>
    /// <param name="id">O ID do item.</param>
    /// <returns>O item encontrado ou null se não encontrado.</returns>
    Task<Item?> GetByIdAsync(int id);

    /// <summary>
    /// Obtém todos os itens.
    /// </summary>
    /// <returns>Uma coleção de itens.</returns>
    Task<IEnumerable<Item>> GetAllAsync();

    /// <summary>
    /// Adiciona um novo item.
    /// </summary>
    /// <param name="item">O item a ser adicionado.</param>
    Task AddAsync(Item item);

    /// <summary>
    /// Atualiza um item existente.
    /// </summary>
    /// <param name="item">O item a ser atualizado.</param>
    Task UpdateAsync(Item item);

    /// <summary>
    /// Exclui um item pelo ID.
    /// </summary>
    /// <param name="id">O ID do item a ser excluído.</param>
    Task DeleteAsync(int id);
}
