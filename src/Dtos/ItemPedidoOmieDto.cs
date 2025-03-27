namespace PedidosPradom.Dtos
{
    public class ItemPedidoOmieDto
    {
        public int Id { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal PrecoReal { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
    }
}
