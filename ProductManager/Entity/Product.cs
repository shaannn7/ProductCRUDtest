using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productid { get; set; }
        [Required]
        public string productname { get; set; }
        [Required]
        public int productprice { get; set; }
        [Required]
        public int categoryid { get; set; }
        public virtual Category category { get; set; }
    }
}
