using ClientesOmie;
using ContaCorrenteCadastro;
using PedidosOmie;
using ProdutoOmie;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using PedidosPradom.Models.SuasVendas.V1;

namespace PedidosPradom.Services
{
    public class IntegrationServiceOld
    {
        //protected JsonSerializerSettings MicrosoftDateFormatSettings = new JsonSerializerSettings
        //{
        //    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
        //    DateTimeZoneHandling = DateTimeZoneHandling.Local
        //};

        //private string _suasVendasToken = "Yoursoft 3YWv1XHVFmtdwE84sCbW1D12I6YQ1yopi85KvmnMWwHGl1F8q7twGX23e22lGH0Es7iDd2pCEg1nOH2Ih688wA7X007DVj0cPW2U-54B284E9185F5660C6C06D7DD5BB1A47E2D672F9";
        //private string _omieKey = "671905994760";
        //private string _omieSecret = "5b158a207a85d7f2688e9e9ea7f635e4";

        ////public void GetPedidos(int minutos = 20)
        ////{
        ////    string resultado;
        ////    HttpStatusCode status;
        ////    var pedidos = new List<PedidoSuasVendas>();
        ////    string data;
        ////    using (var restClient = new RestClientDispose("https://api.suasvendas.com/api/"))
        ////    {
        ////        restClient.AddDefaultHeader("Content-Type", "application/json");
        ////        restClient.AddDefaultHeader("Accept", "application/json");
        ////        restClient.AddDefaultHeader("Authorization", "Yoursoft 3YWv1XHVFmtdwE84sCbW1D12I6YQ1yopi85KvmnMWwHGl1F8q7twGX23e22lGH0Es7iDd2pCEg1nOH2Ih688wA7X007DVj0cPW2U-54B284E9185F5660C6C06D7DD5BB1A47E2D672F9");

        ////        if (DateTime.Now.Hour < 9)
        ////            minutos = 840;

        ////        minutos = -1 * minutos;
        ////        data = DateTime.Now.AddMinutes(minutos).ToString("yyyy-MM-ddTHH:mm");
        ////        string uri = "Pedido?dataHoraAtualizacao=" + data;
        ////        //string uri = "Colaborador";
        ////        var request = new RestRequest(uri, Method.GET);

        ////        var response = restClient.Execute(request);

        ////        resultado = response.Content;

        ////        status = response.StatusCode;
        ////    }

        ////    if (status == HttpStatusCode.OK)
        ////    {
        ////        pedidos = JsonConvert.DeserializeObject<List<PedidoSuasVendas>>(resultado);
        ////    }

        ////    if (pedidos.Count > 0)
        ////    {
        ////        pedidos = pedidos.Where(x => Convert.ToDateTime(x.YsDatahoraInsercao.ToString("yyyy-MM-ddTHH:mm")) >= Convert.ToDateTime(data)).ToList();
        ////        if (pedidos.Count > 0)
        ////            LoadObjectPedidoPost(pedidos);
        ////    }
        ////}
        //public async Task GetPedidosAsync(DateTime dataFiltro)
        //{
        //    string resultado;
        //    HttpStatusCode status;
        //    var pedidos = new List<PedidoSuasVendasV1>();
        //    string data;
        //    using (var restClient = new RestClient("https://api.suasvendas.com/api/"))
        //    {
        //        var request = new RestRequest("Pedido?dataHoraAtualizacao=" + dataFiltro.ToString("yyyy-MM-ddTHH:mm"), Method.Get);
        //        request.AddHeader("Content-Type", "application/json");
        //        request.AddHeader("Accept", "application/json");
        //        request.AddHeader("Authorization", _suasVendasToken);

        //        var response = await restClient.ExecuteAsync(request);
        //        resultado = response.Content;
        //        status = response.StatusCode;
        //    }

        //    if (status == HttpStatusCode.OK)
        //    {
        //        pedidos = JsonConvert.DeserializeObject<List<PedidoSuasVendasV1>>(resultado);
        //    }

