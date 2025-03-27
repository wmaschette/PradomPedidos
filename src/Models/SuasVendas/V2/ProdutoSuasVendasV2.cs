using Newtonsoft.Json;
using PedidosPradom.Dtos;

namespace PedidosPradom.Models.SuasVendas.V2
{
    public class ProdutoSuasVendasV2
    {
        [JsonProperty("prod_id")]
        public int Id { get; set; }

        [JsonProperty("prod_cont_id")]
        public int IndustriaId { get; set; }

        [JsonProperty("prod_tapr_id")]
        public int TabelaPrecoId { get; set; }

        [JsonProperty("prod_imposto_icms")]
        public List<ProdutoIcms> ImpostosIcms { get; set; }

        [JsonProperty("prod_estoque_minimo")]
        public int EstoqueMinimo { get; set; }

        [JsonProperty("prod_preco")]
        public decimal Preco { get; set; }

        [JsonProperty("prod_promocao")]
        public decimal Promocao { get; set; }

        [JsonProperty("prod_peso")]
        public decimal Peso { get; set; }

        [JsonProperty("prod_altura")]
        public decimal Altura { get; set; }

        [JsonProperty("prod_comprimento")]
        public decimal Comprimento { get; set; }

        [JsonProperty("prod_largura")]
        public decimal Largura { get; set; }

        [JsonProperty("prod_comissao")]
        public decimal Comissao { get; set; }

        [JsonProperty("prod_ipi")]
        public decimal Ipi { get; set; }

        [JsonProperty("prod_codigo")]
        public string Codigo { get; set; }

        [JsonProperty("prod_descricao")]
        public string Descricao { get; set; }

        [JsonProperty("prod_embalagem")]
        public string Embalagem { get; set; }

        [JsonProperty("prod_unidade")]
        public string Unidade { get; set; }

        [JsonProperty("prod_ncm")]
        public string Ncm { get; set; }

        [JsonProperty("prod_detalhes")]
        public string Detalhes { get; set; }

        [JsonProperty("prod_status")]
        public string Status { get; set; }

        [JsonProperty("prod_estoque")]
        public decimal Estoque { get; set; }

        [JsonProperty("prod_origem")]
        public string Origem { get; set; }

        [JsonProperty("prod_total_tributos")]
        public decimal TotalTributos { get; set; }

        [JsonProperty("ys_cola_id")]
        public int ColaId { get; set; }

        [JsonProperty("ys_datahora")]
        public DateTime DataHora { get; set; }

        [JsonProperty("ys_datahora_insercao")]
        public DateTime DataHoraInsercao { get; set; }

        [JsonProperty("ys_datahora_atualizacao")]
        public DateTime DataHoraAtualizacao { get; set; }

        [JsonProperty("excluido")]
        public int Excluido { get; set; }

        [JsonProperty("numero_pagina")]
        public int NumeroPagina { get; set; }

        [JsonProperty("qtde_paginas")]
        public int QtdePaginas { get; set; }

        public ProdutoOmieDto ToOmieDto()
        {
            return new ProdutoOmieDto
            {
                CodigoProduto = Codigo,
                Unidade = Unidade,
                Preco = Preco,
                PrecoReal = Preco, // Ou Promocao, se preferir
                PesoBruto = Peso,
                PesoLiquido = Peso // Ou pode usar cálculo se tiver campo específico
            };
        }
    }

    public class ProdutoIcms
    {
        [JsonProperty("pric_prod_id")]
        public int ProdutoId { get; set; }

        [JsonProperty("pric_origem")]
        public string Origem { get; set; }

        [JsonProperty("pric_cst_csosn")]
        public string CstCsosn { get; set; }

        [JsonProperty("ys_datahora")]
        public DateTime DataHora { get; set; }

        [JsonProperty("ys_datahora_insercao")]
        public DateTime DataHoraInsercao { get; set; }

        [JsonProperty("ys_datahora_atualizacao")]
        public DateTime DataHoraAtualizacao { get; set; }

        [JsonProperty("excluido")]
        public int Excluido { get; set; }

        [JsonProperty("numero_pagina")]
        public int NumeroPagina { get; set; }
    }

}
