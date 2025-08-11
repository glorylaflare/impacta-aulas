namespace MiniProjetoEntregas.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; } // Calculado, pode ser ajustado
        public DateTime DataPedido { get; set; }
        public string FormaEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Documento> Documentos { get; set; }
        public ICollection<Entrega> Entregas { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
