using Newtonsoft.Json;
using PedidosPradom.Dtos;

namespace PedidosPradom.Models
{
    namespace AppPedidos.Model
    {
        public class PedidoSuasVendasV2
        {
            public int pedi_id { get; set; }
            public int pedi_cont_id { get; set; }
            public int pedi_forn_id { get; set; }
            public int pedi_cola_id { get; set; }
            public int pedi_pest_id { get; set; }
            public int pedi_quem_digitou { get; set; }
            public List<ItemPedido> pedi_itens { get; set; }
            public List<ParcelaComissao> pedi_parcelas_comissao { get; set; }
            public bool pedi_bloqueado { get; set; }
            public double pedi_dolar { get; set; }
            public double pedi_comissao { get; set; }
            public double pedi_comissao_padrao { get; set; }
            public double pedi_acrescimo { get; set; }
            public double pedi_desconto { get; set; }
            public double pedi_frete_valor { get; set; }
            public string pedi_status_envio { get; set; }
            public string pedi_condicao { get; set; }
            public string pedi_obs { get; set; }
            public string pedi_desconto_encadeado { get; set; }
            public DateTime pedi_data_cadastro { get; set; }
            public DateTime pedi_data_fatura { get; set; }
            public DateTime pedi_previsao_entrega { get; set; }
            public string pedi_tipo { get; set; }
            public string pedi_status { get; set; }
            public int ys_cola_id { get; set; }
            public DateTime ys_datahora { get; set; }
            public DateTime ys_datahora_insercao { get; set; }
            public DateTime ys_datahora_atualizacao { get; set; }
            public int excluido { get; set; }
            public int numero_pagina { get; set; }
            public int qtde_paginas { get; set; }
        }

        public class ItemPedido
        {
            [JsonProperty("peit_id")]
            public int Id { get; set; }

            [JsonProperty("peit_pedi_id")]
            public int PedidoId { get; set; }

            [JsonProperty("peit_prod_id")]
            public int ProdutoId { get; set; }

            [JsonProperty("peit_peso")]
            public double Peso { get; set; }

            [JsonProperty("peit_peso_liquido")]
            public double PesoLiquido { get; set; }

            [JsonProperty("peit_preco")]
            public double Preco { get; set; }

            [JsonProperty("peit_preco_real")]
            public double PrecoReal { get; set; }

            [JsonProperty("peit_qtde")]
            public double Quantidade { get; set; }

            [JsonProperty("peit_qtde_faturada")]
            public double QuantidadeFaturada { get; set; }

            [JsonProperty("peit_ipi")]
            public double Ipi { get; set; }

            [JsonProperty("peit_cor")]
            public string Cor { get; set; }

            [JsonProperty("peit_embalagem")]
            public string Embalagem { get; set; }

            [JsonProperty("peit_desconto")]
            public string Desconto { get; set; }

            [JsonProperty("peit_altura")]
            public double Altura { get; set; }

            [JsonProperty("peit_comprimento")]
            public double Comprimento { get; set; }

            [JsonProperty("peit_largura")]
            public double Largura { get; set; }

            [JsonProperty("ys_cola_id")]
            public int ColaId { get; set; }

            [JsonProperty("ys_datahora")]
            public DateTime DataHora { get; set; }

            [JsonProperty("ys_datahora_insercao")]
            public DateTime DataHoraInsercao { get; set; }

            [JsonProperty("excluido")]
            public int Excluido { get; set; }

            [JsonProperty("numero_pagina")]
            public int NumeroPagina { get; set; }

            public ItemPedidoOmieDto ToOmieDto()
            {
                return new ItemPedidoOmieDto
                {
                    Id = Id,
                    Quantidade = (decimal)Quantidade,
                    Preco = (decimal)Preco,
                    PrecoReal = (decimal)PrecoReal,
                    PesoBruto = (decimal)Peso,
                    PesoLiquido = (decimal)PesoLiquido
                };
            }
        }

        public class ParcelaComissao
        {
            public int pefa_id { get; set; }
            public int pefa_pedi_id { get; set; }
            public double pefa_valor { get; set; }
            public DateTime pefa_data { get; set; }
            public DateTime pefa_data_agrupamento { get; set; }
            public string pefa_status { get; set; }
            public int ys_cola_id { get; set; }
            public DateTime ys_datahora { get; set; }
            public DateTime ys_datahora_insercao { get; set; }
            public DateTime ys_datahora_atualizacao { get; set; }
            public int excluido { get; set; }
            public int numero_pagina { get; set; }
        }
    }

}