        //    if (pedidos.Count > 0)
        //    {
        //        await LoadObjectPedidoPost(pedidos);
        //    }
        //}

        ////public ClienteSuasVendas GetClienteSuasVendas(int clienteId)
        ////{
        ////    string resultado;
        ////    HttpStatusCode status;
        ////    var cliente = new ClienteSuasVendas();
        ////    using (var restClient = new RestClientDispose("https://api.suasvendas.com/api/"))
        ////    {
        ////        restClient.AddDefaultHeader("Content-Type", "application/json");
        ////        restClient.AddDefaultHeader("Accept", "application/json");
        ////        restClient.AddDefaultHeader("Authorization", "Yoursoft 3YWv1XHVFmtdwE84sCbW1D12I6YQ1yopi85KvmnMWwHGl1F8q7twGX23e22lGH0Es7iDd2pCEg1nOH2Ih688wA7X007DVj0cPW2U-54B284E9185F5660C6C06D7DD5BB1A47E2D672F9");

        ////        string uri = "Conta/id?cont_id=" + clienteId;
        ////        var request = new RestRequest(uri, Method.Get);

        ////        var response = restClient.Execute(request);

        ////        resultado = response.Content;

        ////        status = response.StatusCode;
        ////    }

        ////    if (status == HttpStatusCode.OK)
        ////    {
        ////        cliente = JsonConvert.DeserializeObject<ClienteSuasVendas>(resultado);
        ////    }

        ////    return cliente;
        ////}
        //public async Task<ClienteSuasVendas> GetClienteSuasVendasAsync(int clienteId)
        //{
        //    string resultado;
        //    HttpStatusCode status;
        //    var cliente = new ClienteSuasVendas();
        //    using (var restClient = new RestClient("https://api.suasvendas.com/api/"))
        //    {
        //        var request = new RestRequest("Conta/id?cont_id=" + clienteId, Method.Get);
        //        request.AddHeader("Content-Type", "application/json");
        //        request.AddHeader("Accept", "application/json");
        //        request.AddHeader("Authorization", _suasVendasToken);

        //        var response = await restClient.ExecuteAsync(request);
        //        resultado = response.Content;
        //        status = response.StatusCode;
        //    }

        //    if (status == HttpStatusCode.OK)
        //    {
        //        cliente = JsonConvert.DeserializeObject<ClienteSuasVendas>(resultado);
        //    }

        //    return cliente;
        //}

        ////public ProdutoSuasVendas GetProdutoPorId(int produtoId)
        ////{
        ////    string resultado;
        ////    HttpStatusCode status;
        ////    var produto = new ProdutoSuasVendas();
        ////    using (var restClient = new RestClientDispose("https://api.suasvendas.com/api/"))
        ////    {
        ////        restClient.AddDefaultHeader("Content-Type", "application/json");
        ////        restClient.AddDefaultHeader("Accept", "application/json");
        ////        restClient.AddDefaultHeader("Authorization", "Yoursoft 3YWv1XHVFmtdwE84sCbW1D12I6YQ1yopi85KvmnMWwHGl1F8q7twGX23e22lGH0Es7iDd2pCEg1nOH2Ih688wA7X007DVj0cPW2U-54B284E9185F5660C6C06D7DD5BB1A47E2D672F9");

        ////        string uri = "Produto/id?prod_id=" + produtoId;
        ////        var request = new RestRequest(uri, Method.GET);

        ////        var response = restClient.Execute(request);

        ////        resultado = response.Content;

        ////        status = response.StatusCode;
        ////    }

        ////    if (status == HttpStatusCode.OK)
        ////    {
        ////        produto = JsonConvert.DeserializeObject<ProdutoSuasVendas>(resultado);
        ////    }

        ////    return produto;

