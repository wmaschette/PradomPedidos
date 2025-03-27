using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PedidosPradom.Models.AppPedidos.Model;
using PedidosPradom.Models.SuasVendas.V1;
using System.Net;
using System.Net.Http;

namespace PedidosPradom.Services
{
    public class SuasVendasV1Service
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrlV1 = "https://api.suasvendas.com/api/";
        private const string TokenV1 = "Yoursoft 3YWv1XHVFmtdwE84sCbW1D12I6YQ1yopi85KvmnMWwHGl1F8q7twGX23e22lGH0Es7iDd2pCEg1nOH2Ih688wA7X007DVj0cPW2U-54B284E9185F5660C6C06D7DD5BB1A47E2D672F9";

        public SuasVendasV1Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", TokenV1);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<PedidoSuasVendasV1>> BuscarPedidosAsync(DateTime dataFiltro)
        {
            try
            {
                string dataFormatada = dataFiltro.ToString("yyyy-MM-ddTHH:mm");
                string endpoint = $"{BaseUrlV1}Pedido?dataHoraAtualizacao={dataFormatada}";

                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao buscar pedidos: {erro}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var pedidos = JsonConvert.DeserializeObject<List<PedidoSuasVendasV1>>(json);

                return pedidos ?? new List<PedidoSuasVendasV1>();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Pedido SuasVendas.", ex);
            }
        }

        public async Task<ClienteSuasVendas> BuscarClienteAsync(int clienteId)
        {
            try
            {
                string endpoint = $"{BaseUrlV1}Conta/id?cont_id={clienteId}";
                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao buscar cliente ID {clienteId}: {erro}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<ClienteSuasVendas>(json);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Cliente SuasVendas.", ex);
            }
        }

        public async Task<ProdutoSuasVendas> BuscarProdutoAsync(int produtoId)
        {
            try
            {
                string endpoint = $"{BaseUrlV1}Produto/id?prod_id={produtoId}";
                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao buscar produto ID {produtoId}: {erro}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var produto = JsonConvert.DeserializeObject<ProdutoSuasVendas>(json);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Produto SuasVendas.", ex);
            }
        }

    }
}
