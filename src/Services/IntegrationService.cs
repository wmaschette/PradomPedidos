using PedidosOmie;
using PedidosPradom.Models.AppPedidos.Model;
using PedidosPradom.Models.SuasVendas.V1;
using System.Text.RegularExpressions;

namespace PedidosPradom.Services
{
    public class IntegrationService
    {
        private readonly SuasVendasV1Service _suasVendasV1;
        private readonly SuasVendasV2Service _suasVendasV2;
        private readonly OmieService _omieService;

        public IntegrationService(SuasVendasV1Service suasVendasV1, SuasVendasV2Service suasVendasV2, OmieService omieService)
        {
            _suasVendasV1 = suasVendasV1;
            _suasVendasV2 = suasVendasV2;
            _omieService = omieService;
        }

        public async Task ImportarPedidosAsync(DateTime? dataFiltro = null, int? codigoPedido = null)
        {
            if (codigoPedido.HasValue)
            {
                var pedido = await _suasVendasV2.BuscarPedidoPorIdAsync(codigoPedido.Value);
                if (pedido == null)
                    throw new Exception($"Nenhum pedido encontrado para o código {codigoPedido}");

                await ProcessarPedidoV2(pedido);
            }
            else if (dataFiltro.HasValue)
            {
                var pedidos = await _suasVendasV1.BuscarPedidosAsync(dataFiltro.Value);

                if (!pedidos.Any())
                    throw new Exception($"Nenhum pedido encontrado para o código {codigoPedido}");

                foreach (var pedido in pedidos)
                    await ProcessarPedidoV1(pedido);
            }
        }

        private async Task ProcessarPedidoV1(PedidoSuasVendasV1 pedido)
        {
            var cliente = await _suasVendasV1.BuscarClienteAsync((int)pedido.PediClieId);
            if (cliente == null || string.IsNullOrEmpty(cliente.cont_cnpj_cpf))
                return;

            var cnpj = RemoverMascara(cliente.cont_cnpj_cpf);
            var clienteOmie = (await _omieService.BuscarClienteOmieAsync(cnpj)).clientes_cadastro?.FirstOrDefault();
            if (clienteOmie == null)
                return;

            var itensOmie = new List<det>();
            foreach (var item in pedido.PedidoItem ?? Array.Empty<PedidoItem>())
            {
                var produto = await _suasVendasV1.BuscarProdutoAsync((int)item.ProdutoId);
                var produtoOmie = (await _omieService.BuscarProdutoOmieAsync(produto.prod_nome)).produto_servico_cadastro?.FirstOrDefault();
                if (produtoOmie == null)
                    continue;

                itensOmie.Add(_omieService.MontarItemOmie(item.ToOmieDto(), produtoOmie));
            }

            var pedidoOmie = _omieService.MontarPedidoOmie(pedido.PediId.ToString(), clienteOmie, itensOmie);
            //await _omieService.IncluirPedidoOmieAsync(pedidoOmie);
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
