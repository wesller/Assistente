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

    config.AddCommand<CliListCommand>("list")
        .WithDescription("Lista todos os itens cadastrados.")
        .WithAlias("l");

#if DEBUG
    // Development-only settings
    config.PropagateExceptions();
    config.ValidateExamples();
#endif
});

await app.RunAsync(args);