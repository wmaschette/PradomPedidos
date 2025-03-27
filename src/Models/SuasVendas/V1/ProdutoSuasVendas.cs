using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosPradom.Models.SuasVendas.V1
{
    public class ProdutoSuasVendas
    {
        public int prod_id { get; set; }
        public int prod_cont_id { get; set; }
        public string prod_codigo { get; set; }
        public string prod_nome { get; set; }
        public double prod_preco { get; set; }
        public string prod_embalagem { get; set; }
        public string prod_unidade_medida { get; set; }
        public string prod_obs { get; set; }
        public int prod_status { get; set; }
        public string prod_ipi { get; set; }
        public int prod_tapr_id { get; set; }
        public int prod_estoque_minimo { get; set; }
        public string prod_cores { get; set; }
        public string prod_ncm { get; set; }
        public double prod_peso_liquido { get; set; }
        public double prod_peso_bruto { get; set; }
        public double prod_preco_promocao { get; set; }
        public double prod_altura { get; set; }
        public double prod_largura { get; set; }
        public double prod_comprimento { get; set; }
        public string prod_marca { get; set; }
        public string prod_modelo { get; set; }
        public int ys_cola_id { get; set; }
        public DateTime ys_datahora_insercao { get; set; }
        public DateTime ys_datahora_atualizacao { get; set; }
        public int ys_operacao { get; set; }
    }
}
