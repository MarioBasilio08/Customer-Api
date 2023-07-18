using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Deseripcion { get; set; }
        public string? Marca { get; set; }
        public decimal? Precio { get; set; }

    }
}
