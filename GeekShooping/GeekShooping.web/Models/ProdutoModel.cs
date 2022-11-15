namespace GeekShooping.web.Models
{
    public class ProdutoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ImagemUrl { get; set; }
    }
}