        ////}
        //public async Task<ProdutoSuasVendas> GetProdutoPorIdAsync(int produtoId)
        //{
        //    string resultado;
        //    HttpStatusCode status;
        //    var produto = new ProdutoSuasVendas();
        //    using (var restClient = new RestClient("https://api.suasvendas.com/api/"))
        //    {
        //        var request = new RestRequest("Produto/id?prod_id=" + produtoId, Method.Get);
        //        request.AddHeader("Content-Type", "application/json");
        //        request.AddHeader("Accept", "application/json");
        //        request.AddHeader("Authorization", _suasVendasToken);

        //        var response = await restClient.ExecuteAsync(request);
        //        resultado = response.Content;
        //        status = response.StatusCode;
        //    }

        //    if (status == HttpStatusCode.OK)
        //    {
        //        produto = JsonConvert.DeserializeObject<ProdutoSuasVendas>(resultado);
        //    }

        //    return produto;
        //}

        //protected async Task LoadObjectPedidoPost(List<PedidoSuasVendasV1> pedidosGet)
        //{
        //    foreach (PedidoSuasVendasV1 pget in pedidosGet)
        //    {
        //        var clienteSV = await GetClienteSuasVendasAsync((int)pget.PediClieId);
        //        if (String.IsNullOrEmpty(clienteSV.cont_cnpj_cpf))
        //            return;

        //        string cnpjCliente = RemoveSpecialCharacters(clienteSV.cont_cnpj_cpf);
        //        var cliOmie = (await GetClienteOmie(cnpjCliente)).clientes_cadastro[0];

        //        var listDetalhe = new List<det>();
        //        decimal total = 0;
        //        decimal totalMerc = 0;
        //        if (pget.PedidoItem is null)
        //            continue;

        //        foreach (PedidoItem item in pget.PedidoItem)
        //        {
        //            var prodSV = await GetProdutoPorIdAsync((int)item.PeitProdId);
        //            var prodOmie = (await GetProdutoOmie(prodSV.prod_nome)).produto_servico_cadastro[0];
        //            var d = new det()
        //            {
        //                ide = new ide()
        //                {
        //                    codigo_item_integracao = item.PeitId.ToString(),
        //                    simples_nacional = "S"
        //                },
        //                inf_adic = new inf_adic()
        //                {
        //                    peso_bruto = item.PeitPesoBruto,
        //                    peso_liquido = item.PeitPesoLiquido
        //                },
        //                produto = new produto()
        //                {
        //                    codigo_produto = prodOmie.codigo_produto.ToString(),
        //                    quantidade = item.PeitQtde,
        //                    quantidadeSpecified = true,
        //                    valor_mercadoria = Convert.ToDecimal(item.PeitPreco),
        //                    valor_unitario = Convert.ToDecimal(item.PeitPreco),
        //                    valor_unitarioSpecified = true,
        //                    valor_total = Convert.ToDecimal(item.PeitPrecoReal),
        //                    unidade = prodOmie.unidade
        //                }
        //            };
        //            if (d.produto.quantidade == 0 || d.produto.quantidade == null)
        //                d.produto.quantidade = item.PeitQtde;
        //            listDetalhe.Add(d);
        //            total += Convert.ToDecimal(item.PeitPrecoReal);
        //            totalMerc += Convert.ToDecimal(item.PeitPreco);
        //        }

        //        var pedido = new pedido_venda_produto()
        //        {
        //            cabecalho = new cabecalho()
        //            {
        //                bloqueado = "N",
        //                codigo_cliente = cliOmie.codigo_cliente_omie,
        //                codigo_cliente_integracao = cliOmie.codigo_cliente_integracao,
        //                codigo_pedido_integracao = pget.PediId.ToString(),
        //                quantidade_itens = pget.PedidoItem.Count().ToString(),
        //                data_previsao = DateTime.Now.ToString("dd/MM/yyyy")
        //            },
        //            informacoes_adicionais = new informacoes_adicionais()
        //            {
        //                codigo_conta_corrente = "618999666",
        //                codigo_categoria = "1.01.03",
        //                utilizar_emails = cliOmie.email
        //            },
        //            det = listDetalhe.ToArray(),
        //            total_pedido = new total_pedido()
        //            {
        //                valor_mercadorias = totalMerc,
        //                valor_total_pedido = total
        //            }
        //        };

