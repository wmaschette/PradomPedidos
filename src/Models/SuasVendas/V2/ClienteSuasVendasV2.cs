using Newtonsoft.Json;

namespace PedidosPradom.Models.SuasVendas.V2
{
    public class ClienteSuasVendasV2
    {
        [JsonProperty("cont_nome_fantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty("cont_razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty("cont_endereco")]
        public string Endereco { get; set; }

        [JsonProperty("cont_numero")]
        public string Numero { get; set; }

        [JsonProperty("cont_bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cont_cep")]
        public string Cep { get; set; }

        [JsonProperty("cont_cidade")]
        public string Cidade { get; set; }

        [JsonProperty("cont_uf")]
        public string Uf { get; set; }

        [JsonProperty("cont_pais")]
        public string Pais { get; set; }

        [JsonProperty("cont_cnpj_cpf")]
        public string CnpjCpf { get; set; }

        [JsonProperty("cont_inscricao_estadual")]
        public string InscricaoEstadual { get; set; }

        [JsonProperty("cont_inscricao_municipal")]
        public string InscricaoMunicipal { get; set; }

        [JsonProperty("cont_website")]
        public string Website { get; set; }

        [JsonProperty("cont_email")]
        public string Email { get; set; }

        [JsonProperty("cont_obs")]
        public string Observacoes { get; set; }

        [JsonProperty("cont_telefone")]
        public string Telefone { get; set; }

        [JsonProperty("cont_telefone2")]
        public string Telefone2 { get; set; }

        [JsonProperty("cont_info_comercial")]
        public string InfoComercial { get; set; }

        [JsonProperty("cont_endereco_cobranca")]
        public string EnderecoCobranca { get; set; }

        [JsonProperty("cont_endereco_entrega")]
        public string EnderecoEntrega { get; set; }

        [JsonProperty("cont_segmento")]
        public string Segmento { get; set; }

        [JsonProperty("cont_suframa")]
        public string Suframa { get; set; }

        [JsonProperty("cont_info_bancaria")]
        public string InfoBancaria { get; set; }

        [JsonProperty("cont_rg")]
        public string Rg { get; set; }

        [JsonProperty("cont_email_nfe")]
        public string EmailNfe { get; set; }

        [JsonProperty("cont_codigo")]
        public string Codigo { get; set; }

        [JsonProperty("cont_dias_desativacao")]
        public string DiasDesativacao { get; set; }

        [JsonProperty("cont_estado_civil")]
        public string EstadoCivil { get; set; }

        [JsonProperty("cont_sexo")]
        public string Sexo { get; set; }

        [JsonProperty("cont_pessoa")]
        public string TipoPessoa { get; set; } // PJ ou PF

        [JsonProperty("cont_status")]
        public string Status { get; set; }
    }
}
