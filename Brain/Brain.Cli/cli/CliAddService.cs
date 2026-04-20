using Brain.Cli.api;
using Brain.Core.dto;
using Brain.Core.Entities;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brain.Cli.cli
{
    public class CliAddService : Command<CliAddSettings>
    {
        protected override int Execute(CommandContext context, CliAddSettings settings, CancellationToken cancellationToken)
        {
           System.Console.WriteLine($"Titulo: {settings.Titulo}");
           System.Console.WriteLine($"Descrição: {settings.Descricao}");
            
            ItemDto item = new ItemDto
            {
                Titulo = settings.Titulo,
                Descricao = settings.Descricao
            };
            ApiClient api = new ApiClient();
            api.Send(item);
            return 0;
        }
    }
}