        //        await PostPedidoOmie(pedido);
        //    }
        //}
        //protected async Task PostPedidoOmie(pedido_venda_produto pedido)
        //{
        //    try
        //    {
        //        var soapClient = new PedidoVendaProdutoSoapClient();
        //        var builder = new EndpointAddressBuilder(soapClient.Endpoint.Address);
        //        builder.Headers.Add(AddressHeader.CreateAddressHeader("app_key", "", _omieKey));
        //        builder.Headers.Add(AddressHeader.CreateAddressHeader("app_secret", "", _omieSecret));
        //        soapClient.Endpoint.Address = builder.ToEndpointAddress();
        //        // string ped = JsonConvert.SerializeObject(pedido);
        //        var response = await soapClient.IncluirPedidoAsync(pedido);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro ao enviar pedido: {ex.Message}");
        //    }
        //}
        //protected async Task<clientes_listfull_response> GetClienteOmie(string cnpj)
        //{
        //    var soapClient = new ClientesCadastroSoapClient();
        //    var builder = new EndpointAddressBuilder(soapClient.Endpoint.Address);
        //    builder.Headers.Add(AddressHeader.CreateAddressHeader("app_key", "", _omieKey));
        //    builder.Headers.Add(AddressHeader.CreateAddressHeader("app_secret", "", _omieSecret));
        //    soapClient.Endpoint.Address = builder.ToEndpointAddress();
        //    var cliente = new clientes_list_request()
        //    {
        //        clientesFiltro = new clientesFiltro()
        //        {
        //            cnpj_cpf = cnpj
        //        }
        //    };
        //    return await soapClient.ListarClientesAsync(cliente);
        //}
        //protected async Task<fin_conta_corrente_pesquisar_resposta> GetContaCorrenteOmie()
        //{
        //    var soapClient = new ContaCorrenteCadastroSoapClient();
        //    var builder = new EndpointAddressBuilder(soapClient.Endpoint.Address);
        //    builder.Headers.Add(AddressHeader.CreateAddressHeader("app_key", "", _omieKey));
        //    builder.Headers.Add(AddressHeader.CreateAddressHeader("app_secret", "", _omieSecret));
        //    soapClient.Endpoint.Address = builder.ToEndpointAddress();
        //    return await soapClient.PesquisarContaCorrenteAsync(new fin_conta_corrente_pesquisar());
        //}
        //protected async Task<produto_servico_listfull_response> GetProdutoOmie(string descricao)
        //{
        //    var soapClient = new ProdutosCadastroSoapClient();
        //    var builder = new EndpointAddressBuilder(soapClient.Endpoint.Address);
        //    builder.Headers.Add(AddressHeader.CreateAddressHeader("app_key", "", _omieKey));
        //    builder.Headers.Add(AddressHeader.CreateAddressHeader("app_secret", "", _omieSecret));
        //    soapClient.Endpoint.Address = builder.ToEndpointAddress();
        //    var filtro = new produto_servico_list_request()
        //    {
        //        pagina = "1",
        //        registros_por_pagina = "50",
        //        apenas_importado_api = "N",
        //        filtrar_apenas_omiepdv = "N",
        //        filtrar_apenas_descricao = "%" + descricao + "%"
        //    };
        //    var retorno = await soapClient.ListarProdutosAsync(filtro);
        //    return retorno;
        //}

        //private static string RemoveSpecialCharacters(string str)
        //{
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (char c in str)
        //        {
        //            if (c >= '0' && c <= '9')
        //            {
        //                sb.Append(c);
        //            }
        //        }
        //        return sb.ToString();
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}
    }
}
