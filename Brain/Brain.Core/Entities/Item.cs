namespace Brain.Core.Entities;

/// <summary>
/// Representa um item armazenado no banco de dados.
/// </summary>
public class Item
{
    /// <summary>
    /// Identificador único (Auto-incrementado no banco de dados).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Título do item.
    /// </summary>
    public string Titulo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição detalhada do item.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;
}
