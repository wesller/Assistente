using Brain.Cli.api;
using Brain.Core.dto;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Brain.Cli.cli
{
    public class CliListCommand : AsyncCommand<CliListCommand.Settings>
    {
        public class Settings : CommandSettings
        {
        }

        protected override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] Settings settings, CancellationToken cancellationToken)
        {
            var api = new ApiClient();
            var items = await api.GetItemsAsync();

            if (items == null || items.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]Nenhum item encontrado.[/]");
                return 0;
            }

            var table = new Table();
            table.Border(TableBorder.Ascii);
            
            table.AddColumn("ID");
            table.AddColumn("Título");
            table.AddColumn("Descrição");

            foreach (var item in items)
            {
                table.AddRow(item.Id.ToString(), item.Titulo, item.Descricao);
            }

            AnsiConsole.Write(table);

            return 0;
        }
    }
}
