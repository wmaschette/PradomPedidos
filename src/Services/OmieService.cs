using ClientesOmie;
using ContaCorrenteCadastro;
using PedidosOmie;
using ProdutoOmie;
using System.ServiceModel.Channels;
using System.ServiceModel;
using PedidosPradom.Dtos;
using PedidosPradom.Models.SuasVendas.V2;

namespace PedidosPradom.Services
{
    public class OmieService
    {
        private readonly string _omieAppKey = "671905994760";
        private readonly string _omieAppSecret = "5b158a207a85d7f2688e9e9ea7f635e4";

        public async Task<clientes_listfull_response> BuscarClienteOmieAsync(string cnpj)
        {
            var client = new ClientesCadastroSoapClient();
            client.Endpoint.Address = AdicionarHeaders(client.Endpoint.Address);

            var filtro = new clientes_list_request
            {
                clientesFiltro = new clientesFiltro
                {
                    cnpj_cpf = cnpj
                }
            };

            return await client.ListarClientesAsync(filtro);
        }

        public async Task<produto_servico_listfull_response> BuscarProdutoOmieAsync(string descricao)
        {
            var client = new ProdutosCadastroSoapClient();
            client.Endpoint.Address = AdicionarHeaders(client.Endpoint.Address);

            var filtro = new produto_servico_list_request
            {
                pagina = "1",
                registros_por_pagina = "50",
                apenas_importado_api = "N",
                filtrar_apenas_omiepdv = "N",
                filtrar_apenas_descricao = "%" + descricao + "%"
            };

            return await client.ListarProdutosAsync(filtro);
        }

        public async Task<fin_conta_corrente_pesquisar_resposta> BuscarContaCorrenteOmieAsync()
        {
            var client = new ContaCorrenteCadastroSoapClient();
            client.Endpoint.Address = AdicionarHeaders(client.Endpoint.Address);

            return await client.PesquisarContaCorrenteAsync(new fin_conta_corrente_pesquisar());
        }

        public async Task IncluirPedidoOmieAsync(pedido_venda_produto pedido)
        {
            try
            {
                var client = new PedidoVendaProdutoSoapClient();
                client.Endpoint.Address = AdicionarHeaders(client.Endpoint.Address);

                await client.IncluirPedidoAsync(pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar pedido para Omie: {ex.Message}");
                if (!ex.Message.Contains("Pedido já cadastrado"))
                    throw;
            }
        }

        public det MontarItemOmie(ItemPedidoOmieDto item, produto_servico_cadastro produtoOmie)
        {
            return new det
            {
                ide = new ide
                {
                    codigo_item_integracao = item.Id.ToString(),
                    simples_nacional = "S"
                },
                inf_adic = new inf_adic
                {
                    peso_bruto = item.PesoBruto,
                    peso_liquido = item.PesoLiquido
                },
                produto = new produto
                {
                    codigo_produto = produtoOmie.codigo_produto,
                    unidade = produtoOmie.unidade,
                    quantidade = item.Quantidade,
                    quantidadeSpecified = true,
                    valor_mercadoria = item.Preco,
                    valor_unitario = item.Preco,
                    valor_unitarioSpecified = true,
                    valor_total = item.PrecoReal
                }
            };
        }

        public pedido_venda_produto MontarPedidoOmie(string codigoPedido, clientes_cadastro clienteOmie, List<det> itens)
        {
            decimal total = (decimal)itens.Sum(i => i.produto.valor_total);
            decimal totalMerc = (decimal)itens.Sum(i => i.produto.valor_mercadoria);

            var cabecalho = new cabecalho
            {
                bloqueado = "N",
                codigo_cliente = clienteOmie.codigo_cliente_omie,
                codigo_cliente_integracao = clienteOmie.codigo_cliente_integracao,
                codigo_pedido_integracao = codigoPedido,
                quantidade_itens = itens.Count.ToString(),
                data_previsao = DateTime.Now.ToString("dd/MM/yyyy")
            };

            var informacoesAdicionais = new informacoes_adicionais
            {
                codigo_conta_corrente = "625937280",
                codigo_categoria = "1.01.03",
                utilizar_emails = clienteOmie.email,
                enviar_email = "S",
                
            };

            var totalPedido = new total_pedido
            {
                valor_mercadorias = totalMerc,
                valor_total_pedido = total
            };

            return new pedido_venda_produto
            {
                cabecalho = cabecalho,
                informacoes_adicionais = informacoesAdicionais,
                det = [.. itens],
                total_pedido = totalPedido
            };
        }

        private EndpointAddress AdicionarHeaders(EndpointAddress endereco)
        {
            var builder = new EndpointAddressBuilder(endereco);
            builder.Headers.Add(AddressHeader.CreateAddressHeader("app_key", "", _omieAppKey));
            builder.Headers.Add(AddressHeader.CreateAddressHeader("app_secret", "", _omieAppSecret));
            return builder.ToEndpointAddress();
        }
    }
}
