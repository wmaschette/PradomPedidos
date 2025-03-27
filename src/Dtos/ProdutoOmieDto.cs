namespace PedidosPradom.Dtos
{
    public class ProdutoOmieDto
    {
        public string CodigoProduto { get; set; }
        public string Unidade { get; set; }
        public decimal Preco { get; set; }
        public decimal PrecoReal { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
    }
}
