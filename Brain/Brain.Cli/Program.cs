using System.CommandLine;
using System.CommandLine.Invocation;
using Brain.Core.Entities; // Para a entidade Item
using System.Net.Http.Json; // Adicionado para PostAsJsonAsync

// Configuração da URL base da API
var apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? "http://localhost:5000"; // Fallback para dev local

var rootCommand = new RootCommand("Ferramenta CLI para interagir com o Brain API.");

// Comando 'a' (add)
var addCommand = new Command("a", "Adiciona um novo item.");

var tituloArgument = new Argument<string>("titulo", "O título do item.");
var descricaoArgument = new Argument<string>("descricao", "A descrição do item.");

addCommand.AddArgument(tituloArgument);
addCommand.AddArgument(descricaoArgument);

addCommand.SetHandler(async (context) =>
{
    var titulo = context.ParseResult.GetValueForArgument(tituloArgument);
    var descricao = context.ParseResult.GetValueForArgument(descricaoArgument);

    Console.WriteLine($"Adicionando item: Título='{titulo}', Descrição='{descricao}'");

    // Enviar para a API
    using var httpClient = new HttpClient();
    try
    {
        var item = new Item { Titulo = titulo, Descricao = descricao };
        var response = await httpClient.PostAsJsonAsync($"{apiBaseUrl}/itens", item);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Item adicionado com sucesso!");
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Erro ao adicionar item: {response.StatusCode} - {errorContent}");
        }
    }
    catch (HttpRequestException httpEx)
    {
        Console.WriteLine("API está desligada.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
    }
});

rootCommand.AddCommand(addCommand);

await rootCommand.InvokeAsync(args);
