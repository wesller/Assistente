using Brain.Core.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Brain.Core.Context
{
    [JsonSerializable(typeof(ItemDto))]
    [JsonSerializable(typeof(List<ItemDto>))]
    public partial class ItemContext : JsonSerializerContext
    {
    }
}
