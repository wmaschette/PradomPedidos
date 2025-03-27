using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PedidosPradom.Models.AppPedidos.Model;
using PedidosPradom.Models.SuasVendas.V1;
using System.Net;
using System.Net.Http;

namespace PedidosPradom.Services
{
    public class SuasVendasServiceOld
    {
        private readonly HttpClient _httpClient;
        private readonly string _tokenV1 = "Yoursoft 3YWv1XHVFmtdwE84sCbW1D12I6YQ1yopi85KvmnMWwHGl1F8q7twGX23e22lGH0Es7iDd2pCEg1nOH2Ih688wA7X007DVj0cPW2U-54B284E9185F5660C6C06D7DD5BB1A47E2D672F9";
        private readonly string _tokenV2 = "3YWv1XHVFmtdwE84sCbW1D12I6YQ1yopi85KvmnMWwHGl1F8q7twGX23e22lGH0Es7iDd2pCEg1nOH2Ih688wA7X007DVj0cPW2U-54B284E9185F5660C6C06D7DD5BB1A47E2D672F9";

        public SuasVendasServiceOld()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        private void ConfigurarApiV1()
        {
            _httpClient.BaseAddress = new Uri("https://api.suasvendas.com/api/");
            _httpClient.DefaultRequestHeaders.Add("Authorization", _tokenV1);
        }
        private void ConfigurarApiV2()
        {
            _httpClient.BaseAddress = new Uri("https://api.suasvendas.com/v2/Pedido/");
            _httpClient.DefaultRequestHeaders.Add("Token", _tokenV2);
        }

        public async Task<string> BuscarPedidos(DateTime dataFiltro)
        {
            try
            {
                ConfigurarApiV1();
                string dataFormatada = dataFiltro.ToString("yyyy-MM-ddTHH:mm");
                string endpoint = $"Pedido?dataHoraAtualizacao={dataFormatada}";

                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    return $"Erro ao buscar pedidos no SuasVendas. StatusCode: {(int)response.StatusCode}, Detalhes: {erro}";
                }

                var conteudo = await response.Content.ReadAsStringAsync();
                var pedidos = JsonConvert.DeserializeObject<List<PedidoSuasVendasV1>>(conteudo);

                if (pedidos == null || !pedidos.Any())
                    return "Nenhum pedido encontrado para a data selecionada!";

                // Aqui você pode processar os pedidos, salvar no banco etc.
                return "Pedidos importados com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro inesperado ao buscar pedidos: {ex.Message}";
            }
        }

        public async Task<string> BuscarPedidos(int idPedido)
        {
            try
            {
                // Configura API v2
                ConfigurarApiV2();

                string endpoint = $"?pedi_id={idPedido}";

                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    return $"Erro ao buscar pedido ID {idPedido} no SuasVendas. StatusCode: {(int)response.StatusCode}, Detalhes: {erro}";
                }

                var conteudo = await response.Content.ReadAsStringAsync();

                // Aqui você pode trocar o tipo conforme o modelo do pedido individual
                var pedido = JsonConvert.DeserializeObject<List<PedidoSuasVendasV2>>(conteudo);

                if (pedido == null)
                    return $"Pedido ID {idPedido} não encontrado ou resposta inválida.";

                // Processar o pedido se necessário

                return $"Pedido ID {idPedido} importado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro inesperado ao buscar pedido ID {idPedido}: {ex.Message}";
            }
        }

    }
}
