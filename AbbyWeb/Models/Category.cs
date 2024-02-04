using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name{ get; set; }
        [Required]
        [Display(Name="Display Order")]
        [Range(0,100,ErrorMessage ="please enternumber between")]  
        public string  DisplayOrder { get; set; }
    }
}
