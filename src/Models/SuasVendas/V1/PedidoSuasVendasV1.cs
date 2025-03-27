using Newtonsoft.Json;
using PedidosPradom.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosPradom.Models.SuasVendas.V1
{
    public partial class PedidoSuasVendasV1
    {
        [JsonProperty("pedi_id")]
        public long PediId { get; set; }

        [JsonProperty("pedi_clie_id")]
        public long PediClieId { get; set; }

        [JsonProperty("pedi_cola_id")]
        public long PediColaId { get; set; }

        [JsonProperty("pedi_condicao_pagamento")]
        public string PediCondicaoPagamento { get; set; }

        [JsonProperty("pedi_comissao")]
        public long PediComissao { get; set; }

        [JsonProperty("pedi_comissao_padrao")]
        public long PediComissaoPadrao { get; set; }

        [JsonProperty("pedi_status_envio_email")]
        public bool PediStatusEnvioEmail { get; set; }

        [JsonProperty("pedi_obs")]
        public string PediObs { get; set; }

        [JsonProperty("pedi_data_emissao")]
        public DateTimeOffset PediDataEmissao { get; set; }

        [JsonProperty("pedi_status_comissionamento")]
        public long PediStatusComissionamento { get; set; }

        [JsonProperty("pedi_data_fatura")]
        public DateTimeOffset PediDataFatura { get; set; }

        [JsonProperty("pedi_acrescimo")]
        public long PediAcrescimo { get; set; }

        [JsonProperty("pedi_desconto")]
        public long PediDesconto { get; set; }

        [JsonProperty("pedi_pest_id")]
        public long PediPestId { get; set; }

        [JsonProperty("pedi_cotacao_dolar")]
        public long PediCotacaoDolar { get; set; }

        [JsonProperty("pedi_valor_frete")]
        public double PediValorFrete { get; set; }

        [JsonProperty("pedi_desconto_encadeado")]
        public string PediDescontoEncadeado { get; set; }

        [JsonProperty("pedi_bloqueado")]
        public bool PediBloqueado { get; set; }

        [JsonProperty("pedi_cola_id_digitou")]
        public long PediColaIdDigitou { get; set; }

        [JsonProperty("pedi_tipo")]
        public long PediTipo { get; set; }

        [JsonProperty("PedidoItem")]
        public PedidoItem[] PedidoItem { get; set; }

        [JsonProperty("PedidoComissao")]
        public PedidoComissao[] PedidoComissao { get; set; }

        [JsonProperty("PedidoParcela")]
        public PedidoParcela[] PedidoParcela { get; set; }

        [JsonProperty("ys_cola_id")]
        public long YsColaId { get; set; }

        [JsonProperty("ys_datahora_insercao")]
        public DateTimeOffset YsDatahoraInsercao { get; set; }

        [JsonProperty("ys_datahora_atualizacao")]
        public DateTimeOffset YsDatahoraAtualizacao { get; set; }

        [JsonProperty("ys_operacao")]
        public long YsOperacao { get; set; }
    }

    public partial class PedidoComissao
    {
        [JsonProperty("peco_id")]
        public long PecoId { get; set; }

        [JsonProperty("peco_pedi_id")]
        public long PecoPediId { get; set; }

        [JsonProperty("peco_data_prevista")]
        public DateTimeOffset PecoDataPrevista { get; set; }

        [JsonProperty("peco_valor_previsto")]
        public double PecoValorPrevisto { get; set; }

        [JsonProperty("peco_status")]
        public long PecoStatus { get; set; }

        [JsonProperty("peco_valor_recebido")]
        public long PecoValorRecebido { get; set; }

        [JsonProperty("ys_cola_id")]
        public long YsColaId { get; set; }

        [JsonProperty("ys_datahora_insercao")]
        public DateTimeOffset YsDatahoraInsercao { get; set; }

        [JsonProperty("ys_datahora_atualizacao")]
        public DateTimeOffset YsDatahoraAtualizacao { get; set; }

        [JsonProperty("ys_operacao")]
        public long YsOperacao { get; set; }
    }

    public partial class PedidoItem
    {
        [JsonProperty("peit_id")]
        public long Id { get; set; }

        [JsonProperty("peit_pedi_id")]
        public long PedidoId { get; set; }

        [JsonProperty("peit_prod_id")]
        public long ProdutoId { get; set; }

        [JsonProperty("peit_preco")]
        public double Preco { get; set; }

        [JsonProperty("peit_qtde")]
        public long Quantidade { get; set; }

        [JsonProperty("peit_ipi")]
        public long Ipi { get; set; }

        [JsonProperty("peit_cor")]
        public string Cor { get; set; }

        [JsonProperty("peit_st")]
        public long St { get; set; }

        [JsonProperty("peit_preco_real")]
        public double PrecoReal { get; set; }

        [JsonProperty("peit_qtde_faturada")]
        public long QuantidadeFaturada { get; set; }

        [JsonProperty("peit_embalagem")]
        public string Embalagem { get; set; }

        [JsonProperty("peit_peso_bruto")]
        public long PesoBruto { get; set; }

        [JsonProperty("peit_desconto")]
        public string Desconto { get; set; }

        [JsonProperty("peit_peso_liquido")]
        public long PesoLiquido { get; set; }

        [JsonProperty("peit_altura")]
        public double Altura { get; set; }

        [JsonProperty("peit_largura")]
        public double Largura { get; set; }

        [JsonProperty("peit_comprimento")]
        public long Comprimento { get; set; }

        [JsonProperty("ys_cola_id")]
        public long ColaId { get; set; }

        [JsonProperty("ys_datahora_insercao")]
        public DateTimeOffset DataHoraInsercao { get; set; }

        [JsonProperty("ys_datahora_atualizacao")]
        public DateTimeOffset DataHoraAtualizacao { get; set; }

        [JsonProperty("ys_operacao")]
        public long Operacao { get; set; }

        public ItemPedidoOmieDto ToOmieDto()
        {
            return new ItemPedidoOmieDto
            {
                Id = (int)Id,
                Quantidade = (decimal)Quantidade,
                Preco = (decimal)Preco,
                PrecoReal = (decimal)PrecoReal,
                PesoBruto = (decimal)PesoBruto,
                PesoLiquido = (decimal)PesoLiquido
            };
        }
    }

    public partial class PedidoParcela
    {
        [JsonProperty("pepa_id")]
        public long PepaId { get; set; }

        [JsonProperty("pepa_pedi_id")]
        public long PepaPediId { get; set; }

        [JsonProperty("pepa_data_prevista")]
        public DateTimeOffset PepaDataPrevista { get; set; }

        [JsonProperty("pepa_valor_previsto")]
        public long PepaValorPrevisto { get; set; }

        [JsonProperty("pepa_status")]
        public long PepaStatus { get; set; }

        [JsonProperty("ys_cola_id")]
        public long YsColaId { get; set; }

        [JsonProperty("ys_datahora_insercao")]
        public DateTimeOffset YsDatahoraInsercao { get; set; }

        [JsonProperty("ys_datahora_atualizacao")]
        public DateTimeOffset YsDatahoraAtualizacao { get; set; }

        [JsonProperty("ys_operacao")]
        public long YsOperacao { get; set; }
    }

    
}
