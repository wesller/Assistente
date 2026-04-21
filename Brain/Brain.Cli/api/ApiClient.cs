using Brain.Core.dto;
using System.Net.Http.Json;
using Brain.Core.Context;

namespace Brain.Cli.api
{
    public class ApiClient
    {
        private string apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? "http://localhost:5000";

        public void Send(ItemDto item)
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = httpClient.PostAsJsonAsync($"{apiBaseUrl}/itens", item, ItemContext.Default.ItemDto).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Item adicionado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Falha ao adicionar item. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar item: {ex.Message}");
            }
        }

        public async Task<List<ItemDto>> GetItemsAsync()
        {
            using var httpClient = new HttpClient();
            try
            {
                var items = await httpClient.GetFromJsonAsync($"{apiBaseUrl}/itens", ItemContext.Default.ListItemDto);
                return items ?? new List<ItemDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar itens: {ex.Message}");
                return new List<ItemDto>();
            }
        }
    }
}