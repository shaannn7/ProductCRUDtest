using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Entity
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryid { get; set; }
        [Required]
        public string categoryname { get; set; }    
        public virtual ICollection<Product> product { get; set; }
    }
}
