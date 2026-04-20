using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Brain.Cli.cli
{
    public class CliAddSettings : CommandSettings
    {
        [CommandArgument(0, "<TITULO>")]
        [Description("Titulo")]
        public string Titulo { get; set; }

        [CommandArgument(1, "<DESCRICAO>")]
        [Description("Descrição")]
        public string Descricao { get; set; }
    }
}
