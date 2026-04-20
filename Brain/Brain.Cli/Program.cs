using Brain.Cli.cli;
using Brain.Core.Entities; // Para a entidade Item
using Spectre.Console.Cli;
using System.Net.Http.Json;
using System.Net.Security; // Adicionado para PostAsJsonAsync



var app = new CommandApp();
app.Configure(config =>
{
    config.SetApplicationName("Brain CLI");
    config.SetApplicationVersion("1.0.0.0");

    config.AddCommand<CliAddService>("add")
        .WithDescription("Adiciona um novo item. Exemplo: a \"Título do Item\" \"Descrição do Item\"")
        .WithAlias("a")
        .WithExample(new[] { "add", "\"Título do Item\"", "\"Descrição do Item\"" });

#if DEBUG
    // Development-only settings
    config.PropagateExceptions();
    config.ValidateExamples();
#endif
});

await app.RunAsync(args);

//var apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? "http://localhost:5000"; // Fallback para dev local
//var opcao = new CliR
//var rootCommand = new RootCommand("Ferramenta CLI para interagir com o Brain API.");

//// Comando 'a' (add)
//var addCommand = new Command("a", "Adiciona um novo item.");

//var tituloArgument = new Argument<string>("O título do item.");
//var descricaoArgument = new Argument<string>("A descrição do item.");

//addCommand.Add(tituloArgument);
//addCommand.Add(descricaoArgument);

//addCommand.setHandler(async (context) =>
//{
//    var titulo = context.ParseResult.GetValueForArgument(tituloArgument);
//    var descricao = context.ParseResult.GetValueForArgument(descricaoArgument);

//    Console.WriteLine($"Adicionando item: Título='{titulo}', Descrição='{descricao}'");

//    // Enviar para a API
//    using var httpClient = new HttpClient();
//    try
//    {
//        var item = new Item { Titulo = titulo, Descricao = descricao };
//        var response = await httpClient.PostAsJsonAsync($"{apiBaseUrl}/itens", item);

//        if (response.IsSuccessStatusCode)
//        {
//            Console.WriteLine("Item adicionado com sucesso!");
//        }
//        else
//        {
//            var errorContent = await response.Content.ReadAsStringAsync();
//            Console.WriteLine($"Erro ao adicionar item: {response.StatusCode} - {errorContent}");
//        }
//    }
//    catch (HttpRequestException httpEx)
//    {
//        Console.WriteLine("API está desligada.");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
//    }
//});

//rootCommand.Add(addCommand);

//await rootCommand.InvokeAsync(args);
