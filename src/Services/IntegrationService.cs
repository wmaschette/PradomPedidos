using PedidosOmie;
using PedidosPradom.Models.AppPedidos.Model;
using PedidosPradom.Models.SuasVendas.V1;
using System.Text.RegularExpressions;

namespace PedidosPradom.Services
{
    public class IntegrationService(SuasVendasV1Service suasVendasV1, SuasVendasV2Service suasVendasV2, OmieService omieService)
    {
        private readonly SuasVendasV1Service _suasVendasV1 = suasVendasV1;
        private readonly SuasVendasV2Service _suasVendasV2 = suasVendasV2;
        private readonly OmieService _omieService = omieService;

        public async Task ImportarPedidosAsync(DateTime dataFiltro)
        {
            var pedidos = await _suasVendasV1.BuscarPedidosAsync(dataFiltro);

            if (pedidos.Count == 0)
                throw new Exception($"Nenhum pedido encontrado a partir da data {dataFiltro:dd-MM-yyyy HH:mm}");

            var pedidosComItem = pedidos.Where(x => x.PedidoItem != null);

            foreach (var pedido in pedidosComItem)
                await ProcessarPedidoV1(pedido);
        }
        public async Task ImportarPedidosAsync(int pedidoId = 0, DateTime? dataFiltro = null)
        {
            try
            {
                var pedido = await _suasVendasV2.BuscarPedidoAsync(pedidoId, dataFiltro)
                    ?? throw new Exception($"Nenhum pedido encontrado para o {(pedidoId > 0 ? $"código {pedidoId}" : $"filtro de data {dataFiltro:dd-MM-yyyy HH:mm}")}");

                await ProcessarPedidoV2(pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao importar pedidos. {(pedidoId > 0 ? $"Código: {pedidoId}" : $"Data: {dataFiltro:dd-MM-yyyy HH:mm}")}. Detalhes: {ex.Message}");
                throw;
            }
        }

        private async Task ProcessarPedidoV1(PedidoSuasVendasV1 pedido)
        {
            try
            {
                if (pedido.PediId == 51285)
                    Console.Write("Chegou");

                var cliente = await _suasVendasV1.BuscarClienteAsync((int)pedido.PediClieId);
                if (cliente == null || string.IsNullOrEmpty(cliente.cont_cnpj_cpf))
                    return;

                var cnpj = RemoverMascara(cliente.cont_cnpj_cpf);
                var clienteOmie = (await _omieService.BuscarClienteOmieAsync(cnpj)).clientes_cadastro?.FirstOrDefault();
                if (clienteOmie == null)
                    return;

                if (pedido.PedidoItem == null || pedido.PedidoItem.Length == 0)
                    return;

                var itensOmie = new List<det>();
                foreach (var item in pedido.PedidoItem ?? [])
                {
                    var produto = await _suasVendasV1.BuscarProdutoAsync((int)item.ProdutoId);
                    var produtoOmie = (await _omieService.BuscarProdutoOmieAsync(produto.prod_nome)).produto_servico_cadastro?.FirstOrDefault();
                    if (produtoOmie == null)
                        continue;

                    itensOmie.Add(_omieService.MontarItemOmie(item.ToOmieDto(), produtoOmie));
                }

                var pedidoOmie = _omieService.MontarPedidoOmie(pedido.PediId.ToString(), clienteOmie, itensOmie);
                await _omieService.IncluirPedidoOmieAsync(pedidoOmie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar pedido {pedido.PediId}: {ex.Message}");
            }
        }

        private async Task ProcessarPedidoV2(List<PedidoSuasVendasV2> pedidos)
        {
            foreach (var pedido in pedidos)
            {
                // Assumindo que o ID do cliente (pedi_cont_id) seja usado para buscar na API v1
                var cliente = await _suasVendasV2.BuscarClientePorIdAsync(pedido.pedi_cont_id);
                if (cliente == null || string.IsNullOrEmpty(cliente.CnpjCpf))
                    return;

                var cnpj = RemoverMascara(cliente.CnpjCpf);
                var clienteOmie = (await _omieService.BuscarClienteOmieAsync(cnpj)).clientes_cadastro?.FirstOrDefault();
                if (clienteOmie == null)
                    return;

                var itensOmie = new List<det>();
                foreach (var item in pedido.pedi_itens ?? new List<ItemPedido>())
                {
                    var produto = await _suasVendasV2.BuscarProdutoPorIndustriaIdAsync(item.ProdutoId); // ou da v2 se necessário
                    var produtoOmie = (await _omieService.BuscarProdutoOmieAsync(produto.Descricao)).produto_servico_cadastro?.FirstOrDefault();
                    if (produtoOmie == null)
                        continue;

                    itensOmie.Add(_omieService.MontarItemOmie(item.ToOmieDto(), produtoOmie));
                }

                var pedidoOmie = _omieService.MontarPedidoOmie(pedido.pedi_id.ToString(), clienteOmie, itensOmie);
                await _omieService.IncluirPedidoOmieAsync(pedidoOmie);
            }
        }

        private static string RemoverMascara(string documento)
        {
            return Regex.Replace(documento ?? "", @"\D", "");
        }
    }
}
