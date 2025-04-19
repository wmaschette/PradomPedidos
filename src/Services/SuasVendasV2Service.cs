using Newtonsoft.Json;
using PedidosPradom.Models.AppPedidos.Model;
using PedidosPradom.Models.SuasVendas.V2;

namespace PedidosPradom.Services
{
    public class SuasVendasV2Service
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.suasvendas.com/v2/";
        private const string Token = "3YWv1XHVFmtdwE84sCbW1D12I6YQ1yopi85KvmnMWwHGl1F8q7twGX23e22lGH0Es7iDd2pCEg1nOH2Ih688wA7X007DVj0cPW2U-54B284E9185F5660C6C06D7DD5BB1A47E2D672F9";

        public SuasVendasV2Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Token", Token);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<PedidoSuasVendasV2>> BuscarPedidoAsync(int pedidoId = 0, DateTime? dataFiltro = null)
        {
            try
            {
                if (pedidoId <= 0 && dataFiltro == null)
                    throw new ArgumentException("É necessário informar um ID de pedido ou uma data de filtro.");

                var dataAtual = TimeZoneInfo.ConvertTimeFromUtc(
                    DateTime.UtcNow,
                    TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")
                );

                string endpoint = $"{BaseUrl}Pedido/";
                endpoint += pedidoId > 0
                    ? $"?pedi_id={pedidoId}"
                    : $"/{dataFiltro?.ToString("yyyy-MM-dd")}/{dataAtual:yyyy-MM-dd}";

                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao buscar pedido ID {pedidoId}: {erro}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var pedidos = JsonConvert.DeserializeObject<List<PedidoSuasVendasV2>>(json);

                return pedidos ?? [];
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Pedido SuasVendas.", ex);
            }
        }

        public async Task<ClienteSuasVendasV2?> BuscarClientePorIdAsync(int clienteId)
        {
            try
            {
                string endpoint = $"{BaseUrl}Cliente/?cont_id={clienteId}";

                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao buscar cliente ID {clienteId}: {erro}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<List<ClienteSuasVendasV2>>(json);
                return cliente?.FirstOrDefault();



            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Cliente SuasVendas V2.", ex);
            }
        }

        public async Task<ProdutoSuasVendasV2?> BuscarProdutoPorIndustriaIdAsync(int industriaId)
        {
            try
            {
                string endpoint = $"{BaseUrl}Produto/?prod_id={industriaId}";

                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao buscar produto para indústria ID {industriaId}: {erro}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var produto = JsonConvert.DeserializeObject<List<ProdutoSuasVendasV2>>(json);
                return produto?.FirstOrDefault();


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Produto SuasVendas V2.", ex);
            }
        }
    }
}
