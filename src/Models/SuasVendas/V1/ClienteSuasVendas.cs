using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosPradom.Models.SuasVendas.V1
{
    public class ClienteSuasVendas
    {
        public int cont_id { get; set; }
        public int cont_tipo { get; set; }
        public int cont_pessoa { get; set; }
        public string cont_nome_fantasia { get; set; }
        public string cont_razao_social { get; set; }
        public string cont_endereco { get; set; }
        public string cont_numero { get; set; }
        public string cont_bairro { get; set; }
        public string cont_cep { get; set; }
        public string cont_cidade { get; set; }
        public string cont_estado { get; set; }
        public string cont_cnpj_cpf { get; set; }
        public string cont_inscricao_estadual { get; set; }
        public string cont_email { get; set; }
        public string cont_obs { get; set; }
        public string cont_telefone { get; set; }
        public int cont_status { get; set; }
        public int cont_casas_decimais { get; set; }
        public bool cont_usa_cores { get; set; }
        public bool cont_validar_embalagem { get; set; }
        public bool cont_usa_grades { get; set; }
        public string cont_email_nfe { get; set; }
        public List<ClienteVendedor> ClienteVendedor { get; set; }
        public int ys_cola_id { get; set; }
        public DateTime ys_datahora_insercao { get; set; }
        public DateTime ys_datahora_atualizacao { get; set; }
        public int ys_operacao { get; set; }
    }
    public class ClienteVendedor
    {
        public int clve_cont_id { get; set; }
        public int clve_cola_id { get; set; }
        public DateTime ys_datahora_insercao { get; set; }
        public DateTime ys_datahora_atualizacao { get; set; }
        public int ys_operacao { get; set; }
    }
}
